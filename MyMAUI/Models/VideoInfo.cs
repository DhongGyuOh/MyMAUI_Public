using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.MediaElement;

namespace MyMAUI.Models
{
    public class VideoInfo
    {
        public string VideoName {  get; set; }
        public MediaSource VideoSource { get; set; }
        
        public VideoInfo(string _VideoName, MediaSource _VideoSource)
        {
            VideoName = _VideoName;
            VideoSource = _VideoSource;
        }
    }
}
