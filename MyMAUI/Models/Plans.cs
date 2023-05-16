using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMAUI.Models
{
    public class Plans
    {
        public string Title { get; set; }
        public string Thema { get; set; }
        public Plans(string _Title,string _Thema)
        {
            Title = _Title;
            Thema = _Thema;
        }
    }

    public class PlanItem
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Img_Path { get; set;}
        public string Description {  get; set; }
        public PlanItem(string _Title, string _SubTitle, string _Img_Path, string _Description)
        {
            Title = _Title;
            SubTitle = _SubTitle;
            Img_Path = _Img_Path;
            Description = _Description;
        }
    }
}
