using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JiTU_CS.Data;

namespace JiTU_CS.Entity {
    class AnswerEntity : BaseEntity {

        #region constructors_destructors

        public AnswerEntity() {


        }

        ~AnswerEntity() {

        }

        #endregion

        public AnswerData getAnswer(int id) {

            AnswerData return_value = null;

            SQL = "SELECT * FROM answers a WHERE a.answer_id = \"" + id + "\";";
            InitializeCommand();
            OpenConnection();
            DataReader = Command.ExecuteReader();

            if (DataReader.HasRows) {
                DataReader.Read();
                return_value = new AnswerData(DataReader.GetUInt16("answer_id"));
                return_value.text = DataReader.GetString("answer");
                return_value.correct = DataReader.GetBoolean("is_correct");
            } else
                throw new Exception("An Answer with that ID does not Exist");

            return return_value;
        }

        public AnswerData getAnswer(String text) {
            AnswerData return_value = null;

            if (DataReader != null)
                DataReader.Close();

            SQL = "SELECT * FROM answers a WHERE a.text = \"" + text + "\";";
            InitializeCommand();
            OpenConnection();

            DataReader = Command.ExecuteReader();

            

            if (DataReader.HasRows) {
                DataReader.Read();

                return_value = new AnswerData(DataReader.GetUInt16("answer_id"));
                return_value.text = DataReader.GetString("text");
                return_value.correct = DataReader.GetBoolean("is_correct");
                CloseConnection();

            } else
                throw new Exception("Could not find answer on database");



            return return_value;
        }

        public void addAnswer(AnswerData theAnswer) {
            if (DataReader != null)
                DataReader.Close();

            SQL = "INSERT INTO answers (text, is_correct) VALUES (\"" + theAnswer.text + "\", \"" + theAnswer.correct + "\");";
            InitializeCommand();
            OpenConnection();

            int result = ExecuteStoredProcedure();

            CloseConnection();

            if (result == 0)
                throw new Exception("Unable to Add The Answer to the Database");

        }

        public void updateAnswer(AnswerData theAnswer) {

            if (DataReader != null)
                DataReader.Close();

            SQL = "UPDATE answers a SET a.text = \"" + theAnswer.text + "\", a.is_correct = \"" + theAnswer.correct + "\" WHERE a.answer_id = \"" + theAnswer.id + "\";";
            InitializeCommand();
            OpenConnection();

            int result = ExecuteStoredProcedure();

            CloseConnection();

            if (result == 0)
                throw new Exception("Could Not Update answer data on the database");


        }


        public void deleteAnswer(AnswerData theAnswer) {

            if (DataReader != null)
                DataReader.Close();

            SQL = "DELETE FROM answers WHERE answers.answer_id = \"" + theAnswer.id + "\"; DELETE FROM rel_questions_answers WHERE rel_questions_answers.answer_id = \"" + theAnswer.id + "\";";
            InitializeCommand();
            OpenConnection();
            int result = ExecuteStoredProcedure();

            CloseConnection();

            if (result == 0)
                throw new Exception("Could Not Delete Answer Data from Database");


        }




    }
}
