using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MyMAUI.Services;
using static MyMAUI.Models.QuizEntity;
using Plugin.Maui.Audio;

namespace MyMAUI.ViewModels
{
    class BlankVM :Notify
    {
        public IAudioManager audioManager { get; set; }
        public IAudioPlayer audioPlayer { get; set; }
        public int _count { get; set; }
        public int count
        {
            get => _count;
            set
            {
                if(_count != value)
                {
                    _count = value;
                    OnPropertyChanged("count");
                }
            }
        }
        public BlankQuiz _blankQuiz { get; set; }
        public BlankQuiz blankQuiz
        {
            get=> _blankQuiz;
            set
            {
                if(_blankQuiz != value)
                {
                    _blankQuiz = value;
                    OnPropertyChanged("blankQuiz");
                }
            }
        }
        public ObservableCollection<BlankQuiz> _BlankQuizCollection = new ObservableCollection<BlankQuiz>();
        public ObservableCollection<BlankQuiz> BlankQuizCollection
        {
            get=> _BlankQuizCollection;
            set
            {
                if(_BlankQuizCollection != value)
                {
                    _BlankQuizCollection = value;
                    OnPropertyChanged("BlankQuizCollection");
                }
            }
        }
        public ICommand cmd_Select { get; set; }


        public BlankVM()
        {
            count = 3;
            AddBlank();
            SetBlank();
            this.audioManager = new AudioManager();

            cmd_Select = new Command(async(obj) =>
            {
                audioPlayer.Stop();
                Button btn = (Button)obj;
                
                if(!(btn.Text == blankQuiz.CorrectAnswer))
                {
                    count--;
                    if(count == 0)
                    {
                        audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("fail_tiyong.MP3"));
                        audioPlayer.Play();
                        await Task.Delay(1200);
                        await Shell.Current.DisplayAlert("실패", " 기회를 모두 사용하였습니다. \n 처음부터 다시 풀어주세요.", "확인");
                        Shell.Current.SendBackButtonPressed();
                        return;
                    }

                    audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("fail_tiyong2.MP3"));
                    audioPlayer.Play();
                }
                else
                {
                    
                    if (BlankQuizCollection.Count == 1)
                    {
                        audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("correct_harp.MP3"));
                        audioPlayer.Play();
                        await Task.Delay(1200);
                        Shell.Current.SendBackButtonPressed();
                        await App.Current.MainPage.DisplayAlert("정답입니다.", "보상으로 [buger] 를 얻었습니다.", "확인");
                        await SecureStorage.SetAsync("buger", "1");
                        await Shell.Current.GoToAsync("//App/RewardPage");
                        return;
                    }
                    audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("correct_bell.MP3"));
                    audioPlayer.Play();
                    BlankQuizCollection.Remove(blankQuiz);
                    SetBlank();
                }

        

            });

            

        }

        public void AddBlank()
        {
            BlankQuizCollection.Add(new BlankQuiz("Question1","Answer1", "Answer2", "Answer3", "Answer4", "정답", "정답"));
            BlankQuizCollection.Add(new BlankQuiz("Question2", "Answer1", "Answer2", "정답", "Answer4", "Answer5", "정답"));
            BlankQuizCollection.Add(new BlankQuiz("Question3", "정답", "Answer2", "Answer3", "Answer4", "Answer5", "정답"));
            BlankQuizCollection.Add(new BlankQuiz("Question4", "Answer1", "정답", "Answer3", "Answer4", "Answer5", "정답"));
            BlankQuizCollection.Add(new BlankQuiz("Question5", "Answer1", "Answer2", "Answer3", "정답", "Answer5", "정답"));


        }
        public async void SetBlank()
        {
            this.audioManager = new AudioManager();
            Random random = new Random();
            int RNum = random.Next(0, BlankQuizCollection.Count);
            blankQuiz = BlankQuizCollection[RNum];
            audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("sound_pop.mp3"));
            audioPlayer.Play();
        }
    }
}
