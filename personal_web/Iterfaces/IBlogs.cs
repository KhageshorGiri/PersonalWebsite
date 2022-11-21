using personal_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_web.Iterfaces
{
    interface IBlogs
    {
        IEnumerable<Blog> GetAllBlogs();

        IEnumerable<BlogCategory> GetBlogCategories();

        void CreateBlogCategory(BlogCategory blogCategory);

        Blog GetBlog(int Id);

        void CreateBlog(Blog blog);

        void UpdteBlog(Blog blog);

        void DeleteBlog(int Id);

        void DeleteBlogCategory(int Id);
    }
}
