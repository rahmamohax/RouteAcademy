namespace ExaminationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============== Examination System ==============");
            int subID;
            string subName;

            do
            {
                Console.Write("Enter Subject ID: ");
            }
            while (!int.TryParse(Console.ReadLine(), out subID) || subID <0);

            do
            {
                Console.Write("Enter Subject Name: ");
                subName = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(subName));

            Console.WriteLine("\nChoose Exam Type:");
            Console.WriteLine("1. Practical Exam (MCQ only)");
            Console.WriteLine("2. Final Exam (True/False + MCQ)");

            int examType;
            do
            {
                Console.Write("Enter choice (1 or 2): ");
            }
            while (!int.TryParse(Console.ReadLine(), out examType) || (examType != 1 && examType != 2));

            Exam exam;
            Subject subject;

            if (examType == 1) {
                exam = new PracticalExam();
                subject= new Subject(subID, subName, exam);
                subject.CreateExam((PracticalExam) exam); 
            }

            else
            {
                exam = new FinalExam();
                subject = new Subject(subID, subName, exam);
                subject.CreateExam((FinalExam)exam);
            }

            char input;
            do
            {
                Console.Write("Do You Want To Show Exam? (y/n) "); 
                
            } while (!char.TryParse(Console.ReadLine(), out input) || !( input == 'y' || input == 'Y'
                                                     || input == 'N' || input == 'n')); 

            if (input == 'y' || input == 'Y')
            {
                
                Console.WriteLine($"\n===== Starting {subject.SubjectName} Exam =====\n");
                Console.WriteLine($"Time Allowed: {exam.Time} minutes");
                Console.WriteLine($"Number of Questions: {exam.NoOfQuestions}\n");
                
                exam.ShowExam();

                Console.WriteLine("\n===== Exam Finished =====");
                
            }
            else
            {
                Console.WriteLine("\nExam saved for later. You can take it any time.");
            }
        }
    }
}