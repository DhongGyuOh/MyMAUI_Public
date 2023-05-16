using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MyMAUI.Models;
using MyMAUI.Services;
using static MyMAUI.Models.QuizEntity;
using Microsoft.Maui.Media;
using System.Diagnostics;
using Plugin.Maui.Audio;

namespace MyMAUI.ViewModels
{
    class QnAVM : Notify
    {
        public IAudioManager audioManager { get; set; }
        public IAudioPlayer audioPlayer { get; set; }
        public QnAQuiz _QnA { get; set; }
        public QnAQuiz QnA
        {
            get=> _QnA;
            set
            {
                if(_QnA != value)
                {
                    _QnA = value;
                    OnPropertyChanged("QnA");
                }
            }
        }

        public ObservableCollection<QnAQuiz> _QnAQuizzes = new ObservableCollection<QnAQuiz>();
        public ObservableCollection<QnAQuiz> QnAQuizzes
        {
            get => _QnAQuizzes;
            set
            {
                if(_QnAQuizzes != value)
                {
                    _QnAQuizzes = value;
                    OnPropertyChanged("QnAQuizzes");
                }
            }
        }
        private Stopwatch stopwatch = new Stopwatch();
        private string _InTime { get; set; }
        public string InTime
        {
            get => _InTime;
            set
            {
                if(_InTime != value)
                {
                    _InTime = value;
                    OnPropertyChanged("InTime");
                    if(InTime == "1 분  0 초")
                    {
                        Shell.Current.SendBackButtonPressed();
                        Shell.Current.DisplayAlert("실패", "제한시간 내에 풀지 못했습니다.", "확인");
                        stopwatch.Reset();
                        stopwatch.Stop();
                    }
                }
            }
        }
        
        public ICommand cmd_submit { get; set; }
        
        
        public QnAVM()
        {
            stopwatch.Start();
            Device.StartTimer(TimeSpan.FromSeconds(1),() =>
            {
                InTime = stopwatch.Elapsed.Minutes.ToString() + " 분  " + stopwatch.Elapsed.Seconds.ToString() +" 초";
                if(Shell.Current.CurrentPage.ToString() != "MyMAUI.Views.QnAPage")
                {
                    stopwatch.Reset();
                    stopwatch.Stop();
                    
                }
                return true;
            });

            AddQnAQuiz();
            SetQnAQuiz();
            this.audioManager = new AudioManager();

            cmd_submit = new Command(async(obj) =>
            {
                audioPlayer.Stop();
                Entry entry = (Entry)obj;
                if (entry.Text == QnA.Answer)
                {
                    stopwatch.Stop();
                    await Shell.Current.DisplayAlert("정답", QnA.QName, "확인");
                    QnAQuizzes.Remove(QnA);
                    entry.Text = "";

                    if (QnAQuizzes.Count == 0)
                    {
                        audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("correct_harp.MP3"));
                        audioPlayer.Play();
                        await Task.Delay(1200);

                        Shell.Current.SendBackButtonPressed();
                        await App.Current.MainPage.DisplayAlert("정답입니다.", "보상으로 [BingSu] 를 얻었습니다.", "확인");
                        await SecureStorage.SetAsync("BingSu", "1");
                        await Shell.Current.GoToAsync("//App/RewardPage");
                        return;
                    }
                    audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("correct_string.MP3"));
                    audioPlayer.Play();
                    await Task.Delay(1200);

                    stopwatch.Restart();
                    SetQnAQuiz();
                }
                else
                {
                    audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("fail_tiyong.MP3"));
                    audioPlayer.Play();
                }
                
            });
            
        }

        

        public void AddQnAQuiz()
        {
            QnAQuizzes.Add(new QnAQuiz("정답 해설 팝업", "문제 내용입니다.", "정답"));
            QnAQuizzes.Add(new QnAQuiz("정답 해설 팝업", "문제 내용입니다.", "정답"));
            QnAQuizzes.Add(new QnAQuiz("정답 해설 팝업", "문제 내용입니다.", "정답"));
            QnAQuizzes.Add(new QnAQuiz("정답 해설 팝업", "문제 내용입니다.", "정답"));
            QnAQuizzes.Add(new QnAQuiz("정답 해설 팝업", "문제 내용입니다.", "정답"));
            QnAQuizzes.Add(new QnAQuiz("정답 해설 팝업", "문제 내용입니다.", "정답"));
        }

        public async void SetQnAQuiz()
        {
            this.audioManager = new AudioManager();
            Random random = new Random();
            int R_Num = random.Next(0, QnAQuizzes.Count);
            QnA = QnAQuizzes[R_Num];
            audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("tiktok.mp3"));
            audioPlayer.Play();
        }

    }
}
