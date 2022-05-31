using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMachine
{
    internal class UIMethods
    {
        static readonly Random rng = new Random();

        /// <summary>
        /// Organises the <QAndA>question</QAndA> and <QAndA>answers</QAndA> entered by the Gamesmaster into a QAndA object.
        /// </summary>
        /// <returns>QAndA object containing question, possible answers and the correct answer index</returns>
        public static QAndA EnterQuestion()
        {
            QAndA storedQuestion = new QAndA();
            string response;
            string[] separatedQuestionAndAnswers = {};
            bool validQuestionAdded = false;
            while (validQuestionAdded == false)
            {
                response = AddQuestion();
                if (!response.Contains('|') || String.IsNullOrEmpty(response))
                {
                    Console.WriteLine("Please enter a question and possible answers in the expected format!");
                }
                else
                {
                    separatedQuestionAndAnswers = response.Split('|');
                    storedQuestion.question = separatedQuestionAndAnswers[0].Trim();
                    storedQuestion.answers = new List<string>();
                    for (int j = 1; j < separatedQuestionAndAnswers.Length; j++)
                    {
                        storedQuestion.answers.Add(separatedQuestionAndAnswers[j].Trim());
                    }
                    storedQuestion.correctAnswerIndex = SetCorrectAnswerIndex(storedQuestion.answers.Count);
                    validQuestionAdded = true;
                }
            }
            return storedQuestion;
        }

        /// <summary>
        /// Prompt for the Gamesmaster to enter a question and possible answers
        /// </summary>
        /// <returns>Gamesmaster question and possible answers in string format</returns>
        public static string AddQuestion()
        {
            bool responseCorrectFormat = false;
            Console.WriteLine("Enter a question for the bank, with answers separated by |");
            string response = Console.ReadLine();
            while(responseCorrectFormat)
            {
                if (!response.Contains("|") || response.Length == 0) {
                    Console.WriteLine("Please separate answers with the '|' character. It's important!");
                }
                else
                {
                   responseCorrectFormat = true; 
                }
            }
            return response;
        }
        /// <summary>
        /// Store the correct answer index (zero-index is accounted for here so that the Gamesmaster can start from 1)
        /// </summary>
        /// <param name="addedQuestion">QnA object for a single question</param>
        /// <returns>positive Integer</returns>
        public static int SetCorrectAnswerIndex(int numberOfPossibleAnswers)
        {
            int correctIndex;
            Console.WriteLine("Which option is the correct answer? (Enter the number)");            
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out correctIndex) || correctIndex <= 0 || correctIndex > numberOfPossibleAnswers)
                {
                    Console.WriteLine("Invalid number index entered. Try again! ");
                }
                else
                {
                    correctIndex--;
                    break;
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
            int randomIndex = rng.Next(qns.Count);
            var q = qns[randomIndex];
            Console.Clear();
            Console.WriteLine(q.question);
            for(int i = 0; i < q.answers.Count; i++) {
                Console.Write(q.answers[i].ToLower() + "\t");
            }
            Console.WriteLine();

            string playerAnswer = Console.ReadLine();
            if (playerAnswer.ToLower() == q.answers[q.correctAnswerIndex].ToLower())
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
