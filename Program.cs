using System;
using System.Xml.Serialization;

namespace QuizMachine
{
    internal class Program
    {
        static readonly string FILE_NAME = "question_and_answer_bank.xml";

        static void Main(string[] args)
        {
            int playerScore = 0;
            List<QAndA> questionBank = new List<QAndA>(3);

            if (!File.Exists(FILE_NAME))
            {
                for (int i = 0; i < questionBank.Capacity; i++)
                {
                    QAndA q = UIMethods.EnterQuestion();
                    questionBank.Add(q);
                }
                SaveQuestionBank(questionBank);
            }
            else
            {
                questionBank = ReadQuestionBank();
                for (int i = 0; i < questionBank.Count; i++)
                {
                    playerScore += UIMethods.GetQuestionScore(questionBank);
                }
                UIMethods.DisplayFinalScore(playerScore);
            }
        }

        /// <summary>
        /// Outputs the List of Questions to a XML file
        /// </summary>
        /// <param name="questionStore">List of QnA objects for serialisation</param>
        public static void SaveQuestionBank(List<QAndA> questionStore)
        {
            StreamWriter writer;
            var serializer = new XmlSerializer(typeof(List<QAndA>));
            using (writer = new StreamWriter(FILE_NAME))
            {         
                serializer.Serialize(writer, questionStore);
            }
            writer.Close();
        }
        /// <summary>
        /// Converts the XML file of questions to a QAndA object to be read in the Quiz game
        /// </summary>
        /// <returns>Deserialised List of QnA objects</returns>
        public static List<QAndA> ReadQuestionBank()
        {
            var deserializer = new XmlSerializer(typeof(List<QAndA>));
            using (StreamReader reader = new StreamReader(FILE_NAME))
            {
                return (List<QAndA>)deserializer.Deserialize(reader);
            }
        }
    }
}