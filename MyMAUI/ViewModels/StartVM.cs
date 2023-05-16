using MyMAUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyMAUI.Views;
using SkiaSharp.Extended.UI.Controls;
using Plugin.Maui.Audio;

namespace MyMAUI.ViewModels
{
    class StartVM : Notify
    {
        private IAudioManager audioManager;
        private IAudioPlayer audioPlayer;
        public ICommand cmd_Tapping{ get; set; }
        
        public StartVM()
        {
            cmd_Tapping = new Command(async(obj) =>
            {
                this.audioManager = new AudioManager();
                //Sound File을 지정한다 반드시 Raw에 넣을것!
                audioPlayer = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("cat_sound2.wav"));
                audioPlayer.Play();

                SKLottieView skia = (SKLottieView)obj;
                await skia.ScaleTo(0);
                await skia.ScaleTo(2);
                Task task1 = skia.RotateTo(3600,700);
                Task task2 = skia.ScaleTo(0,700);
                Task task3 = Task.Delay(700);
                audioPlayer.Dispose();
                await Task.WhenAll(task1, task2, task3);
                await Shell.Current.GoToAsync("//App/QuizPage");
            });
        }
    }

}
