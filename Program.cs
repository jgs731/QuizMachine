using System;
using System.Xml.Serialization;

namespace QuizMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerScore = 0;
            var questions = new QAndABank();
            Console.WriteLine("Enter a question for the bank, with answers separated by |");
            string response = Console.ReadLine();
            Console.WriteLine("Which option is the correct answer? (Enter the number)");
            int correctResponse = Convert.ToInt32(Console.ReadLine());
            SaveQuestionBank(response, correctResponse);
            Console.Clear();
            questions = ReadQuestionBank();
            Console.WriteLine(questions.questions);
            string playerAnswer = Console.ReadLine();
            if (playerAnswer == questions.answers[questions.correctAnswerIndex - 1])
            {
                Console.WriteLine("Correct!");
                playerScore++;
            }
            else
            {
                Console.WriteLine($"Incorrect, the correct answer is {questions.answers[questions.correctAnswerIndex - 1]}");
            }

            Console.WriteLine($"Final score: {playerScore}");
        }

        public static void SaveQuestionBank(string response, int correctIndex)
        {
            StreamWriter writer;
            var questionStore = new QAndABank();
            string[] vs = response.Split('|');
            List<string> tempStoreAnswers = new List<string>();
            questionStore.questions = vs[0];
            for(int i = 1; i < (vs.Length - 1); i++)
            {
                tempStoreAnswers.Add(vs[i].Trim());
            }
            questionStore.answers = tempStoreAnswers.ToArray();
            questionStore.correctAnswerIndex = correctIndex;
            var serializer = new XmlSerializer(typeof(QAndABank));
            using (writer = new StreamWriter("question_and_answer_bank.xml"))
            {         
                serializer.Serialize(writer, questionStore);
            }
            writer.Close();
        }

        public static QAndABank ReadQuestionBank()
        {
            QAndABank question = new QAndABank();
            var deserializer = new XmlSerializer(typeof(QAndABank));
            using (StreamReader reader = new StreamReader("question_and_answer_bank.xml"))
            {
                question = (QAndABank)deserializer.Deserialize(reader);
            }

            return question;
        }
    }
}