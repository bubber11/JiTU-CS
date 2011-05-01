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


            }


            return is_valid;
        }

    }
}
