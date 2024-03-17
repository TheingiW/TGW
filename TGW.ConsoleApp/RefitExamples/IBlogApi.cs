using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Refit;
using System.Threading.Tasks;
using TGW.ConsoleApp.Models;

namespace TGW.ConsoleApp.RefitExamples
{
   
        public interface IBlogApi
        {
            [Get("/api/blog")]
            Task<List<BlogModel>> GetBlogs();

            [Get("/api/blog/{id}")]
            Task<BlogModel> GetBlog(int id);

            [Post("/api/blog")]
            Task<string> CreateBlog(BlogModel blog);

            [Put("/api/blog/{id}")]
            Task<string> UpdateBlog(int id, BlogModel blog);

            [Delete("/api/blog/{id}")]
            Task<string> DeleteBlog(int id);
        }
    }
