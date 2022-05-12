using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMachine
{
    internal class UIMethods
    {
        public static QAndA InsertQuestion()
        {
            QAndA storedQuestion = new QAndA();
            String response = GamesmasterQuestions();
            storedQuestion.correctAnswerIndex = GamesMasterCorrectIndex() - 1;
            string[] vs = response.Split('|');

            storedQuestion.question = vs[0].Trim();
            storedQuestion.answers = new List<string>();
            for (int j = 1; j < vs.Length; j++)
            {
                storedQuestion.answers.Add(vs[j].Trim());
            }
            return storedQuestion;
        }

        public static String GamesmasterQuestions()
        {
            Console.WriteLine("Enter a question for the bank, with answers separated by |");
            string response = Console.ReadLine();
            return response;
        }

        public static int GamesMasterCorrectIndex()
        {
            int correctIndex;
            Console.WriteLine("Which option is the correct answer? (Enter the number)");
            bool correctResponse = Int32.TryParse(Console.ReadLine(), out correctIndex);
            if (correctResponse == false)
            {
                Console.WriteLine("Please enter a valid number index");
            }
            return correctIndex;
        }
    }
}
