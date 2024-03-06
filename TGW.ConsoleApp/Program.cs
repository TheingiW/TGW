// See https://aka.ms/new-console-template for more information
using TGW.ConsoleApp.AdoDotNetExamples;

Console.WriteLine("Hello, World!");
#region Read 
//SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
//sqlConnectionStringBuilder.DataSource = "DESKTOP-STO7F37\\SQLEXPRESS2016";
//sqlConnectionStringBuilder.InitialCatalog = "db_Testing";
//sqlConnectionStringBuilder.UserID = "sa";
//sqlConnectionStringBuilder.Password = "sasa";

//string query = "SELECT * FROM tbl_Blog";


//SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
//Console.WriteLine("Connection Opening.......");
//sqlConnection.Open();
//Console.WriteLine("Connection Opened");


//SqlCommand cmd = new SqlCommand(query, sqlConnection);
//SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//DataTable dt = new DataTable();
//adapter.Fill(dt);
//Console.WriteLine("Connection Closeing.......");
//sqlConnection.Close();
//Console.WriteLine("Connection Closed");

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine(dr["BlogId"]);
//    Console.WriteLine(dr["BlogTitle"]);
//    Console.WriteLine(dr["BlogAuthor"]);
//    Console.WriteLine(dr["BlogContent"]);
//    }
#endregion

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Edit(1);
//adoDotNetExample.Edit(11);
//adoDotNetExample.Create();
//adoDotNetExample.Delete(1);

//DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Edit(1);
//dapperExample.Edit(11);
//dapperExample.Create("test title", "test author", "test content");
//dapperExample.Update(2002, "test title 2", "test author 2", "test content 2");
//dapperExample.Delete(2002);


//EFCoreExample efCoreExample = new EFCoreExample();
//efCoreExample.Read();

//efCoreExample.Edit(1);
//efCoreExample.Edit(11);

//efCoreExample.Create("test title", "test author", "test content");
//efCoreExample.Update(3002, "test title 2", "test author 2", "test content 2");
//efCoreExample.Delete(3002);
//Console.WriteLine("Waiting for api...");
//Console.ReadKey();

//HttpClientExample httpClientExample = new HttpClientExample();
//await httpClientExample.Run();

//BlogModel blog = new BlogModel();
//blog.BlogTitle = "Test";
//blog.BlogAuthor = "Test";
//blog.BlogContent = "Test";

//string json = JsonConvert.SerializeObject(blog); // C# object to Json
//Console.WriteLine(blog);
//Console.WriteLine(json);
//Console.WriteLine(blog.BlogTitle);
//Console.WriteLine(blog.BlogAuthor);
//Console.WriteLine(blog.BlogContent);
//BlogModel blog2 = JsonConvert.DeserializeObject<BlogModel>(json)!;
//Console.WriteLine(blog2.BlogTitle);
//Console.WriteLine(blog2.BlogAuthor);
//Console.WriteLine(blog2.BlogContent);
//// hello

Console.WriteLine("Waiting for api...");
Console.ReadKey();

//HttpClientExample httpClientExample = new HttpClientExample();
//await httpClientExample.Run();

