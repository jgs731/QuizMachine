using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMachine
{
    internal class QAndABank
    {
        List<string> questions = new List<string>();
        string[] answers;
        StreamWriter writer;

        public void storeQuestionAndAnswers(string response)
        {
            string[] vs = response.Split('|');
            foreach (string str in vs)
            {
                using (writer = new StreamWriter("question_and_answer_bank.txt"))
                {
                    if (str.Contains("?"))
                    {
                        questions.Add(str);
                        continue;
                    }
                    Console.WriteLine(str);
                    writer.WriteLine(str);
                }
            }
            writer.Close();
        }
    }
}
