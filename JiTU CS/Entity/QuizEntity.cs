using System;
using System.Collections.Generic;
using System.Text;
using JiTU_CS.Data;

namespace JiTU_CS.Entity {
    class QuizEntity : BaseEntity {


        #region constructors_destructors
        public QuizEntity() {

        }

        ~QuizEntity() {


        }
        #endregion

        public QuizData getQuiz(int id) {
            QuizData return_value = null;

            if (DataReader != null)
                DataReader.Close();

            SQL = "SELECT * FROM quizzes q WHERE q.quiz_id = \"" + id + "\";";

            InitializeCommand();

            OpenConnection();

            DataReader = Command.ExecuteReader();

            if (DataReader.HasRows) {
                DataReader.Read();

                return_value = new QuizData(DataReader.GetUInt16("quiz_id"));
                return_value.Added = DataReader.GetDateTime("open_date");
                return_value.Due = DataReader.GetDateTime("due_date");
                CloseConnection();

                List<QuestionData> temp = getQuestions(return_value);
                for (int i = 0; i < temp.Count; i++)
                    return_value.addQuestion(temp[i]);

            }
            else {
                CloseConnection();
                throw new Exception("The Quiz does not exist");
            }

            return return_value;
        }

        public List<QuestionData> getQuestions(QuizData quizIn) {

            List<QuestionData> return_value = new List<QuestionData>();

            if (DataReader != null)
                DataReader.Close();

            SQL = "SELECT r.question_id FROM rel_quizzes_questions r where r.quiz_id =\"" + quizIn.id + "\";";

            InitializeCommand();
            OpenConnection();
            DataReader = Command.ExecuteReader();

            if (DataReader.HasRows) {
                QuestionEntity temp = new QuestionEntity();
                while (DataReader.Read()) {
                    return_value.Add(temp.getQuestion(DataReader.GetUInt16("question_id")));
                }
            }


            return return_value;
        }

    }
}
