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
            if (DataReader != null)
                DataReader.Close();
            CloseConnection();
        }

        #endregion

        #region CRUD

        #region CREATE

        public void CreateQuestion (QuestionData theQuestion) {

            theQuestion.Id = NextId;

            AnswerEntity temp;

            temp = new AnswerEntity();

            for (int i = 0; i < theQuestion.Answers.Count; i++) {
                temp.CreateAnswer(theQuestion.Answers[i]);
            }
            temp.Dispose();

            if (DataReader != null)
                DataReader.Close();

            SQL = "INSERT INTO `questions` (`question_id`, `question`) VALUES (\"" + theQuestion.Id + "\", \"" + theQuestion.Text + "\");";

            InitializeCommand();
            OpenConnection();

            int result = ExecuteStoredProcedure();

            if (DataReader != null)
                DataReader.Close();

            if (result == 0)
                throw new Exception("Cannot add the selected question to the database");

            for (int i = 0; i < theQuestion.Answers.Count; i++) {
                if (DataReader != null)
                    DataReader.Close();

                SQL = "INSERT INTO `rel_questions_answers` (`question_id`, `answer_id`) VALUES (\"" +
                    theQuestion.Id +
                    "\", \"" +
                    theQuestion.Answers[i].Id +
                    "\");";
                InitializeCommand();
                OpenConnection();

                result = ExecuteStoredProcedure();
                if (result == 0)
                    throw new Exception("One or more of the answers could not be added to the database");

            }
            CloseConnection();     

        }

        #endregion

        #region READ

        public QuestionData ReadQuestion(int id) {

            QuestionData return_data = null;

            if (DataReader != null)
                DataReader.Close();

            SQL = "SELECT * FROM `questions` q WHERE q.`question_id` = \"" + id + "\";";

            InitializeCommand();
            OpenConnection();
            DataReader = Command.ExecuteReader();

            if (DataReader.HasRows) {
                DataReader.Read();
                return_data = new QuestionData(DataReader.GetUInt16("question_id"));
                return_data.Text = DataReader.GetString("question");
                DataReader.Close();
            }

            if (return_data != null) {
                AnswerEntity temp = new AnswerEntity();
                List<AnswerData> temp1 = temp.ReadAnswers(return_data);
                for (int i = 0; i < temp1.Count; i++)
                    return_data.AddAnswer(temp1[i]);
                temp.Dispose();
            }
            
            return return_data;
        }

        public List<QuestionData> ReadQuestions(QuizData theQuiz) {
            
            List<QuestionData> return_data = new List<QuestionData>();

            if (DataReader != null)
                DataReader.Close();

            List<int> quest_ids = new List<int>();

            SQL = "SELECT r.`question_id` FROM `rel_quizzes_questions` r WHERE r.`quiz_id` = \"" + theQuiz.Id + "\";";

            InitializeCommand();
            OpenConnection();

            DataReader = Command.ExecuteReader();

            if (DataReader.HasRows)
                while (DataReader.Read())
                    quest_ids.Add(DataReader.GetUInt16("question_id"));

            CloseConnection();

            for (int i = 0; i < quest_ids.Count; i++)
                return_data.Add(ReadQuestion(quest_ids[i]));

            return return_data;
        }
      
        #endregion

        #region UPDATE

        public void UpdateQuestion(QuestionData theQuestion) {

            AnswerEntity temp = new AnswerEntity();
            for (int i = 0; i < theQuestion.Answers.Count; i++)
                temp.UpdateAnswer(theQuestion.Answers[i]);
            temp.Dispose();

            if (DataReader != null)
                DataReader.Close();


            SQL = "UPDATE `questions` q SET q.`question` = \"" + theQuestion.Text + "\" WHERE q.`question_id` = \"" + theQuestion.Id + "\";";

            InitializeCommand();
            OpenConnection();

            int result = ExecuteStoredProcedure();

            CloseConnection();

            if (result == 0)
                throw new Exception("Unable to edit the question on database");


        }

        #endregion

        #region DELETE

        public void DeleteQuestion(QuestionData theQuestion) {

            if (DataReader != null)
                DataReader.Close();


            SQL = "DELETE `questions`, `answers`, `rel_questions_answers` FROM `questions` INNER JOIN `rel_questions_answers` on `questions`.`question_id` = `rel_questions_answers`.`question_id` INNER JOIN `answers` ON `answers`.`answer_id` = `rel_questions_answers`.`answer_id` WHERE `questions`.`question_id` = \"" + theQuestion.Id + "\";";

            InitializeCommand();
            OpenConnection();

            int result = ExecuteStoredProcedure();

            CloseConnection();

            if (result == 0)
                throw new Exception("Could not delete the data from the database");

        }


        #endregion

        #endregion

        #region Properties

        public int NextId {
            get {
                int return_data = 0;

                if (DataReader != null)
                    DataReader.Close();

                SQL = "SELECT IFNULL(MAX(question_id), 0) FROM questions;";

                InitializeCommand();
                OpenConnection();

                DataReader = Command.ExecuteReader();

                if (DataReader.HasRows) {
                    DataReader.Read();
                    return_data = DataReader.GetUInt16("IFNULL(MAX(question_id), 0)");
                }

                CloseConnection();
                return_data++;

                return return_data;
            }
        }
        #endregion
    
    
    }
}
