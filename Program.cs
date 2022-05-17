using System;
using System.Xml.Serialization;

namespace QuizMachine
{
    internal class Program
    {
        static string file = "question_and_answer_bank.xml";
        static void Main(string[] args)
        {
            int playerScore = 0;
            List<QAndA> questionBank = new List<QAndA>(5);

            if (!File.Exists(file)) {
                for (int i = 0; i < questionBank.Capacity; i++)
                {
                    QAndA q = UIMethods.InsertQuestion();
                    questionBank.Add(q);
                }
                SaveQuestionBank(questionBank);

                Console.Clear();
            }
            questionBank = ReadQuestionBank();

            for (int i = 0; i < questionBank.Count; i++)
            {
                playerScore += UIMethods.GetQuestionScore(questionBank);
            }
            Console.WriteLine($"Final score: {playerScore}");
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionStore"></param>
        public static void SaveQuestionBank(List<QAndA> questionStore)
        {
            StreamWriter writer;
            var serializer = new XmlSerializer(typeof(List<QAndA>));
            using (writer = new StreamWriter(file))
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
            var deserializer = new XmlSerializer(typeof(List<QAndA>));
            using (StreamReader reader = new StreamReader(file))
            {
                return (List<QAndA>)deserializer.Deserialize(reader);
            }
        }
    }
}