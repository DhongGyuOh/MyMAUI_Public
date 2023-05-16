using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMAUI.Models;
using MyMAUI.Services;
using Plugin.Maui.Audio;
using System.Windows.Input;
using static MyMAUI.Models.AlbumEntity;

namespace MyMAUI.ViewModels
{
    [QueryProperty(nameof(mozzas),"mozzas")]
    class MozzaDetailVM : Notify
    {
        
        public IAudioManager audioManager { get; set; }
        public IAudioPlayer audioPlayer { get; set; }
        public MozzaDetailVM()
        {
            PlaySound();
           
        }
        public AlbumEntity _mozzas { get; set; }
        public AlbumEntity mozzas
        {
            get => _mozzas;
            set
            {
                if(_mozzas != value)
                {
                    _mozzas = value;
                    OnPropertyChanged("mozzas");
                }
            }
        }

        public async void PlaySound()
        {
            
            

            this.audioManager = new AudioManager();
            audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("cat_sound2.wav"));
            audioPlayer.Play();
        }

        
    }
    
}
