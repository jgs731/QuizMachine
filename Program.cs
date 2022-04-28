using System;

namespace QuizMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QAndABank qaBank = new QAndABank();
            Console.WriteLine("Enter a question for the bank, with answers separated by | (Mark the correct answer with a '*' at the end)");
            string response = Console.ReadLine();

            SaveQuestionBank(response);
        }

        public static void SaveQuestionBank(string response)
        {
            StreamWriter writer;
            string[] vs = response.Split('|');
            using (writer = new StreamWriter("question_and_answer_bank.txt"))
            {
                foreach (string str in vs)
                {
                    writer.WriteLine(str);
                }
            }
            writer.Close();
        }

        public static String ReadQuestionBank()
        {
            using (StreamReader reader = new StreamReader("question_and_answer_bank.txt"))
            {
                for (int i = 0;  i < reader.ReadToEnd().Length; i++)
                if (reader.ToString().Contains("?"))
                {
                    QAndABank.questions.Add(reader.ToString());
                    continue;
                }
            }
            return ""; // Think I need to return an object here, will reassess in next commit
        }
    }
}