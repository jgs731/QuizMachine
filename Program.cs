using System;

namespace QuizMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a question for the bank, with answers separated by | (Mark the correct answer with a '*' at the end)");
            string response = Console.ReadLine();
            StreamWriter writer;
            string[] response_array = response.Split("|");
            foreach (string str in response_array) {
                using (writer = new StreamWriter("question_and_answer_bank.txt"))
                {
                    writer.WriteLine(str);
                }
                writer.Close();
            }
        }
    }
}