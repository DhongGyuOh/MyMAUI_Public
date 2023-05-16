using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMAUI.Services;
using static MyMAUI.Models.QuizEntity;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Microsoft.Maui.Platform;
using Plugin.Maui.Audio;


namespace MyMAUI.ViewModels
{
    class FoodQuizVM : Notify
    {
        public int randomNum;
        public ICommand cmd_NextQuiz { get; set; }
        public ICommand cmd_Completed { get; set; } 
        public IAudioManager audioManager { get; set; }
        public IAudioPlayer audioPlayer { get; set; }
        public FoodQuiz _foodQuiz { get; set; }
        public FoodQuiz foodQuiz
        {
            get=> _foodQuiz;
            set
            {
                if(_foodQuiz != value)
                {
                    _foodQuiz = value;
                    OnPropertyChanged("foodQuiz");
                }
            }
        }

        public ObservableCollection<FoodQuiz> _foods = new ObservableCollection<FoodQuiz>();
        public ObservableCollection<FoodQuiz> foods
        {
            get=> _foods;
            set
            {
                if(_foods != value)
                {
                    _foods = value;
                    OnPropertyChanged("foods");
                }
            }
        }
        public FoodQuizVM()
        {
            AddFood();
            SetQuiz();
            this.audioManager = new AudioManager();
            
          
            cmd_Completed = new Command(async(obj) =>
            {
                audioPlayer.Stop();
                audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("answer_show.wav"));
                audioPlayer.Play();
                await Task.Delay(2000);
                if (foods.Count <= 1)
                {
                    audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("winner.mp3"));
                    audioPlayer.Play();
                    await Shell.Current.DisplayAlert("정답 입니다.", foods[randomNum].Detail, "확인");
                    Shell.Current.SendBackButtonPressed();
                    await App.Current.MainPage.DisplayAlert("정답입니다.", "보상으로 [Chicken] 를 얻었습니다.", "확인");
                    await SecureStorage.SetAsync("Chicken", "1");
                    await Shell.Current.GoToAsync("//App/RewardPage");
                    return;

                }
                Entry entry = (Entry)obj;
                if (foods[randomNum].Price.ToString() == entry.Text)
                {
                    audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("correct_answeris.wav"));
                    audioPlayer.Play();
                    await Shell.Current.DisplayAlert("정답 입니다.", foods[randomNum].Detail, "확인");
                    entry.Text = "";
                    foods.Remove(foodQuiz);
                    await Task.Delay(500);
                    SetQuiz();
                }
                else
                {
                    audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("fail.mp3"));
                    audioPlayer.Play();
                }
                

            });

        }
        public void AddFood()
        {
            foods.Add(new FoodQuiz("Question(1000)", 1000, "quiz_qna","Collect Popup"));
            foods.Add(new FoodQuiz("Question(2000)", 2000, "quiz_blank", "Collect Popup"));
            foods.Add(new FoodQuiz("Question(3000)", 3000, "quiz_worldcup", "Collect Popup"));
            foods.Add(new FoodQuiz("Question(4000)", 4000, "quiz_yesno", "Collect Popup"));
            
        }
        public async void SetQuiz ()
        {
            this.audioManager = new AudioManager ();
            audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("start_question.mp3"));
            audioPlayer.Play();
            if (foods.Count == 0) return;
            Random random = new Random();
            randomNum = random.Next(0,foods.Count);
            foodQuiz = foods[randomNum];
        }
    }
}
