using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyMAUI.Models.QuizEntity;
using MyMAUI.Services;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Plugin.Maui.Audio;

namespace MyMAUI.ViewModels
{
    class YesNoVM : Notify
    {
        public IAudioManager audioManager { get; set; }
        public IAudioPlayer audioPlayer { get; set; }
        public int _count { get; set; }
        public int count
        {
            get=> _count;
            set
            {
                if(_count != value)
                {
                    _count = value;
                    OnPropertyChanged("count");
                }
            }
        }
        public YesNoQuiz _yesNoQuiz { get; set; }
        public YesNoQuiz yesNoQuiz
        {
            get=> _yesNoQuiz;
            set
            {
                if(_yesNoQuiz != value)
                {
                    _yesNoQuiz = value;
                    OnPropertyChanged("yesNoQuiz");
                }
            }
        }
        public ObservableCollection<YesNoQuiz> _YesNoCollection = new ObservableCollection<YesNoQuiz>();
        public ObservableCollection<YesNoQuiz> YesNoCollection
        {
            get => _YesNoCollection;
            set
            {
                if(_YesNoCollection != value)
                {
                    _YesNoCollection = value;
                    OnPropertyChanged("YesNoCollection");
                }
            }
        }
        public ICommand cmd_Select { get; set; }
        public YesNoVM()
        {
            count = 3;
            AddYesNo();
            SetYesNo();
            this.audioManager = new AudioManager();
            
            cmd_Select = new Command(async(obj) =>
            {
                audioPlayer.Stop();
                
                Button btn = (Button)obj;
                if(!((btn.Text == yesNoQuiz.AnswerA) == yesNoQuiz.Result))
                {
                    count--;
                    
                    if (count == 0)
                    {
                        audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("fail_tiyong.MP3"));
                        audioPlayer.Play();
                        await Task.Delay(1200);
                        await Shell.Current.DisplayAlert("실패", "기회를 모두 사용하였습니다. \n 다시 풀어보세요.", "확인");
                        Shell.Current.SendBackButtonPressed();
                    }
                    else
                    {
                        audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("fail_tiyong2.MP3"));
                        audioPlayer.Play();
                        await Task.Delay(1000);
                        return;
                    }
                    
                }
                else
                {
                    if (YesNoCollection.Count == 1)
                    {
                        audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("correct_string.MP3"));
                        audioPlayer.Play();
                        await Task.Delay(1000);
                        Shell.Current.SendBackButtonPressed();
                        await App.Current.MainPage.DisplayAlert("정답입니다.", "보상으로 [Icecream] 를 얻었습니다.", "확인");
                        await SecureStorage.SetAsync("Icecream", "1");
                        await Shell.Current.GoToAsync("//App/RewardPage");
                        return;
                    }
                    else
                    {
                        audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("correct_bell.MP3"));
                        audioPlayer.Play();
                        await Task.Delay(1000);
                        YesNoCollection.Remove(yesNoQuiz);
                        SetYesNo();
                    }
                }

                

            });

        }

        public void AddYesNo()
        {
            YesNoCollection.Add(new YesNoQuiz("첫번째 문제내용입니다. 정답 Yes", "Yes", "No", true));
            YesNoCollection.Add(new YesNoQuiz("두번째 문제내용입니다. 정답 No", "Yes", "No", false));
            YesNoCollection.Add(new YesNoQuiz("세번째 문제내용입니다. 정답 Yes", "Yes", "No", true));
            YesNoCollection.Add(new YesNoQuiz("네번째 문제내용입니다. 정답 No", "Yes", "No", false));
            YesNoCollection.Add(new YesNoQuiz("다섯번째 문제내용입니다. 정답 Yes", "Yes", "No", true));
            YesNoCollection.Add(new YesNoQuiz("여섯번째 문제내용입니다. 정답 No", "Yes", "No", false));
            YesNoCollection.Add(new YesNoQuiz("일곱번째 문제내용입니다. 정답 Yes", "Yes", "No", true));
            


        }
        public async void SetYesNo()
        {
            this.audioManager = new AudioManager();
            Random random = new Random();
            int RNum = random.Next(0,YesNoCollection.Count);
            yesNoQuiz = YesNoCollection[RNum];
            audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("sound_pop.mp3"));
            audioPlayer.Play();
        }
    }
}
