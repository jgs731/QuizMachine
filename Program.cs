using System;
using System.Xml.Serialization;

namespace QuizMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerScore = 0;
            List<QAndABank> questionBank = new List<QAndABank>(5);
            for(int i = 0; i < questionBank.Count; i++)
            {
                String response = UIMethods.GamesmasterQuestions();
                int correctResponse = UIMethods.GamesMasterCorrectIndex();
                SaveQuestionBank(questionBank[i], response, correctResponse);
            }

            Console.Clear();
            var qns = ReadQuestionBank();
            Console.WriteLine(qns.questions);
            string playerAnswer = Console.ReadLine();
            if (playerAnswer == qns.answers[qns.correctAnswerIndex - 1])
            {
                Console.WriteLine("Correct!");
                playerScore++;
            }
            else
            {
                Console.WriteLine($"Incorrect, the correct answer is {qns.answers[qns.correctAnswerIndex - 1]}");
            }

            Console.WriteLine($"Final score: {playerScore}");
        }

        public static void SaveQuestionBank(QAndABank questionStore, string response, int correctIndex)
        {
            StreamWriter writer;;
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