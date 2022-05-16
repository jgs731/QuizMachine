using System;
using System.Xml.Serialization;

namespace QuizMachine
{
    internal class Program
    {
        static Random? randomQuestionNumber;
        static void Main(string[] args)
        {
            int playerScore = 0;
            List<QAndA> questionBank = new List<QAndA>(5);

            for (int i = 0; i < questionBank.Capacity; i++)
            {
                QAndA q = UIMethods.InsertQuestion();
                questionBank.Add(q);
            }
            SaveQuestionBank(questionBank);

            Console.Clear();
            var qns = ReadQuestionBank();

            for (int i = 0; i < qns.Count; i++)
            {
                playerScore =+ PickRandomQuestion(qns);
            }
            Console.WriteLine($"Final score: {playerScore}");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="qns"></param>
        /// <returns></returns>
        private static int PickRandomQuestion(List<QAndA> qns)
        {
            int score = 0;
            int randomIndex = randomQuestionNumber.Next(1, qns.Count);
            Console.WriteLine(qns[randomIndex].question);
            string playerAnswer = Console.ReadLine();
            if (playerAnswer == qns[randomIndex].answers[qns[randomIndex].correctAnswerIndex])
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine($"Incorrect, the correct answer is {qns[randomIndex].answers[qns[randomIndex].correctAnswerIndex]}");
            }
            return score;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionStore"></param>
        public static void SaveQuestionBank(List<QAndA> questionStore)
        {
            StreamWriter writer;
            var serializer = new XmlSerializer(typeof(List<QAndA>));
            using (writer = new StreamWriter("question_and_answer_bank.xml"))
            {         
                serializer.Serialize(writer, questionStore);
            }
            writer.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<QAndA> ReadQuestionBank()
        {
            var question = new List<QAndA>();
            var deserializer = new XmlSerializer(typeof(List<QAndA>));
            using (StreamReader reader = new StreamReader("question_and_answer_bank.xml"))
            {
                question = (List<QAndA>)deserializer.Deserialize(reader);
            }
            return question;
        }
    }
}