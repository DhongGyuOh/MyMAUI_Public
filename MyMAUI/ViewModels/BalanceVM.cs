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
    class BalanceVM : Notify
    {
        public IAudioManager audioManager { get; set; }
        public IAudioPlayer audioPlayer { get; set; }
        public int _count { get; set; }
        public int count
        {
            get=>_count;
            set
            {
                if (_count != value)
                {
                    _count = value;
                    OnPropertyChanged("count");
                }
            }
        }
        public BalanceQuiz _balanceQuiz { get; set; }
        public BalanceQuiz balanceQuiz
        {
            get => _balanceQuiz;
            set
            {
                if(_balanceQuiz != value)
                {
                    _balanceQuiz = value;
                    OnPropertyChanged("balanceQuiz");
                }
            }
        }
        public ObservableCollection<BalanceQuiz> _BalanceCollection = new ObservableCollection<BalanceQuiz>();
        public ObservableCollection<BalanceQuiz> BalanceCollection
        {
            get => _BalanceCollection;
            set
            {
                if(_BalanceCollection != value)
                {
                    _BalanceCollection = value;
                    OnPropertyChanged("BalanceCollection");
                }
            }
        }
        public ICommand cmd_Select { get; set; }

        public BalanceVM()
        {
            count = 5;
            AddBalance();
            SetBalance();
            this.audioManager = new AudioManager();

            cmd_Select = new Command(async (obj) =>
            {
                audioPlayer.Stop();
                Button btn = (Button)obj;
                string balancePick = balanceQuiz.SelectedOption ? balanceQuiz.OptionA : balanceQuiz.OptionB;
                if (btn.Text == balancePick)
                {
                    if (BalanceCollection.Count == 1)
                    {
                        audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("correct_string.MP3"));
                        audioPlayer.Play();
                        await Task.Delay(1200);
                        await Shell.Current.DisplayAlert("정답입니다.", "보상으로  [coffee]를 얻었습니다.!", "확인");
                        await SecureStorage.SetAsync("coffee", "1");
                        Shell.Current.SendBackButtonPressed();
                        await Shell.Current.GoToAsync("//App/RewardPage");
                        return;

                    }

                    audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("correct_bell.MP3"));
                    audioPlayer.Play();
                    await Task.Delay(1200);

                    BalanceCollection.Remove(balanceQuiz);
                    SetBalance();
                }
                else
                {
                    count--;
                    if (count == 0)
                    {
                        audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("fail_tiyong.MP3"));
                        audioPlayer.Play();
                        await Task.Delay(1200);
                        Shell.Current.SendBackButtonPressed();
                        await Shell.Current.DisplayAlert("실패", "기회를 모두 사용하였습니다.", "확인");

                    }
                    audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("fail_tiyong2.MP3"));
                    audioPlayer.Play();
                }

            });

        }

     


        public void AddBalance()
        {
            BalanceCollection.Add(new BalanceQuiz("여름", "겨울", false));
            BalanceCollection.Add(new BalanceQuiz("유니짜장", "차돌짬뽕", false));
            BalanceCollection.Add(new BalanceQuiz("부먹", "찍먹", false));
            BalanceCollection.Add(new BalanceQuiz("시골", "도시", false));
            BalanceCollection.Add(new BalanceQuiz("고양이", "강아지", true));
            BalanceCollection.Add(new BalanceQuiz("항상 나보다 일찍 자서 코 시끄럽게 고는 룸메", "일주일에 한 번만 씻는 룸메", true));
            BalanceCollection.Add(new BalanceQuiz("바다 놀러갔는데 건물 안에만 있으려는 친구", "바다 놀러 갔는데 해산물 먹기 싫다는 친구", false));
            BalanceCollection.Add(new BalanceQuiz("요구르트에 김치 말아먹기", "라면에 초콜릿 넣기", false));
            BalanceCollection.Add(new BalanceQuiz("평생 탄산 안 마시기", "평생 라면 못 먹기", true));
            BalanceCollection.Add(new BalanceQuiz("독심술 초능력이 생겼는데 내 의지와 상관없이 모든 사람 생각 읽기", "거짓말하면 죽는 병 걸리기", true));
            BalanceCollection.Add(new BalanceQuiz("약속해서 만났는데 핸드폰만 보는 사람", "약속은 항상 먼저 잡으면서 돈은 절대 안 내는 사람", false));
            BalanceCollection.Add(new BalanceQuiz("로또 당첨되면 애인에게 바로 말한다", "로또 당첨되면 애인에게 숨긴다", true));
            BalanceCollection.Add(new BalanceQuiz("월 200만 원 백수 되기(일 하면 절대 안 됨)", "월 600만 원 직장인(정년까지 일 못 그만둠)", true));
            BalanceCollection.Add(new BalanceQuiz("내가 좋아하는 사람이 날 싫어하게 되기", "나를 싫어하던 사람이 목숨 걸 만큼 날 좋아하게 되기", true));
            BalanceCollection.Add(new BalanceQuiz("반반의 확률로 10억 받기", "그냥 5000만 원 받기", true));
            BalanceCollection.Add(new BalanceQuiz("똥 안 먹었는데 먹었다고 소문나기(전 세계 사람들이 다 알고 있음)", "진짜로 먹었는데 아무도 모르기", false));
            BalanceCollection.Add(new BalanceQuiz("새 신발인데 물웅덩이에 빠지고 1시간 이상 돌아다니기", "양말 젖어서 1시간 이상 돌아다니는데 발 냄새 심하게 나기", true));
            BalanceCollection.Add(new BalanceQuiz("1년 동안 폰 없이 살기", "1년동안 친구 없기", true));
            BalanceCollection.Add(new BalanceQuiz("항상 불 환하게 키고 자는 룸메(불 끄면 일어나서 다시 끔)", "밤마다 몰래 타자기 두드리는 룸메(시끄럽지는 않은데 거슬림)", false));
            BalanceCollection.Add(new BalanceQuiz("평생 노래 못 듣기", "한국 제외한 모든 나라 여행 못 가기", false));
            BalanceCollection.Add(new BalanceQuiz("자는데 모기소리 들리기(물리지는 않음) ", "소리는 없는데 모기에 물리기", false));
            

        }

        public async void SetBalance()
        {
            this.audioManager = new AudioManager();
            Random random = new Random();
            int RNum = random.Next(0,BalanceCollection.Count);
            balanceQuiz = BalanceCollection[RNum];
            audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("sound_pop.mp3"));
            audioPlayer.Play();
        }
    }
}
