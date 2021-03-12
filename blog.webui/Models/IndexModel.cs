using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.webui.Models
{
    public class IndexModel
    {
        public List<Kisisel>  kimdir { get; set; }
        public List<Sertfika> sertfikalar{get;set;}
        public List<Proje> projeler { get; set; }
        public List<Yetenekler> yetenekler { get; set; }
        public List<Blog> bloglar { get; set; }
    }
}