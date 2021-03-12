using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete
{
    public class KisiselRepository : IKisisel
    {
        public void add(Kisisel sertfika)
        {
        }

        public void delete(int id)
        {
        }

        public List<Kisisel> GetAll()
        {
            List<Kisisel> kimdir = null;
            using (var db = new database())
            {
                kimdir = db.Kisisel.Where(i => i.kimdir.Length > 0).ToList();
                return kimdir;
            }
        }

        public Kisisel GetById(int id)
        {
            Kisisel kimdir;
            using(var db=new database()){
                kimdir=db.Kisisel.Where(i=>i.id==1).FirstOrDefault();
            }
            return kimdir;

        }

        public void update(Kisisel kisisel)
        {
             using (var db = new database())
            {
                db.Entry(kisisel).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

    }
}