using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMachine
{
    internal class UIMethods
    {
        public static String GamesmasterQuestions()
        {
            Console.WriteLine("Enter a question for the bank, with answers separated by |");
            string response = Console.ReadLine();
            return response;
        }

        public static int GamesMasterCorrectIndex()
        {
            Console.WriteLine("Which option is the correct answer? (Enter the number)");
            int correctResponse = Convert.ToInt32(Console.ReadLine());
            return correctResponse;
        }
    }
}
