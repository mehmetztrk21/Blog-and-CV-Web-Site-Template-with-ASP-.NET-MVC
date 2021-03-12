using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopapp.data.Abstract;
using shopapp.entity;
using shopapp.webui.Models;

namespace shopapp.webui.Controllers
{
    public class AdminController : Controller
    {
        ISertfika sertfika = null;
        IProje proje = null;
        IYetenekler yetenek = null;
        IKisisel kimdir = null;
        IBlog blog = null;


        public AdminController(ISertfika sertfikalar, IYetenekler yetenekler, IProje projeler, IKisisel kimdir, IBlog blog)
        {
            this.sertfika = sertfikalar;
            this.proje = projeler;
            this.yetenek = yetenekler;
            this.kimdir = kimdir;
            this.blog = blog;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllSertfika()
        {
            var sert = sertfika.GetAll();

            IndexModel model = new IndexModel()
            {
                sertfikalar = sert
            };

            return View(model);
        }

        public IActionResult DeleteSertfika(int id)
        {
            sertfika.delete(id);

            return RedirectToAction("AllSertfika");
        }

        [HttpGet]
        public IActionResult EditSertfika(int id)
        {
            var model = sertfika.GetById(id);
            return View(model);
        }


        [HttpPost]
        public IActionResult EditSertfika(Sertfika s)
        {

            Sertfika model = new Sertfika()
            {
                id = s.id,
                name = s.name,
                description = s.description,
                kurum = s.kurum
            };

            sertfika.update(model);
            return RedirectToAction("AllSertfika");
        }

        [HttpGet]
        public IActionResult AddSertfika()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSertfika(Sertfika s)
        {
            Sertfika model = new Sertfika()
            {
                name = s.name,
                kurum = s.kurum,
                description = s.description
            };

            sertfika.add(model);

            return RedirectToAction("AllSertfika");
        }


        public IActionResult AllProje()
        {
            var proj = proje.GetAll();

            IndexModel model = new IndexModel()
            {
                projeler = proj
            };

            return View(model);
        }

        public IActionResult DeleteProje(int id)
        {
            proje.delete(id);

            return RedirectToAction("AllProje");
        }

        [HttpGet]
        public IActionResult AddProje()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProje(Proje proj)
        {
            Proje model = new Proje()
            {
                name = proj.name,
                ozet = proj.ozet,
                description = proj.description,
                img1 = proj.img1,
                img2 = proj.img2,
                img3 = proj.img3
            };

            proje.add(model);
            return RedirectToAction("AllProje");
        }

        [HttpGet]
        public IActionResult EditProje(int id)
        {
            var model = proje.GetById(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditProje(Proje proj, IFormFile file1, IFormFile file2, IFormFile file3)
        {

            Proje model = new Proje()
            {
                id = proj.id,
                name = proj.name,
                description = proj.description,
                ozet = proj.ozet,
                img1 = proj.img1,
                img2 = proj.img2,
                img3 = proj.img3
            };

            if (file1 != null)
            {
                var extention = Path.GetExtension(file1.FileName);  //resmin uzantısını bulduk.
                var randomName = string.Format($"{Guid.NewGuid()}{extention}"); //rastgele bir isim tanımlama. İstediğin bir mantık ile kullanabilirsin. Guid.neGuid uzun bir sayı verir bize başka resimlerle aynı isim olmasın diye. Ayrıca uzantısını da belirttik.
                model.img1 = randomName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName); //resmin kaydedileceği yer.

                using (var stream = new FileStream(path, FileMode.Create))  //girdiğimiz yola resmi fiiksel olarak kaydetmemiz için yazdık.
                {
                    await file1.CopyToAsync(stream);  //kaydettik.
                }
            }
            if (file2 != null)
            {
                var extention = Path.GetExtension(file2.FileName);  //resmin uzantısını bulduk.
                var randomName = string.Format($"{Guid.NewGuid()}{extention}"); //rastgele bir isim tanımlama. İstediğin bir mantık ile kullanabilirsin. Guid.neGuid uzun bir sayı verir bize başka resimlerle aynı isim olmasın diye. Ayrıca uzantısını da belirttik.
                model.img2 = randomName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName); //resmin kaydedileceği yer.

                using (var stream = new FileStream(path, FileMode.Create))  //girdiğimiz yola resmi fiiksel olarak kaydetmemiz için yazdık.
                {
                    await file2.CopyToAsync(stream);  //kaydettik.
                }
            }
            if (file3 != null)
            {
                var extention = Path.GetExtension(file3.FileName);  //resmin uzantısını bulduk.
                var randomName = string.Format($"{Guid.NewGuid()}{extention}"); //rastgele bir isim tanımlama. İstediğin bir mantık ile kullanabilirsin. Guid.neGuid uzun bir sayı verir bize başka resimlerle aynı isim olmasın diye. Ayrıca uzantısını da belirttik.
                model.img3 = randomName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName); //resmin kaydedileceği yer.

                using (var stream = new FileStream(path, FileMode.Create))  //girdiğimiz yola resmi fiiksel olarak kaydetmemiz için yazdık.
                {
                    await file3.CopyToAsync(stream);  //kaydettik.
                }
            }



            proje.update(model);

            return RedirectToAction("AllProje");
        }


