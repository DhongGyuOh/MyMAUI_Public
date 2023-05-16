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
using Plugin.Maui.Audio;

namespace MyMAUI.ViewModels
{
    class QuizVM : Notify
    {
        public IAudioManager audioManager { get; set; }
        public IAudioPlayer audioPlayer { get; set; }
        
        public ObservableCollection<Category> _Categories = new ObservableCollection<Category>();
        public QuizVM()
        {
            AddQuiz();
            PlaySound();
            

            //cmd_GoToQuiz = new Command((para) =>
            //{
            //    string QuizCategory = (string)para;
            //    Shell.Current.GoToAsync("//App/" + QuizCategory + "Page");
            //});
        }

        public void AddQuiz()
        {
            Categories.Add(new Category("FoodQuiz", "quiz_food.jpg", "🍝음식 퀴즈🍲"));
            Categories.Add(new Category("QnA", "quiz_qna.jpg", "🗨주관식 퀴즈💬"));
            Categories.Add(new Category("PriorityQuiz", "quiz_worldcup.jpg", "🥇🥈🥉우선순위 퀴즈🏆"));
            Categories.Add(new Category("Balance", "quiz_balance.jpg", "⚖️밸런스 게임⚖️"));
            Categories.Add(new Category("YesNo", "quiz_yesno.jpg","🙆🏻‍Yes 🤷🏻Or ‍🙅🏻‍No 퀴즈 \n\n"));
            Categories.Add(new Category("BlankQuiz", "quiz_blank.jpg", "🔢객관식 퀴즈🔠"));

        }
        public ICommand cmd_GoToQuiz => new Command<string>(p => GoToQuiz(p));

        private void GoToQuiz(string menu)
        {
            Shell.Current.GoToAsync("//App/" + menu + "Page");
        }


        public ObservableCollection<Category> Categories
        {
            get=> _Categories;
            set
            {
                if(_Categories != value)
                {
                    _Categories = value;
                    OnPropertyChanged("Categories");
                }
            }
        }

        public async void PlaySound()
        {
            this.audioManager = new AudioManager();
            audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("stepbystep.mp3"));
            audioPlayer.Play();
        }
    }
}
