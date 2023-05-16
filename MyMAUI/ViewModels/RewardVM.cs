using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMAUI.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MyMAUI.Views;
using static MyMAUI.Models.QuizEntity;
using SkiaSharp.Extended.UI.Controls;
using Plugin.Maui.Audio;

namespace MyMAUI.ViewModels
{
    class RewardVM : Notify
    {
        public IAudioManager audioManager { get; set; }
        public IAudioPlayer audioPlayer { get; set; }
        public Reward reward { get; set; }
        public ICommand cmd_GoToRewardDetail { get; set; }
        public RewardVM()
        {

            PlaySound();
            cmd_GoToRewardDetail = new Command(async(obj) =>
            {
                string rewardType = (string)obj;
                
                switch (rewardType)
                {
                    case "Icecream":
                        reward = new Reward(rewardType, "dotnet_bot.svg"); //YesNo
                        break;
                    case "BingSu":
                        reward = new Reward(rewardType, "dotnet_bot.svg");  //QnA
                        break;
                    case "Chicken":
                        reward = new Reward(rewardType, "dotnet_bot.svg");  //Food
                        break;
                    case "Pizza":
                        reward = new Reward(rewardType, "dotnet_bot.svg");  //Priority
                        break;
                    case "coffee":
                        reward = new Reward(rewardType, "dotnet_bot.svg"); //balance
                        break;
                    case "burger":
                        reward = new Reward(rewardType, "dotnet_bot.svg"); //모두 풀면
                        break;
                    default:
                        break;
                }

                string str = await SecureStorage.GetAsync(rewardType);
                if(str == null)
                {
                    await Shell.Current.DisplayAlert("미획득", "아직 보상을 얻지 못했습니다.", "확인");
                    return;
                }
                await Shell.Current.GoToAsync($"//App/RewardDetailPage",true,new Dictionary<string, object>
                {
                    {
                        "reward",reward
                    } });
            },
            (obj) =>
            {
                return CheckReward();
            });

        }

        public bool CheckReward()
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        
        public async void PlaySound()
        {
            this.audioManager = new AudioManager();
            audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("reward_sound.mp3"));
            audioPlayer.Play();
        }
     

    }
}
