using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MyMAUI.Services;
using MyMAUI.Models;
using CommunityToolkit.Maui.MediaElement;

namespace MyMAUI.ViewModels
{
    class VideoVM : Notify
    {
        public VideoInfo _VideoInfo { get; set; }
        public VideoInfo VideoInfo
        {
            get=> _VideoInfo;
            set
            {
                if(_VideoInfo != value)
                {
                    _VideoInfo = value;
                    OnPropertyChanged(nameof(VideoInfo));
                }
            }
        }
        public ObservableCollection<VideoInfo> _VideoList = new ObservableCollection<VideoInfo>();
        public ObservableCollection<VideoInfo> VideoList
        {
            get => _VideoList;
            set
            {
                if(_VideoList != value)
                {
                    _VideoList = value;
                    OnPropertyChanged(nameof(VideoList));
                }
            }
        }

        public VideoVM()
        {
            AddVideo();
        }

        public void AddVideo()
        {

            VideoList.Add(new VideoInfo("test1", MediaSource.FromUri("https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4")));
            VideoList.Add(new VideoInfo("test2",  MediaSource.FromUri("https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4")));
        }

    }
}
