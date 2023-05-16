using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMAUI.Services; 
using System.Threading.Tasks;
using static MyMAUI.Models.QuizEntity;
using Plugin.Maui.Audio;

namespace MyMAUI.ViewModels
{
    [QueryProperty(nameof(reward), "reward")]
    class RewardDetailVM : Notify
    {
        public IAudioManager audioManager { get; set; }
        public IAudioPlayer audioPlayer { get; set; }

        public Reward _reward { get; set; }
        public Reward reward
        {
            get => _reward;
            set
            {
                if (_reward != value)
                {
                    _reward = value;
                    OnPropertyChanged("reward");
                }
            }
        }

        public RewardDetailVM()
        {
            PlaySound();
        }

        public async void PlaySound()
        {
            this.audioManager = new AudioManager();
            audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("reward_sound2.mp3"));
            audioPlayer.Play();
        }
        
    }
}
