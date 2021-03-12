using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete
{
    public class YetenekRepository : IYetenekler
    {
        public void add(Yetenekler sertfika)
        {
            using(var db=new database()){
                db.Yetenekler.Add(sertfika);
                db.SaveChanges();
            }

        }

        public void delete(int id)
        {
                using(var db=new database()){
                    db.Yetenekler.Remove(db.Yetenekler.Where(i=>i.id==id).FirstOrDefault());
                    db.SaveChanges();
                }
        }

        public List<Yetenekler> GetAll()
        {
            List<Yetenekler> yetenekler=null;
           using(var db=new database()){
               yetenekler=db.Yetenekler.ToList();
               return yetenekler;
           }
        }

        public Yetenekler GetById(int id)
        {
            Yetenekler yetenek;
            using(var db=new database()){
                yetenek=db.Yetenekler.Where(i=>i.id==id).FirstOrDefault();
            }
            return yetenek;

        }

        public void update(Yetenekler sertfika)
        {
            
            using(var db=new database()){
                db.Entry(sertfika).State = EntityState.Modified;
                db.SaveChanges();
            }

        }
    }
}