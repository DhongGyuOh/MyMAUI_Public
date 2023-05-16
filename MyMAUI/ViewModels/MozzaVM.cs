using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMAUI.Models;
using MyMAUI.Services;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Plugin.Maui.Audio;

namespace MyMAUI.ViewModels
{
    [QueryProperty(nameof(albumCategories), "albumCategories")]
    class MozzaVM : Notify
    {
        public IAudioManager audioManager { get; set; }
        public IAudioPlayer audioPlayer { get; set; }  
        public ObservableCollection<AlbumEntity> _Mozza = new ObservableCollection<AlbumEntity>();
        public ObservableCollection<AlbumEntity> Mozza
        {
            get => _Mozza;
            set
            {
                if (_Mozza != value)
                {
                    _Mozza = value;
                    OnPropertyChanged("Mozza");
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
                    AddMozza();
                }
            }
        }
        public ICommand cmd_MozzaDetail { get; set; }
        public MozzaVM()
        {
            PlaySound();
            cmd_MozzaDetail = new Command(async(obj) =>
            {
                AlbumEntity mozzas = (AlbumEntity)obj;
                await Shell.Current.GoToAsync($"//App/MozzaPage/MozzaDetailPage?mozza={mozzas}", true, new Dictionary<string, object>
                {
                    {"mozzas",mozzas }
                });
            });
        }

        public void AddMozza()
        {
            switch (albumCategories.ImagePath)
            {
                case "quiz_balance.jpg":
                    Mozza.Add(new AlbumEntity("Title1", "dotnet_bot.svg", "Content Detail"));
                    Mozza.Add(new AlbumEntity("Title2", "dotnet_bot.svg", "Content Detail"));
                    Mozza.Add(new AlbumEntity("Title3", "dotnet_bot.svg", "Content Detail"));
                    Mozza.Add(new AlbumEntity("Title4", "dotnet_bot.svg", "Content Detail"));

                    break;
                case "quiz_blank.jpg":
                    Mozza.Add(new AlbumEntity("Title1", "dotnet_bot.svg", "Content Detail"));
                    Mozza.Add(new AlbumEntity("Title2", "dotnet_bot.svg", "Content Detail"));
                    Mozza.Add(new AlbumEntity("Title3", "dotnet_bot.svg", "Content Detail"));
                    Mozza.Add(new AlbumEntity("Title4", "dotnet_bot.svg", "Content Detail"));

                    break;

                default:
                    break;
            }
        }

        public async void PlaySound()
        {
            this.audioManager = new AudioManager();
            audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("cat_sound.mp3"));
            await Task.Delay(1200);
            audioPlayer.Play();
            

        }
       
    }


}
