using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JiTU_CS.Data {
    public class QuizData {

        public QuizData(int id) {
            id_internal = 0;
            questions_internal = new List<QuestionData>();
            added_internal = 0;
            due_internal = 0;
        }

        public int id {
            get {
                return id_internal;
            }
            set {
                id_internal = value;
            }
        }

        public List<QuestionData> questions {
            get {
                return questions_internal;
            }
        }

        public int DateAdded {
            get {
                return added_internal;
            }
            set {
                added_internal = value;
            }
        }

        public int DueDate {
            get {
                return due_internal;
            }
            set {
                due_internal = value;
            }
        }

        public void addQuestion(QuestionData dataIn) {
            questions_internal.Add(dataIn);
        }

        private int id_internal;
        private List<QuestionData> questions_internal;
        private int added_internal;
        private int due_internal;
        
    }
}
