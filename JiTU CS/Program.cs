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

            Entity.QuestionEntity temp = new Entity.QuestionEntity();
            Data.QuestionData temp1 = temp.getQuestion(1);

            Console.WriteLine(temp1.Text);

            for (int i = 0; i < temp1.answers.Count; i++)
                Console.WriteLine(i + ". " + temp1.answers[i].text);


        }
    }
}
