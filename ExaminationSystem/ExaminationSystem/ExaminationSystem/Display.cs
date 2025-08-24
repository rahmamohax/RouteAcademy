using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal static class Display
    {
        internal static void FinalExam(FinalExam exam, Answer[] user, int obtained, int total)
        {
            for (int i = 0; i < exam.NoOfQuestions; i++) {
                Console.WriteLine("");
                Console.WriteLine($"Question {i+1}: {exam.Questions[i].Body}");
                Console.WriteLine($"Your Answer: {user[i].AnswerText}");
                Console.WriteLine($"Right Answer: {exam.Questions[i].RightAnswer.AnswerText}");
            }
            Console.WriteLine($"Exam Finished. Your Grade: {obtained}/{total}");

        }
    }
}
