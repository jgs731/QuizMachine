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
            qaBank.storeQuestionAndAnswers(response);
        }
    }
}