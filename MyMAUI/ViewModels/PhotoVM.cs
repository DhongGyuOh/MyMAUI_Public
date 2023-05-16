using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMAUI.Services;
using System.Windows.Input;
using static MyMAUI.Models.AlbumEntity;
using System.Collections.ObjectModel;
using MyMAUI.Models;
using Plugin.Maui.Audio;

namespace MyMAUI.ViewModels
{
    [QueryProperty(nameof(albumCategories), "albumCategories")]
    class PhotoVM : Notify
    {
        public IAudioManager audioManager { get; set; }
        public IAudioPlayer audioPlayer { get; set; }
        public ObservableCollection<AlbumEntity> _PhotoCollection = new ObservableCollection<AlbumEntity>();
        public ObservableCollection<AlbumEntity> PhotoCollection
        {
            get=> _PhotoCollection;
            set
            {
                if(_PhotoCollection != value)
                {
                    _PhotoCollection = value;
                    OnPropertyChanged("PhotoCollection");
                    
                }
            }
        }
        public AlbumCategory _albumCategories { get; set; }
        public AlbumCategory albumCategories
        {
            get => _albumCategories;
            set
            {
                if (_albumCategories != value)
                {
                    _albumCategories = value;
                    OnPropertyChanged("albumCategories");
                    AddPhoto();
                }
            }

        }



        public ICommand cmd_GoToDetail { get; set; }

        public PhotoVM()
        {
            PlaySound();

            cmd_GoToDetail = new Command(async(obj) =>
            {
                AlbumEntity photos = (AlbumEntity)obj;
                await Shell.Current.GoToAsync($"//App/PhotoPage/PhotoDetailPage?photo={photos}",true,
                    new Dictionary<string, object>
                    {
                        {"photos",photos }
                    });
            });
        }

        public void AddPhoto()
        {
            switch (albumCategories.ImagePath)
            {
                case "quiz_food.jpg":
                    PhotoCollection.Add(new AlbumEntity("Title1", "dotnet_bot.svg", "Content Detail"));
                  
                    break;
                case "quiz_yesno.jpg":
                    PhotoCollection.Add(new AlbumEntity("Title2", "dotnet_bot.svg", "Content Detail"));
                   
                    break;
                case "quiz_worldcup.jpg":
                    PhotoCollection.Add(new AlbumEntity("Title3", "dotnet_bot.svg", "Content Detail"));
                    
                    break;

                default:
                    break;
            }
        }

        public async void PlaySound()
        {
            this.audioManager = new AudioManager();
            audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("camera_sound.mp3"));
            audioPlayer.Play();
        }


    }
}