        public IActionResult AllYetenek()
        {
            var yeteneklers = yetenek.GetAll();
            IndexModel model = new IndexModel()
            {
                yetenekler = yeteneklers
            };
            return View(model);
        }

        public IActionResult DeleteYetenek(int id)
        {
            yetenek.delete(id);
            return RedirectToAction("AllYetenek");
        }

        [HttpGet]
        public IActionResult EditYetenek(int id)
        {
            var model = yetenek.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditYetenek(Yetenekler yet)
        {
            Yetenekler model = new Yetenekler()
            {
                id = yet.id,
                name = yet.name,
                desc = yet.desc,
                yetkinlik = yet.yetkinlik
            };
            yetenek.update(model);
            return RedirectToAction("AllYetenek");
        }

        [HttpGet]
        public IActionResult AddYetenek()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddYetenek(Yetenekler yet)
        {
            Yetenekler yetenekler = new Yetenekler()
            {
                name = yet.name,
                desc = yet.desc,
                yetkinlik = yet.yetkinlik
            };
            yetenek.add(yetenekler);

            return RedirectToAction("AllYetenek");
        }

        [HttpGet]
        public IActionResult EditKisisel()
        {
            var model = kimdir.GetById(1);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditKisisel(Kisisel model)
        {

            Kisisel kisisel = new Kisisel()
            {
                id = 1,
                kimdir = model.kimdir
            };


            kimdir.update(kisisel);

            return RedirectToAction("Index");
        }

        public IActionResult AllBlog()
        {
            var blogs = blog.GetAll();
            IndexModel model = new IndexModel()
            {
                bloglar = blogs
            };
            return View(model);

        }

        public IActionResult DeleteBlog(int id)
        {

            blog.delete(id);

            return RedirectToAction("AllBlog");
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBlog(Blog blogs, IFormFile file1)
        {

            Blog model = new Blog()
            {
                id = blogs.id,
                baslik = blogs.baslik,
                blog = blogs.blog,
                ozet = blogs.ozet,
            };

            if (file1 != null)
            {
                var extention = Path.GetExtension(file1.FileName);  //resmin uzantısını bulduk.
                var randomName = string.Format($"{Guid.NewGuid()}{extention}"); //rastgele bir isim tanımlama. İstediğin bir mantık ile kullanabilirsin. Guid.neGuid uzun bir sayı verir bize başka resimlerle aynı isim olmasın diye. Ayrıca uzantısını da belirttik.
                model.img = randomName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName); //resmin kaydedileceği yer.

                using (var stream = new FileStream(path, FileMode.Create))  //girdiğimiz yola resmi fiiksel olarak kaydetmemiz için yazdık.
                {
                    await file1.CopyToAsync(stream);  //kaydettik.
                }
            }
            blog.add(model);
            return RedirectToAction("AllBlog");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var model = blog.GetById(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditBlog(Blog model, IFormFile file1)
        {
            Blog blogs = new Blog()
            {
                id = model.id,
                baslik = model.baslik,
                ozet = model.ozet,
                blog = model.blog,
                img=model.img
            };

            if (file1 != null)
            {
                var extention = Path.GetExtension(file1.FileName);  //resmin uzantısını bulduk.
                var randomName = string.Format($"{Guid.NewGuid()}{extention}"); //rastgele bir isim tanımlama. İstediğin bir mantık ile kullanabilirsin. Guid.neGuid uzun bir sayı verir bize başka resimlerle aynı isim olmasın diye. Ayrıca uzantısını da belirttik.
                blogs.img = randomName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName); //resmin kaydedileceği yer.

                using (var stream = new FileStream(path, FileMode.Create))  //girdiğimiz yola resmi fiiksel olarak kaydetmemiz için yazdık.
                {
                    await file1.CopyToAsync(stream);  //kaydettik.
                }
            }
            blog.update(blogs);

            return RedirectToAction("AllBlog");
        }


    }
}