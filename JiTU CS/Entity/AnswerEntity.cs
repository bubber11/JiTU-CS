using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JiTU_CS.Data;

namespace JiTU_CS.Entity {
    class AnswerEntity : BaseEntity {


        #region constructors_destructors

        public AnswerEntity() : base() {

            if (Connection == null)
                OpenConnection();

        }

        ~AnswerEntity() {

        }

        #endregion

        #region CRUD


        #region CREATE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="theAnswer"></param>
        public void CreateAnswer(AnswerData theAnswer) {

            theAnswer.Id = NextId;

            if (DataReader != null)
                DataReader.Close();

            SQL = "INSERT INTO `answers` (`answer_id`, `text`, `is_correct`) VALUES (\"" +
                theAnswer.Id +
                "\", \"" +
                theAnswer.Text +
                "\", " +
                theAnswer.Correct.ToString() +
                ");";

            InitializeCommand();


            int result = ExecuteStoredProcedure();

            CloseConnection();

            if (result == 0)
                throw new Exception("Could not add the answer to the database");

        }

        #endregion


        #region READ
        /// <summary>
        /// Gets a single answer object from the database with the specified ID
        /// </summary>
        /// <param name="id">id field of the Answer object being retrieved</param>
        /// <returns>an Answer object</returns>
        public AnswerData ReadAnswer(int id) {

            AnswerData return_value = null;

            if (DataReader != null)
                DataReader.Close();

            SQL = "SELECT * FROM `answers` a WHERE a.`answer_id` = \"" +
                id +
                "\";";

            InitializeCommand();
            OpenConnection();

            DataReader = Command.ExecuteReader();

            if (DataReader.HasRows) {
                DataReader.Read();
                return_value = new AnswerData(DataReader.GetUInt16("answer_id"));
                return_value.Text = DataReader.GetString("text");
                return_value.Correct = DataReader.GetBoolean("is_correct");

            }

            CloseConnection();

            if (return_value == null)
                throw new Exception("The answer requested did not exist");

            return return_value;
        }

        /// <summary>
        /// Gets a single answer object from the database with the specified Text
        /// </summary>
        /// <param name="text">the text of the answer</param>
        /// <returns>an Answer object</returns>
        public AnswerData ReadAnswer(String text) {

            AnswerData return_value = null;

            if (DataReader != null)
                DataReader.Close();

            SQL = "SELECT * FROM `answers` a WHERE a.`text` = \"" + text + "\";";
            InitializeCommand();
            OpenConnection();

            DataReader = Command.ExecuteReader();

            if (DataReader.HasRows) {
                DataReader.Read();
                return_value = new AnswerData(DataReader.GetUInt16("answer_id"));
                return_value.Text = DataReader.GetString("text");
                return_value.Correct = DataReader.GetBoolean("is_correct");
            }

            CloseConnection();

            if (return_value == null)
                throw new Exception("The Answer did not exist on the database");

            return return_value;
        }


        /// <summary>
        /// Gets a list of Answers object associated with a question
        /// </summary>
        /// <param name="theQuestion">the question being queried</param>
        /// <returns>a list of Answer objects</returns>
        public List<AnswerData> ReadAnswers(QuestionData theQuestion) {
            List<AnswerData> return_data = new List<AnswerData>();

            if (DataReader != null)
                DataReader.Close();

            SQL = "SELECT * from `answers` a INNER JOIN `rel_questions_answers` r ON r.`answer_id` = a.`answer_id` WHERE r.`question_id` = \"" + theQuestion.Id + "\";";

            InitializeCommand();
            OpenConnection();
            DataReader = Command.ExecuteReader();

            if (DataReader.HasRows) {
                while (DataReader.Read()) {
                    AnswerData temp = new AnswerData(DataReader.GetUInt16("answer_id"));
                    temp.Correct = DataReader.GetBoolean("is_correct");
                    temp.Text = DataReader.GetString("text");
                    return_data.Add(temp);
                }
            }
            CloseConnection();

            return return_data;
        }


        #endregion


        #region UPDATE

        /// <summary>
        /// 
        /// </summary>
        /// <param name="theAnswer"></param>
        public void UpdateAnswer(AnswerData theAnswer) {

            if (DataReader != null)
                DataReader.Close();

            SQL = "UPDATE `answers` a SET a.`text` = \"" +
                theAnswer.Text +
                "\", a.`is_correct` = " +
                theAnswer.Correct.ToString() +
                " WHERE a.`answer_id` = \"" +
                theAnswer.Id +
                "\";";

            InitializeCommand();
            OpenConnection();

            int result = ExecuteStoredProcedure();
            CloseConnection();

            if (result == 0)
                throw new Exception("The Answer Could Not Be Updated");


        }
        
        #endregion


        #region DELETE

        /// <summary>
        /// 
        /// </summary>
        /// <param name="theAnswer"></param>
        public void DeleteAnswer(AnswerData theAnswer) {
            
            if (DataReader != null)
                DataReader.Close();


            SQL = "DELETE FROM `answers` WHERE `answer_id` = \"" + theAnswer.Id + "\";";

            InitializeCommand();
            OpenConnection();

            int result = ExecuteStoredProcedure();

            if (result == 0)
                throw new Exception("Could not delete the answer from the database");

            if( DataReader != null)
                DataReader.Close();

            SQL = "DELETE FROM `rel_questions_answers` WHERE `answer_id` = \"" + theAnswer.Id + "\";";

            InitializeCommand();

            result = ExecuteStoredProcedure();

            if (result == 0)
                throw new Exception("Could not delete the answer relation from the database");

            if (DataReader != null)
                DataReader.Close();

            SQL = "DELETE FROM `rel_answers_users` WHERE `answer_id` = \"" + theAnswer.Id + "\";";
            InitializeCommand();

            result = ExecuteStoredProcedure();
            CloseConnection();

            if (result == 0)
                throw new Exception("Could not clear the results for that answer");

        }

        #endregion

        #endregion

        #region Properties
        public int NextId {
            get {
                int return_data = 0;

                /** Make sure that there is not a data table open at the moment **/
                if (DataReader != null)
                    DataReader.Close();

                SQL = "SELECT IFNULL(MAX(answer_id), 0) FROM answers;";

                InitializeCommand();

                OpenConnection();

                DataReader = Command.ExecuteReader();

                if (DataReader.HasRows) {
                    DataReader.Read();
                    return_data = DataReader.GetUInt16("IFNULL(MAX(answer_id), 0)");
                }

                CloseConnection();

                return_data++;

                return return_data;
            }
        }
        #endregion

    }
}
