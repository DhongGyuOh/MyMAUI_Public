using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using static MyMAUI.Models.Plans;
using Plugin.Maui.Audio;
using MyMAUI.Models;
using MyMAUI.Services;

namespace MyMAUI.ViewModels
{
    class PlanVM : Notify
    {
        
        public ICommand cmd_Share => new Command<string>(p=>SharePlan(p));
        public ICommand cmd_ChangeItem {get;set;}
        public IAudioManager audioManager { get; set; }
        public IAudioPlayer audioPlayer { get; set; }
        public ObservableCollection<Plans> _plans = new ObservableCollection<Plans>();
        public ObservableCollection<Plans> plans
        {
            get=> _plans;
            set
            {
                if(_plans != value)
                {
                    _plans = value;
                    OnPropertyChanged($"{nameof(plans)}");
                }
            }
        }
        public ObservableCollection<PlanItem> _planItems = new ObservableCollection<PlanItem>();
        public ObservableCollection<PlanItem> planItems
        {
            get => _planItems;
            set
            {
                if(_planItems != value)
                {
                    _planItems = value;
                    OnPropertyChanged($"{nameof(planItems)}");
                }
            }
        }
        public string _SelectedItem { get; set; }
        public string SelectedItem
        {
            get=> _SelectedItem;
            set
            {
                if(_SelectedItem != value)
                {
                    _SelectedItem = value;
                    OnPropertyChanged($"{nameof(SelectedItem)}");
                }
            }
        }
        public PlanVM()
        {
            AddPlan();
            PlaySound();

            cmd_ChangeItem = new Command((plans) =>
            {
                Plans plan = (Plans)plans;
                SetPlanItem(plan);

            });

        }

        

        public void AddPlan()
        {
            plans.Add(new Plans("첫번째", "첫번째 Title"));
            plans.Add(new Plans("두번째", "두번째 Title"));
            plans.Add(new Plans("세번째", "세번째 Title"));
            plans.Add(new Plans("네번째", "네번째 Title"));
            
        }

        public void SetPlanItem(Plans plan)
        {
            planItems.Clear();
            if (plan == null) return;
            switch (plan.Title)
            {
                case "첫번째":
                    planItems.Add(new PlanItem("Type1", "Title1", "dotnet_bot.svg", "Content Detail1"));
                    planItems.Add(new PlanItem("Type2", "Title2", "dotnet_bot.svg", "Content Detail2"));
                    planItems.Add(new PlanItem("Type3", "Title3", "dotnet_bot.svg", "Content Detail3"));
                    planItems.Add(new PlanItem("Type4", "Title4", "dotnet_bot.svg", "Content Detail4"));
                    planItems.Add(new PlanItem("Type5", "Title5", "dotnet_bot.svg", "Content Detail5"));

                    break;
                case "두번째":
                    planItems.Add(new PlanItem("Type1", "Title1", "dotnet_bot.svg", "Content Detail1"));
                    planItems.Add(new PlanItem("Type2", "Title2", "dotnet_bot.svg", "Content Detail2"));
                    planItems.Add(new PlanItem("Type3", "Title3", "dotnet_bot.svg", "Content Detail3"));
                    planItems.Add(new PlanItem("Type4", "Title4", "dotnet_bot.svg", "Content Detail4"));
                    planItems.Add(new PlanItem("Type5", "Title5", "dotnet_bot.svg", "Content Detail5"));

                    break;
                case "세번째":
                    planItems.Add(new PlanItem("Type1", "Title1", "dotnet_bot.svg", "Content Detail1"));
                    planItems.Add(new PlanItem("Type2", "Title2", "dotnet_bot.svg", "Content Detail2"));
                    planItems.Add(new PlanItem("Type3", "Title3", "dotnet_bot.svg", "Content Detail3"));
                    planItems.Add(new PlanItem("Type4", "Title4", "dotnet_bot.svg", "Content Detail4"));
                    planItems.Add(new PlanItem("Type5", "Title5", "dotnet_bot.svg", "Content Detail5"));

                    break;
                case "네번째":
                    planItems.Add(new PlanItem("Type1", "Title1", "dotnet_bot.svg", "Content Detail1"));
                    planItems.Add(new PlanItem("Type2", "Title2", "dotnet_bot.svg", "Content Detail2"));
                    planItems.Add(new PlanItem("Type3", "Title3", "dotnet_bot.svg", "Content Detail3"));
                    planItems.Add(new PlanItem("Type4", "Title4", "dotnet_bot.svg", "Content Detail4"));
                    planItems.Add(new PlanItem("Type5", "Title5", "dotnet_bot.svg", "Content Detail5"));

                    break;




            }
        }

        public async void PlaySound()
        {
            this.audioManager = new AudioManager();
            audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("fly_sound.mp3"));
            audioPlayer.Play();

        }

        public async void SharePlan(string Title)
        {
            await Share.Default.RequestAsync(new ShareTextRequest(Title + " 계획은 어떠신가요?"));    //Text 공유하기
        }
    }
}
