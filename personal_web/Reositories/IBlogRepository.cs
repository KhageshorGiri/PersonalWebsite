using personal_web.Iterfaces;
using personal_web.Model_Context;
using personal_web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace personal_web.Reositories
{
    public class IBlogRepository : IBlogs
    {
        private PersonalWeb_context dbContext;
        public IBlogRepository(PersonalWeb_context _context)
        {
            this.dbContext = _context;
        }
        public void CreateBlog(Blog blog)
        {
            dbContext.Blogs.Add(blog);
            dbContext.SaveChanges();
        }

        public void DeleteBlog(int Id)
        {
            Blog blog = dbContext.Blogs.Find(Id);
            dbContext.Blogs.Remove(blog);
            dbContext.SaveChanges();
        }

        public IEnumerable<Blog> GetAllBlogs()
        {
            return dbContext.Blogs.ToList();
        }

        public Blog GetBlog(int Id)
        {
            return dbContext.Blogs.Find(Id);
        }

        public IEnumerable<BlogCategory> GetBlogCategories()
        {
            return dbContext.BlogCategories.ToList();
        }

        public void CreateBlogCategory(BlogCategory blogCategory)
        {
            dbContext.BlogCategories.Add(blogCategory);
            dbContext.SaveChanges();
        }
        public void UpdteBlog(Blog blog)
        {
            dbContext.Entry(blog).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void DeleteBlogCategory(int Id)
        {
            BlogCategory blogCategory = dbContext.BlogCategories.Find(Id);
            dbContext.BlogCategories.Remove(blogCategory);
            dbContext.SaveChanges();
        }
    }
}