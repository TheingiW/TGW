using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TGW.ConsoleApp.Models;
using Dapper;

namespace TGW.ConsoleApp.DapperExamples
{
    public class DapperExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "TestDb",
            UserID = "sa",
            Password = "sasa@123"
        };


        public void Read()
        {
            string query = @"SELECT [BlogId]
                              ,[BlogTitle]
                              ,[BlogAuthor]
                              ,[BlogContent]
                          FROM [dbo].[tbl_blog]";

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> lst = db.Query<BlogModel>(query).ToList();

            foreach (BlogModel item in lst)
            {

                Console.WriteLine("Title......." + item.BlogId);
                Console.WriteLine("Title......." + item.BlogTitle);
                Console.WriteLine("Author....." + item.BlogAuthor);
                Console.WriteLine("Content...." + item.BlogContent);

            }
        }

        public void Edit(int id)
        {
            string query = @"SELECT [BlogId]
                              ,[BlogTitle]
                              ,[BlogAuthor]
                              ,[BlogContent]
                          FROM [dbo].[tbl_blog] WHERE BlogID=@BlogId";
            BlogModel blog = new BlogModel()
            {
                BlogId = id,
            };
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogModel>(query, blog).FirstOrDefault();

            if (item is null)
            {
                Console.WriteLine("No Data Found.");
                return;
            }
            Console.WriteLine("Title......." + item.BlogId);
            Console.WriteLine("Title......." + item.BlogTitle);
            Console.WriteLine("Author....." + item.BlogAuthor);
            Console.WriteLine("Content...." + item.BlogContent);

        }
        public void Create(string title, string author, string content)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
             VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

            BlogModel blogModel = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blogModel);

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";

            Console.WriteLine(message);


        }

        public void Update(int id, string title, string author, string content)
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
                           SET [BlogTitle] = @BlogTitle
                              ,[BlogAuthor] = @BlogAuthor
                              ,[BlogContent] = @BlogContent
                         WHERE BlogId = @BlogId";

            BlogModel blog = new BlogModel()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";

            Console.WriteLine(message);
        }
        public void Delete(int id)
        {
            string query = @"Delete From [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";

            BlogModel blog = new BlogModel()
            {
                BlogId = id,
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);
            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";

            Console.WriteLine(message);
        }

    }
}
