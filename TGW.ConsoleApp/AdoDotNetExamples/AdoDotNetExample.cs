using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace TGW.ConsoleApp.AdoDotNetExamples
{
    public class AdoDotNetExample
    {

        public void Read()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "DESKTOP-STO7F37\\SQLEXPRESS2016";
            sqlConnectionStringBuilder.InitialCatalog = "db_Testing";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa";

            string query = @"SELECT [BlogId]
                              ,[BlogTitle]
                              ,[BlogAuthor]
                              ,[BlogContent]
                          FROM [dbo].[tbl_blog]";


            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            Console.WriteLine("Connection Opening.......");
            sqlConnection.Open();
            Console.WriteLine("Connection Opened");


            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Console.WriteLine("Connection Closeing.......");
            sqlConnection.Close();
            Console.WriteLine("Connection Closed");

            foreach (DataRow dr in dt.Rows)
            {

                Console.WriteLine("Title......." + dr["BlogTitle"]);
                Console.WriteLine("Author....." + dr["BlogAuthor"]);
                Console.WriteLine("Content...." + dr["BlogContent"]);
            }
        }

        public void Edit(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "DESKTOP-STO7F37\\SQLEXPRESS2016";
            sqlConnectionStringBuilder.InitialCatalog = "db_Testing";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa";

            string query = @"SELECT [BlogId]
                              ,[BlogTitle]
                              ,[BlogAuthor]
                              ,[BlogContent]
                          FROM [dbo].[tbl_blog] WHERE BlogID=@BlogId";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            sqlConnection.Close();
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No Data Found.");
                return;
            }

            DataRow dr = dt.Rows[0];

            Console.WriteLine("Title......." + dr["BlogTitle"]);
            Console.WriteLine("Author....." + dr["BlogAuthor"]);
            Console.WriteLine("Content...." + dr["BlogContent"]);


        }

        public void Create(string title, string author, string content)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "DESKTOP-STO7F37\\SQLEXPRESS2016";
            sqlConnectionStringBuilder.InitialCatalog = "db_Testing";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa";

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();

            sqlConnection.Close();

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";

            Console.WriteLine(message);


        }

        public void Delete(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "DESKTOP-STO7F37\\SQLEXPRESS2016";
            sqlConnectionStringBuilder.InitialCatalog = "db_Testing";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa";

            string query = "Delete FROM [dbo].[tbl_blog] WHERE BlogID=@BlogId";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            Console.WriteLine(message);



        }

        public void Update(int id, string title, string author, string content)
        {

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "DESKTOP-STO7F37\\SQLEXPRESS2016";
            sqlConnectionStringBuilder.InitialCatalog = "db_Testing";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa";

            string query = @"UPDATE [dbo].[Tbl_Blog]
                           SET [BlogTitle] = @BlogTitle
                              ,[BlogAuthor] = @BlogAuthor
                              ,[BlogContent] = @BlogContent
                         WHERE BlogId = @BlogId";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            cmd.Parameters.AddWithValue("@BlogID", id);

            int result = cmd.ExecuteNonQuery();

            sqlConnection.Close();

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";

            Console.WriteLine(message);


        }

    }
}
