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

            if (DataReader != null)
                DataReader.Close();

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

        public QuestionData getQuestion(String text) {
            QuestionData return_value = null;

            if (DataReader != null)
                DataReader.Close();

            SQL = "SELECT * FROM questions q WHERE q.question = \"" + text + "\";";
            InitializeCommand();
            OpenConnection();

            DataReader = Command.ExecuteReader();

            if (DataReader.HasRows) {
                DataReader.Read();
                return_value = new QuestionData(DataReader.GetUInt16("question_id"));
                return_value.Text = DataReader.GetString("question");

            } else
                throw new Exception("Could Not Find Question on Database");


            return return_value;
        }

        public List<AnswerData> getAnswers(QuestionData theQuestion) {
           
            List<AnswerData> return_value = new List<AnswerData>();

            if (DataReader != null)
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
            }

            CloseConnection();

            return return_value;
        }

        public void addQuestion(QuestionData theQuestion) {
            if (DataReader != null)
                DataReader.Close();

            SQL = "INSERT INTO questions (question) VALUES (\"" + theQuestion.Text + "\");";
            InitializeCommand();
            OpenConnection();

            int result = ExecuteStoredProcedure();

            CloseConnection();

            if (result == 0)
                throw new Exception("Unable to add question to database");

        }

        public void updateQuestion(QuestionData theQuestion) {


            if (DataReader != null)
                DataReader.Close();

            SQL = "UPDATE questions q SET q.text = \"" + theQuestion.Text + "\" WHERE q.question_id = \"" + theQuestion.id + "\";";
            InitializeCommand();
            OpenConnection();
            int result = ExecuteStoredProcedure();
            CloseConnection();

            if (result == 0)
                throw new Exception("Unable to update the Question Contents");

        }

        public void deleteQuestion(QuestionData theQuestion) {

            if (DataReader != null)
                DataReader.Close();

            SQL = "DELETE FROM questions WHERE questions.question_id = \"" + theQuestion.id + "\";";
            InitializeCommand();
            OpenConnection();
            int result = ExecuteStoredProcedure();
            CloseConnection();
            if (result == 0)
                throw new Exception("Unable to delete the Question");


        }

        public void addAnswer(QuestionData theQuestion, AnswerData theAnswer) {
            if (DataReader != null)
                DataReader.Close();

            SQL = "INSERT INTO rel_questions_answers (question_id, answer_id) VALUES (\"" + theQuestion.id + "\", \"" + theAnswer.id + "\");";
            InitializeCommand();
            OpenConnection();

            int result = ExecuteStoredProcedure();

            CloseConnection();

            if (result == 0)
                throw new Exception("Unable to create realtionship between Question " + theQuestion.id + " and Answer " + theAnswer.id + ".");

        }

        #endregion


    }
}
