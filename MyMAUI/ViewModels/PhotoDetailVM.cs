using MyMAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyMAUI.Services;
using Plugin.Maui.Audio;

namespace MyMAUI.ViewModels
{
    [QueryProperty(nameof(photos),"photos")]
    class PhotoDetailVM : Notify
    {
        public IAudioManager audioManager { get; set; }
        public IAudioPlayer audioPlayer { get; set; }
        public PhotoDetailVM()
        {
            PlaySound();
        }
        public AlbumEntity _photos { get; set; }
        public AlbumEntity photos
        {
            get => _photos;
            set
            {
                if(_photos != value)
                {
                    _photos = value;
                    OnPropertyChanged("photos");
                }
            }
        }

        public async void PlaySound()
        {
            this.audioManager = new AudioManager();
            audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("sound_pop.mp3"));
            await Task.Delay(100);
            audioPlayer.Play();
        }



    }
}
