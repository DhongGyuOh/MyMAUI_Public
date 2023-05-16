using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMAUI.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using static MyMAUI.Models.QuizEntity;
using SkiaSharp.Extended.UI.Controls;
using Plugin.Maui.Audio;

namespace MyMAUI.ViewModels
{
    class PriorityQuizVM : Notify
    {
        public IAudioManager audioManager { get; set; }
        public IAudioPlayer audioPlayer { get; set; }
        public ICommand cmd_pick { get; set; }
        public ICommand cmd_Select { get; set; }
        public ICommand cmd { get; set; }
        int RandomNumA;
        int RandomNumB;
        public PriorityQuiz _priorityA { get; set; }
        public PriorityQuiz priorityA
        {
            get => _priorityA;
            set
            {
                if(_priorityA != value)
                {
                    _priorityA = value;
                    OnPropertyChanged("priorityA");
                }
            }
        }
        public PriorityQuiz _priorityB { get; set; }
        public PriorityQuiz priorityB
        {
            get => _priorityB;
            set
            {
                if (_priorityB != value)
                {
                    _priorityB = value;
                    OnPropertyChanged("priorityB");
                }
            }
        }
        public ObservableCollection<PriorityQuiz> _priorityQuiz = new ObservableCollection<PriorityQuiz>();
        public ObservableCollection<PriorityQuiz> priorityQuiz
        {
            get => _priorityQuiz;
            set
            {
                if(_priorityQuiz != value)
                {
                    _priorityQuiz = value;
                    OnPropertyChanged("priorityQuiz");
                }
            }
        }
        public PriorityQuizVM()
        {
            AddPriorityQuiz();
            SetPriorityQuiz();
            this.audioManager = new AudioManager();

            cmd_Select = new Command<PrioritySkia>(async(obj) =>
            {
                audioPlayer.Stop();

                PriorityQuiz priority = obj.Priority;
                SKLottieView sKLottie = obj.Skia;
                ImageButton imgBtn = obj.ImgBtn;
                imgBtn.ZIndex = 2;
                await imgBtn.RotateTo(360);
                await imgBtn.ScaleTo(3);
                await sKLottie.ScaleTo(3);
                sKLottie.IsAnimationEnabled = true;
                await Task.Delay(1650);
                sKLottie.IsAnimationEnabled = false;
                await imgBtn.ScaleTo(0);
                await imgBtn.ScaleTo(1);
                await imgBtn.RotateTo(0);
                imgBtn.ZIndex = 1;
                PriorityQuiz priority_other = priority == priorityA ? priorityB : priorityA;
                if(priority.Priority < priority_other.Priority)
                {
                    audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("correct_harp.MP3"));
                    audioPlayer.Play();
                    priorityQuiz.Remove(priority_other);
                    SetPriorityQuiz();
                }
                else
                {
                    audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("fail_tiyong.MP3"));
                    audioPlayer.Play();
                    Shell.Current.SendBackButtonPressed();
                    await App.Current.MainPage.DisplayAlert("오답입니다.", "처음부터 다시 풀어주세요.","확인");
                }

                if(priorityQuiz.Count == 1)
                {
                    audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("correct_string.MP3"));
                    audioPlayer.Play();
                    await Task.Delay(1200);
                    Shell.Current.SendBackButtonPressed();
                    await App.Current.MainPage.DisplayAlert("정답입니다.", "보상으로 [Pizza] 를 얻었습니다.", "확인");
                    await SecureStorage.SetAsync("Pizza", "1");
                    await Shell.Current.GoToAsync("//App/RewardPage");
                }

            });


        }

        public void AddPriorityQuiz()
        {
            priorityQuiz.Add(new PriorityQuiz("(1)건강", "dotnet_bot.svg", 1));
            priorityQuiz.Add(new PriorityQuiz("(2)64 Telecaster", "dotnet_bot.svg", 2));
            priorityQuiz.Add(new PriorityQuiz("(3)MPC Live 2", "dotnet_bot.svg", 3));
            priorityQuiz.Add(new PriorityQuiz("(4)12 Jazz Bass", "dotnet_bot.svg", 4));
            priorityQuiz.Add(new PriorityQuiz("(5)Acoustic Guitar", "dotnet_bot.svg", 5));
            priorityQuiz.Add(new PriorityQuiz("(6)유튜브", "dotnet_bot.svg", 6));
            priorityQuiz.Add(new PriorityQuiz("(7)릴스 쇼츠", "dotnet_bot.svg", 7));
            priorityQuiz.Add(new PriorityQuiz("(8)회사", "dotnet_bot.svg", 8));
        }

        public async void SetPriorityQuiz()
        {
            this.audioManager = new AudioManager();
            audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("sound_pop.mp3"));
            audioPlayer.Play();
            if (priorityQuiz.Count == 1) return;
            Random random = new Random();
            do
            {
                RandomNumA = random.Next(0,priorityQuiz.Count);
                RandomNumB = random.Next(0,priorityQuiz.Count);
            } while (RandomNumA == RandomNumB); //난수끼리 같다면 다시 난수발생 시키기
            
            priorityA = priorityQuiz[RandomNumA];
            priorityB = priorityQuiz[RandomNumB];
        }


    }
}
