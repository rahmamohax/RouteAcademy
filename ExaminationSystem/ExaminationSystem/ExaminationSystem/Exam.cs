using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal abstract class Exam
    {

        public int Time { get; set; }
        public int NoOfQuestions { get; set; }
        public  Question[] Questions { get; set; }

        protected Exam()
        {
            
        }

        protected Exam(int time, int noOfQuestions, Question[] question)
        {
            Time = time;
            NoOfQuestions = noOfQuestions;
            Questions = question;
        }
        public abstract void ShowExam();

    }

    internal class PracticalExam : Exam
    {
        public PracticalExam() : base()
        {
        }
        public PracticalExam(int time, int noOfQuestions, Question[] question) : base(time, noOfQuestions, question)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine("========== Practical Exam ===========");
            foreach (Question question in Questions)
            {

                Console.WriteLine("");
                question.ShowQuestion();

                int ans;
                do
                {
                    Console.Write("Your Answer (Enter ID): ");
                }
                while (!int.TryParse(Console.ReadLine(), out ans) || ans <= 0 || ans > question.AnswerList.Length);

                Console.WriteLine($"Your Answer: {question.AnswerList[ans-1]}");
                Console.WriteLine($"Correct Answer: {question.RightAnswer}\n");

            }
            Console.WriteLine("Exam Finished. Review Answers Above.");
        }
    }

    internal class FinalExam : Exam
    {
        public FinalExam() : base()
        {
        }

        public FinalExam(int time, int noOfQuestions, Question[] question) : base(time, noOfQuestions, question)
        {
        }

        public override void ShowExam()
        {
            Answer[] userAnswers= new Answer[Questions.Length];
            Console.WriteLine("========== Final Exam ===========");
            int TotalMarks = 0, ObtainedMarks = 0, Count = 0;
            foreach (Question question in Questions) {

                Console.WriteLine("");
                question.ShowQuestion();

                int ans;
                do
                {
                    Console.Write("Your Answer (Enter ID): ");
                }
                while (!int.TryParse(Console.ReadLine(), out ans) || ans <= 0 || ans > question.AnswerList.Length);
                if (ans == question.RightAnswer.AnswerId)
                    ObtainedMarks += question.Mark;

                userAnswers[Count++] =(Answer) question.AnswerList[ans -1].Clone();
                TotalMarks += question.Mark;

            }
            Display.FinalExam(this, userAnswers, ObtainedMarks, TotalMarks);
        }

        
    }
}
