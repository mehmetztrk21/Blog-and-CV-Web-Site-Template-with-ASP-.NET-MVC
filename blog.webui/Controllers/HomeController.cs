using System;
using Microsoft.AspNetCore.Mvc;
using shopapp.data.Abstract;
using shopapp.data.Concrete;
using shopapp.webui.Models;

namespace shopapp.webui.Controllers
{
    // localhost:5000/home
    public class HomeController : Controller  //linklerde olacak fonksiyonları buraya yazıyoruz.
    {
        ISertfika sertfika = null;
        IProje proje = null;
        IYetenekler yetenek= null;
        IKisisel kimdir = null;

        IBlog bloglar=null;


        public HomeController(ISertfika sertfikalar, IYetenekler yetenekler, IProje projeler, IKisisel kimdir,IBlog bloglar)
        {
            this.sertfika = sertfikalar;
            this.proje=projeler;
            this.yetenek=yetenekler;
            this.kimdir=kimdir;
            this.bloglar=bloglar;
        }

        //controller sınıflarına yazılan fonksyonlara action metotlar denir.

        // localhost:5000
        // localhost:5000/home
        // localhost:5000/home/index
        public IActionResult Index()
        {
            IndexModel model = new IndexModel()
            {
                sertfikalar = sertfika.GetAll(),
                yetenekler=yetenek.GetAll(),
                projeler=proje.GetAll(),
                kimdir=kimdir.GetAll()
                

            };

            return View(model);
        }

        public IActionResult Details(int id){
            var proj=proje.GetById(id);

            ProjeDetay model=new ProjeDetay(){
                name=proj.name,
                description=proj.description,
                img1=proj.img1,
                img2=proj.img2,
                img3=proj.img3
            };

            return View(model);
        }

        public IActionResult Yetenekler(){
            var yet=yetenek.GetAll();

            IndexModel model=new IndexModel(){
                yetenekler=yet
            };
            return View(model);
        }
          public IActionResult Projeler(){
            var proj=proje.GetAll();

            IndexModel model=new IndexModel(){
                projeler=proj
            };
            return View(model);
        }
          public IActionResult Sertfikalar(){
            var sert=sertfika.GetAll();

            IndexModel model=new IndexModel(){
                sertfikalar=sert
            };
            return View(model);
        }

        // localhost:5000/home/about

        public IActionResult Bloglar(){
            var blog=bloglar.GetAll();
            IndexModel model=new IndexModel(){
                bloglar=blog
            };


            return View(model);
        }
        public IActionResult BlogDetails(int id){
            var blog=bloglar.GetById(id);
            BlogDetails model=new BlogDetails(){
                baslik=blog.baslik,
                blog=blog.blog,
                img=blog.img
            };

            return View(model);
        }


    }
}