using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JiTU_CS.Data {

    class ResultData {

        public ResultData(UserData theUser, QuizData theQuiz) {
            __Answers = new List<AnswerData>();
            __Student = theUser;
            __Quiz = theQuiz;
        }

        public List<AnswerData> Answers {
            get {
                return __Answers;
            }
        }

        public UserData Student {
            get {
                return __Student;
            }
        }

        public QuizData Quiz {
            get {
                return __Quiz;
            }
        }

        private List<AnswerData> __Answers;
        private UserData __Student;
        private QuizData __Quiz;

    }

}
