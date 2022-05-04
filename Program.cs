using System;
using System.Xml.Serialization;

namespace QuizMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QAndABank qaBank = new QAndABank();
            Console.WriteLine("Enter a question for the bank, with answers separated by | (Mark the correct answer with a '*' at the end)");
            string response = Console.ReadLine();

            SaveQuestionBank(response);
        }

        public static void SaveQuestionBank(string response)
        {
            StreamWriter writer;
            string[] vs = response.Split('|');
            var serializer = new XmlSerializer(typeof(QAndABank));
            using (writer = new StreamWriter("question_and_answer_bank.xml"))
            {         
                serializer.Serialize(writer, vs);
            }
            writer.Close();
        }

        public static String ReadQuestionBank()
        {
            String storedQuestion = "";
            QAndABank file = new QAndABank();
            var deserializer = new XmlSerializer(typeof(QAndABank));
            using (StreamReader reader = new StreamReader("question_and_answer_bank.xml"))
            {
                deserializer.Deserialize(reader);
                for (int i = 0;  i < reader.ReadToEnd().Length; i++)
                {
                    if (reader.ToString().Contains("?"))
                    {
                        storedQuestion = reader.ToString();
                        continue;
                    }
                }
            }
            return storedQuestion; // Think I need to return an object here, will reassess in next commit
        }
    }
}