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

        public void storeQuestionAndAnswers(string response)
        {
            string[] vs = response.Split('|');
            foreach (string v in vs)
            {
                if (v.Contains("?")){
                    questions.Add(v);
                }
                answers[0] = v;
            }
        }
    }
}
