using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace JiTU_CS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new UI.GeneralUI());

            Entity.QuestionEntity questEnt = new Entity.QuestionEntity();
            Entity.AnswerEntity answEnt = new Entity.AnswerEntity();

            Data.QuestionData tempQuest;
            Data.AnswerData tempAnsw;


            tempQuest = new Data.QuestionData(0);
            tempQuest.Text = "What is today?";

            questEnt.addQuestion(tempQuest);

            tempQuest = questEnt.getQuestion(tempQuest.Text);

            tempAnsw = new Data.AnswerData(0);
            tempAnsw.text = "Monday";
            tempAnsw.correct = true;

            answEnt.addAnswer(tempAnsw);

            tempAnsw = answEnt.getAnswer(tempAnsw.text);

            tempQuest.addAnswer(tempAnsw);

            tempQuest = questEnt.getQuestion(tempQuest.id);

            Console.WriteLine(tempQuest.Text);
            Console.WriteLine(tempQuest.answers[0].text);
        }
    }
}
