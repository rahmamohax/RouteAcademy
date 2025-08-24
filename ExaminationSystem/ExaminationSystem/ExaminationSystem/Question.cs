using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal abstract class Question
    {

        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }

        public  Answer[] AnswerList { get; set; }
        public Answer RightAnswer { get; set; }

        public abstract void ShowQuestion();
        protected Question(string header, string body, int mark, Answer[] answerList, Answer rightAnswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answerList;
            RightAnswer = rightAnswer;
        }
    }

    internal class TrueFalseQ : Question
    {
        public TrueFalseQ(string body, int mark, Answer rightAnswer)
        : base("True/False Question", body, mark,
               new Answer[2] { new Answer(1, "True"), new Answer(2, "False") },
               rightAnswer)
        {
        }

        public override void ShowQuestion()
        {
            Console.WriteLine($"{Header}\t (Mark: {Mark})\n" +
                $"{Body}\n"); 
            foreach (var answer in AnswerList)
                Console.WriteLine($"{answer}");
        }


    }

    internal class MCQ : Question
    {
        public MCQ(string header, string body, int mark, Answer[] answerList, Answer rightAnswer) : base("MCQ Question", body, mark, answerList, rightAnswer)
        {
        }

        public override void ShowQuestion()
        {
            Console.WriteLine($"{Header}\t (Mark: {Mark})\n" +
                $"{Body}\n");
            foreach (var answer in AnswerList)
                Console.WriteLine($"{answer}");
        }
    }
}
