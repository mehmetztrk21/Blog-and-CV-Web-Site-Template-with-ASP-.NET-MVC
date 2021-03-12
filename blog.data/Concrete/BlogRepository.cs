using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete
{
    public class BlogRepository : IBlog
    {
        public void add(Blog sertfika)
        {
                using(var db=new database()){
                    db.Bloglar.Add(sertfika);
                    db.SaveChanges();
                }
        }

        public void delete(int id)
        {
                using(var db=new database()){
                    
                    db.Bloglar.Remove(db.Bloglar.Where(i=>i.id==id).FirstOrDefault());
                    db.SaveChanges();
                }

        }

        public List<Blog> GetAll()
        {
            using(var db=new database()){
                return db.Bloglar.ToList();
            }            
        }

        public Blog GetById(int id)
        {
            Blog blog=null;

            using(var db=new database()){
                 blog=db.Bloglar.Where(i=>i.id==id).FirstOrDefault();
            }
                return blog;
        }

        public void update(Blog sertfika)
        {
            using(var db=new database()){
                db.Entry(sertfika).State=EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}