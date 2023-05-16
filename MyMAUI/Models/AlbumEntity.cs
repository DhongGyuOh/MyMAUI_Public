using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMAUI.Models
{
    public class AlbumEntity
    {
        public string Title { get; set; }
        public string Path { get; set; }
        public string Detail { get; set; }

        public AlbumEntity(string _Title, string _Path, string _Detail)
        {
            Title = _Title;
            Path = _Path;
            Detail = _Detail;
        }

    }
    public class AlbumCategory
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Category { get; set; }
        public AlbumCategory(string _Title, string _ImagePath, string _Category)
        {
            Title = _Title;
            ImagePath = _ImagePath;
            Category = _Category;
        }   
    }
}
