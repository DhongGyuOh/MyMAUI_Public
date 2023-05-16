using SkiaSharp.Extended.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMAUI.Models
{
    class QuizEntity
    {
        public class QnAQuiz
        {
            public string QName { get; set; }
            public string Question { get; set; }
            public string Answer { get; set; }

            public QnAQuiz(string _QName, string _Question, string _Answer)
            {
                QName = _QName;
                Question = _Question;
                Answer = _Answer;
            }

        }
        public class Category
        {
            public string CName { get; set; }
            public string CPath { get; set; }
            public string CText { get; set; }
            public Category(string _CName, string _CPath, string _CText)
            {
                CName = _CName;
                CPath = _CPath;
                CText = _CText;
            }
        }

        public class FoodQuiz
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public string Path { get; set; }
            public string Detail { get; set; }
            public FoodQuiz(string _Name, int _Price, string _Path, string _Detail)
            {
                Name = _Name;
                Path = _Path;
                Price = _Price;
                Detail = _Detail;
            }
        }

        public class PriorityQuiz
        {
            public string Name { get; set; }
            public string Path { get; set; }
            public int Priority { get; set; }
            public PriorityQuiz(string _Name, string _Path, int _Priority)
            {
                Name = _Name;
                Path = _Path;
                Priority = _Priority;
            }

        }

        public class Reward
        {
            public string RType { get; set; }
            public string RPath { get; set; }
            public Reward(string _RType, string _RPath)
            {
                RType = _RType;
                RPath = _RPath;
            }
        }
        public class PrioritySkia
        {
            public SKLottieView Skia { get; set; }
            public PriorityQuiz Priority { get; set; }
            public ImageButton ImgBtn { get; set; }

            public PrioritySkia(PriorityQuiz _Priority, SKLottieView _Skia, ImageButton _ImgBtn)
            {
                this.Priority = _Priority;
                this.Skia = _Skia;
                this.ImgBtn = _ImgBtn;
            }
        }
        public class BalanceQuiz
        {
            public string OptionA { get; set; }
            public string OptionB { get; set; }
            public bool SelectedOption { get; set; }    //true면 A false면 B
            public BalanceQuiz(string _OptionA, string _OptionB, bool _SelectedOption)
            {
                this.OptionA = _OptionA;
                OptionB = _OptionB;
                SelectedOption = _SelectedOption;
            }
        }

        public class YesNoQuiz
        {
            public string Question { get; set; }
            public string AnswerA { get; set; }
            public string AnswerB { get; set; }
            public bool Result { get; set; }

            public YesNoQuiz(string _Question, string _AnswerA, string _AnswerB, bool _Result)
            {
                Question = _Question;
                AnswerA = _AnswerA;
                AnswerB = _AnswerB;
                this.Result = _Result;
            }
        }

        public class BlankQuiz
        {
            public string Question { get; set; }
            public string Answer1 { get; set; }
            public string Answer2 { get; set; }
            public string Answer3 { get; set; }
            public string Answer4 { get; set; }
            public string Answer5 { get; set; }
            public string CorrectAnswer { get; set; }
            public BlankQuiz(string _Question, string _Answer1, string _Answer2, string _Answer3, string _Answer4, string _Answer5, string _CorrectAnswer)
            {
                Question = _Question;
                Answer1 = _Answer1;
                Answer2 = _Answer2;
                Answer3 = _Answer3;
                Answer4 = _Answer4;
                Answer5 = _Answer5;
                CorrectAnswer = _CorrectAnswer;
            }
        }


    }

}
