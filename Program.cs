using System;
using System.Xml.Serialization;

namespace QuizMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerScore = 0;
            System.Collections.Generic.List<QAndABank> questionBank = new List<QAndABank>(5);
            QAndABank storedQuestion = new QAndABank();

            for (int i = 0; i < 5; i++)
            {
                String response = UIMethods.GamesmasterQuestions();
                storedQuestion.correctAnswerIndex = UIMethods.GamesMasterCorrectIndex() - 1;
                string[] vs = response.Split('|');

                storedQuestion.questions = vs[0].Trim();
                storedQuestion.answers = new List<string>();
                for (int j = 1; i < vs.Length; i++)
                {
                    storedQuestion.answers.Add(vs[j].Trim());
                }
                questionBank.Add(storedQuestion);
            }
            SaveQuestionBank(questionBank);

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

        public static void SaveQuestionBank(List<QAndABank> questionStore)
        {
            StreamWriter writer;
            var serializer = new XmlSerializer(typeof(List<QAndABank>));
            using (writer = new StreamWriter("question_and_answer_bank.xml"))
            {         
                serializer.Serialize(writer, questionStore);
            }
            writer.Close();
        }

        public static QAndABank ReadQuestionBank()
        {
            var question = new QAndABank();
            var deserializer = new XmlSerializer(typeof(List<QAndABank>));
            using (StreamReader reader = new StreamReader("question_and_answer_bank.xml"))
            {
                question = (QAndABank)deserializer.Deserialize(reader);
            }
            return question;
        }
    }
}