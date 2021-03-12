using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete
{
    public class ProjeRepository : IProje
    {
        public void add(Proje sertfika)
        {
            using(var db=new database()){
                db.Projeler.Add(sertfika);
                db.SaveChanges();
            }
        }

        public void delete(int id)
        {
            System.Console.WriteLine(id);
            using(var db=new database()){
                   if(db.Projeler.Where(i=>i.id==id).FirstOrDefault()!=null){
                       db.Projeler.Remove(db.Projeler.Where(i=>i.id==id).FirstOrDefault());
                   }
                    db.SaveChanges();
                }

        }

        public List<Proje> GetAll()
        {
            List<Proje> projeler = null;
            using (var db = new database())
            {
                projeler = db.Projeler.ToList();
                return projeler;
            }
        }

        public Proje GetById(int id)
        {
            Proje proje = null;
            using (var db = new database())
            {
                proje = db.Projeler.Where(i => i.id == id).FirstOrDefault();
            }
            return proje;
        }

        public void update(Proje sertfika)
        {
            using (var db = new database())
            {
                db.Entry(sertfika).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}