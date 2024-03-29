﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGW.ConsoleApp.Models;

namespace TGW.ConsoleApp.EFCoreExamples
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDBContext db = new AppDBContext();
            List<BlogModel> lst = db.Blogs.ToList();

            foreach (BlogModel item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

        public void Edit(int id)
        {
            AppDBContext db = new AppDBContext();
            BlogModel item = db.Blogs.FirstOrDefault(item => item.BlogId == id)!;
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }

        public void Create(string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            AppDBContext db = new AppDBContext();
            db.Blogs.Add(blog);
            int result = db.SaveChanges();

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";

            Console.WriteLine(message);
        }

        public void Update(int id, string title, string author, string content)
        {
            AppDBContext db = new AppDBContext();
            BlogModel item = db.Blogs.FirstOrDefault(item => item.BlogId == id)!;
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;
            int result = db.SaveChanges();

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";

            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            AppDBContext db = new AppDBContext();
            BlogModel item = db.Blogs.FirstOrDefault(item => item.BlogId == id)!;
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            db.Blogs.Remove(item);
            int result = db.SaveChanges();

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";

            Console.WriteLine(message);
        }
    }
}
