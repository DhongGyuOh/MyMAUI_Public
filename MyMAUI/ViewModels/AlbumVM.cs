using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMAUI.Services;
using static MyMAUI.Models.AlbumEntity;
using System.Windows.Input;
using MyMAUI.Models;
using System.Collections.ObjectModel;
using Plugin.Maui.Audio;

namespace MyMAUI.ViewModels
{

    class AlbumVM : Notify
    {
        public IAudioManager audioManager{get;set;}
        public IAudioPlayer audioPlayer{get;set;}
        public ICommand cmd_Click { get; set; }
        public AlbumCategory _Album { get; set; }
        public AlbumCategory Album
        {
            get=> _Album;
            set
            {
                if(_Album != value)
                {
                    _Album = value;
                    OnPropertyChanged("Album");
                }
            }
        }

        public ObservableCollection<AlbumCategory> _AlbumCollection = new ObservableCollection<AlbumCategory>();
        public ObservableCollection<AlbumCategory> AlbumCollection
        {
            get => _AlbumCollection;
            set
            {
                if(_AlbumCollection != value)
                {
                    _AlbumCollection = value;
                    OnPropertyChanged("AlbumCollection");
                }
            }
        }

        public AlbumVM()
        {
            
            AddAlbum();
            PlaySound();
            cmd_Click = new Command(async(obj) =>
            {
                AlbumCategory albumCategories = (AlbumCategory)obj;
                await Shell.Current.GoToAsync("//App/" + albumCategories.Category + $"?albumCategory={albumCategories}", true,
                    new Dictionary<string, object>
                    {
                        {"albumCategories", albumCategories}
                    });
            });
        }

        public void AddAlbum()
        {
            AlbumCollection.Add(new AlbumCategory("첫번째 카테고리", "quiz_balance.jpg", "MozzaPage"));
            AlbumCollection.Add(new AlbumCategory("두번째 카테고리", "quiz_blank.jpg", "MozzaPage"));
            AlbumCollection.Add(new AlbumCategory("세번째 카테고리", "quiz_food.jpg", "PhotoPage"));
            AlbumCollection.Add(new AlbumCategory("네번째 카테고리", "quiz_yesno.jpg", "PhotoPage"));
            AlbumCollection.Add(new AlbumCategory("다섯번째 카테고리", "quiz_worldcup.jpg", "PhotoPage"));
        }

        public async void PlaySound()
        {
            this.audioManager = new AudioManager();
            audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("coffee_sound.wav"));
            audioPlayer.Play();
        }
    }
}
