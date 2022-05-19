using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMachine
{
    internal class UIMethods
    {
        static Random? rng = new Random();

        /// <summary>
        /// Organises the <QAndA>question</QAndA> and <QAndA>answers</QAndA> entered by the Gamesmaster into a QAndA object.
        /// </summary>
        /// <returns>QAndA object containing question, possible answers and the correct answer index</returns>
        public static QAndA EnterQuestion()
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
        /// Prompt for the Gamesmaster to enter a question and possible answers
        /// </summary>
        /// <returns>Gamesmaster question and possible answers in string format</returns>
        public static string GamesmasterQuestions()
        {
            Console.WriteLine("Enter a question for the bank, with answers separated by |");
            string response = Console.ReadLine();
            return response;
        }
        /// <summary>
        /// Store the correct answer index (zero-index is accounted for here so that the Gamesmaster can start from 1)
        /// </summary>
        /// <param name="addedQuestion">QnA object for a single question</param>
        /// <returns>positive Integer</returns>
        public static int GamesMasterCorrectIndex(QAndA addedQuestion)
        {
            int correctIndex;
            Console.WriteLine("Which option is the correct answer? (Enter the number)");
            bool validInput = Int32.TryParse(Console.ReadLine(), out correctIndex);
            while (validInput == false)
            {
                if (addedQuestion.answers[correctIndex] == null)
                {
                    Console.WriteLine("Please enter a valid number index");
                }
                else
                {
                    correctIndex = correctIndex - 1;
                    validInput = true;
                }
            }
            return correctIndex;
        }

        /// <summary>
        /// Displays a question to the player, and asserts if the response is correct
        /// </summary>
        /// <param name="qns">List of questions (stored as QAndA objects in a List)</param>
        /// <returns>1 for a correct answer or 0 for an incorrect answer</returns>
        public static int GetQuestionScore(List<QAndA> qns)
        {
            int score = 0;
            int randomIndex = rng.Next(1, qns.Count);
            var q = qns[randomIndex];
            Console.Clear();
            Console.WriteLine(q.question);
            string playerAnswer = Console.ReadLine();
            if (playerAnswer == q.answers[q.correctAnswerIndex])
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine($"Incorrect, the correct answer is {q.answers[q.correctAnswerIndex]}");
            }
            return score;
        }

        /// <summary>
        /// Display the final score to the player at the end of the game/
        /// </summary>
        /// <param name="playerScore">Player score calculated during the game</param>
        public static void DisplayFinalScore(int playerScore)
        {
            Console.WriteLine($"Final score: {playerScore}");
        }
    }
}
