using System.ComponentModel.DataAnnotations;
namespace shopapp.entity
{
    public class Blog
    {
        [Key]
        public int id { get; set; }

        public string baslik { get; set; }
        public string blog { get; set; }
        public string ozet { get; set; }
        public string img { get; set; }

     }
}