using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMachine
{
    internal class UIMethods
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static QAndA InsertQuestion()
        {
            QAndA storedQuestion = new QAndA();
            String response = GamesmasterQuestions();
            storedQuestion.correctAnswerIndex = GamesMasterCorrectIndex(storedQuestion);
            string[] vs = response.Split('|');

            storedQuestion.question = vs[0].Trim();
            storedQuestion.answers = new List<string>();
            for (int j = 1; j < vs.Length; j++)
            {
                storedQuestion.answers.Add(vs[j].Trim());
            }
            return storedQuestion;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GamesmasterQuestions()
        {
            Console.WriteLine("Enter a question for the bank, with answers separated by |");
            string response = Console.ReadLine();
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GamesMasterCorrectIndex(QAndA addedQuestion)
        {
            int correctIndex;
            Console.WriteLine("Which option is the correct answer? (Enter the number)");
            bool correctResponse = Int32.TryParse(Console.ReadLine(), out correctIndex);
            while (correctResponse == false)
            {
                if (addedQuestion.answers[correctIndex] == null)
                {
                    Console.WriteLine("Please enter a valid number index");
                }
                else
                {
                    correctIndex = correctIndex - 1;
                    correctResponse = true;
                }
            }
            return correctIndex;
        }
    }
}
