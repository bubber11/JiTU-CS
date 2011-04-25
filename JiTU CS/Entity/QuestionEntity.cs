using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JiTU_CS.Data;


namespace JiTU_CS.Entity {
    class QuestionEntity : BaseEntity {


        #region constructors_destructors

        public QuestionEntity() {

        }

        ~QuestionEntity() {

        }

        #endregion

        #region functions

        public QuestionData getQuestion(int theQuest) {
            QuestionData return_value = null;

            SQL = "SELECT * FROM questions q WHERE q.question_id = \"" + theQuest + "\";";
            InitializeCommand();
            OpenConnection();
            DataReader = Command.ExecuteReader();

            if (DataReader.HasRows) {
                DataReader.Read();
                return_value = new QuestionData(DataReader.GetUInt16("question_id"));
                return_value.Text = DataReader.GetString("question");
            }
            List<AnswerData> temp = getAnswers(return_value);
            for (int i = 0; i < temp.Count; i++)
                return_value.addAnswer(temp[i]);

            return return_value;
        }

        public List<AnswerData> getAnswers(QuestionData theQuestion) {
            List<AnswerData> return_value = new List<AnswerData>();

            DataReader.Close();
            SQL = "SELECT * FROM answers a INNER JOIN rel_questions_answers r ON r.answer_id = a.answer_id WHERE r.question_id = \"" + theQuestion.id + "\";";
            InitializeCommand();
            OpenConnection();
            DataReader = Command.ExecuteReader();

            if (DataReader.HasRows) {
                while (DataReader.Read()) {
                    AnswerData temp = new AnswerData(DataReader.GetUInt16("answer_id"));
                    temp.correct = DataReader.GetBoolean("is_correct");
                    temp.text = DataReader.GetString("text");
                    return_value.Add(temp);
                }
            } else
                throw new Exception("The question does not have any answers");

            return return_value;
        }

        


        #endregion


    }
}
