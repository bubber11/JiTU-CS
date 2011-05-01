using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JiTU_CS.Entity;
using JiTU_CS.Data;

namespace JiTU_CS.Controller {
    static class QuestionController {

        static QuestionEntity theEntity = new QuestionEntity();

        public static bool ValidateQuestion(QuestionData theQuestion) {
            bool is_valid = true;

            if (theQuestion.Text.Length <= 4) {
                is_valid = false;
            }

            foreach (AnswerData data in theQuestion.Answers) {
                is_valid = AnswerController.ValidateAnswer(data);
                if (!is_valid)
                    break;
            }

            if (is_valid)
                if (theQuestion.Answers.Count < 2)
                    is_valid = false;

            if (is_valid) {
                int count = 0;
                for (int i = 0; i < theQuestion.Answers.Count; i++)
                    if (theQuestion.Answers[i].Correct)
                        count++;

                is_valid = (count == 1);
            }

            return is_valid;
        }

        public static void DeleteQuestion(QuestionData theQuestion)
        {
            theEntity.DeleteQuestion(theQuestion);
        }

    }
}
