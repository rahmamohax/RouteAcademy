using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }
        public Subject(int subjectId, string subjectName, Exam exam)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
            Exam = exam;
        }

        public void CreateExam(PracticalExam exam)
        {
            if (exam == null) return;

            Console.WriteLine("");
            int input, noQues;
            do
            {
                Console.Write("Enter Exam Time (30 min - 180 min): ");
            }
            while (!int.TryParse(Console.ReadLine(), out input) || input < 30 || input > 180);
            exam.Time = input;

            do
            {
                Console.Write("Enter Number of Questions: ");
            }
            while (!int.TryParse(Console.ReadLine(), out noQues) || noQues <= 0);
            exam.NoOfQuestions = noQues;
            exam.Questions = new Question[noQues];

            for (int i = 0; i < noQues; i++) {
                string body;
                int mark;
                Console.WriteLine("");
                do
                {
                    Console.Write($"Type Down Question {i+1}: ");
                    body = Console.ReadLine();
                }
                while (string.IsNullOrWhiteSpace(body));

                do
                {
                    Console.Write("Enter mark for this question: ");
                }
                while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0);

                Answer[] answers = new Answer[3];
                string ans;
                Console.WriteLine("Choices for Question");
                for (int j =0; j<3; j++)
                {
                    do
                    {
                        Console.Write($"Write Answer {j+1}: ");
                         ans = Console.ReadLine(); 
                    } while (string.IsNullOrWhiteSpace(ans));

                    answers[j] = new Answer(j + 1, ans);
                }
                int key;
                do
                {
                    Console.Write("Input Right Answer's ID: "); 
                } while (!int.TryParse(Console.ReadLine(), out key) || key <=0 || key >3);

                exam.Questions[i] = new MCQ(
                    "MCQ Question",
                    body,
                    mark,
                    answers,
                    (Answer)answers[key - 1].Clone()
                );
            }
        }
        public void CreateExam(FinalExam exam)
        {
            if (exam == null) return;
            Console.WriteLine("");
            int input, noQues;
            do
            {
                Console.Write("Enter Exam Time (30 min - 180 min) ");
            }
            while (!int.TryParse(Console.ReadLine(), out input) || input < 30 || input > 180);
            exam.Time = input;

            do
            {
                Console.Write("Enter Number of Questions: ");
            }
            while (!int.TryParse(Console.ReadLine(), out noQues) || noQues <= 0);
            exam.NoOfQuestions = noQues;
            exam.Questions = new Question[noQues];

            for (int i = 0; i < noQues; i++)
            {
                Console.WriteLine($"Choose Question Type for Question {i + 1}:");
                Console.WriteLine("1. True/False");
                Console.WriteLine("2. MCQ");

                int qType;
                do
                {
                    Console.Write("Enter choice (1 or 2): ");
                }
                while (!int.TryParse(Console.ReadLine(), out qType) || (qType != 1 && qType != 2));

                string body;
                int mark;
                Console.WriteLine("");
                do
                {
                    Console.Write($"Type Down Question {i + 1}: ");
                    body = Console.ReadLine();
                }
                while (string.IsNullOrWhiteSpace(body));

                do
                {
                    Console.Write("Enter mark for this question: ");
                }
                while (!int.TryParse(Console.ReadLine(), out mark) || mark <= 0);

                if (qType == 1)
                {
                    int key;
                    do
                    {
                        Console.Write("Correct Answer (1 for True, 2 for False): ");
                    }
                    while (!int.TryParse(Console.ReadLine(), out key) || key < 1 || key > 2);

                    exam.Questions[i] = new TrueFalseQ(
                        body,
                        mark,
                        new Answer(key, key == 1 ? "True" : "False")
                    );
                }
                else 
                {
                    Answer[] answers = new Answer[3];
                    string ans;

                    Console.WriteLine("Choices for Question");
                    for (int j = 0; j < 3; j++)
                    {
                        do
                        {
                            Console.Write($"Write Answer {j + 1}: ");
                            ans = Console.ReadLine();
                        }
                        while (string.IsNullOrWhiteSpace(ans));

                        answers[j] = new Answer(j + 1, ans);
                    }

                    int key;
                    do
                    {
                        Console.Write("Input Correct Answer ID (1-3): ");
                    }
                    while (!int.TryParse(Console.ReadLine(), out key) || key < 1 || key > 3);

                    exam.Questions[i] = new MCQ(
                        "MCQ Question",
                        body,
                        mark,
                        answers,
                        (Answer)answers[key - 1].Clone()
                    );
                }
            }
        }

    }
}
