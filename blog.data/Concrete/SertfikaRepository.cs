using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete
{
    public class SertfikaRepository : ISertfika
    {
        public void add(Sertfika sertfika)
        {
                using(var db=new database()){
                        db.Sertfikalar.Add(sertfika);
                        db.SaveChanges();
                }
        }

        public void delete(int id)
        {
                using(var db=new database()){
                    db.Sertfikalar.Remove(db.Sertfikalar.Where(i=>i.id==id).FirstOrDefault());
                    db.SaveChanges();
                }
        }

        public List<Sertfika> GetAll()
        {
            using(var db=new database()){
                return db.Sertfikalar.ToList();
            }

        }

        public Sertfika GetById(int id)
        {
            Sertfika sertfika;
            using(var db=new database()){
                sertfika=db.Sertfikalar.Where(i=>i.id==id).FirstOrDefault();
            }
            return sertfika;

        }

        public void update(Sertfika sertfika)
        {
        using (var db = new database())
            {
                db.Entry(sertfika).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}