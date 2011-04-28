using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JiTU_CS.Data {
    public class QuestionData {

        public QuestionData(int idIn) {
            id_internal = idIn;
            text_internal = String.Empty;
            answers_internal = new List<AnswerData>();
        }

        public String Text {
            get {
                return text_internal;
            }
            set {
                text_internal = value;
            }
        }

        public List<AnswerData> Answers {
            get {
                return answers_internal;
            }
        }

        public int Id {
            get {
                return id_internal;
            }
            set {
                id_internal = value;
            }
        }


        public void AddAnswer(AnswerData answerIn) {
            answers_internal.Add(answerIn);
        }


        private List<AnswerData> answers_internal;
        private String text_internal;
        private int id_internal;
    }
}
