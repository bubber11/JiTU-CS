using System;
using System.Collections.Generic;
using System.Text;
using JiTU_CS.Data;
using JiTU_CS.Controller;

namespace JiTU_CS.Entity {
    class QuizEntity : BaseEntity {

        #region Constructor/Destructor

        public QuizEntity() {
        }

        ~QuizEntity() {

        }

        #endregion

        #region CRUD

        #region CREATE

        public void CreateQuiz(QuizData theQuiz) {

            theQuiz.Id = NextId;
            if (DataReader != null)
                DataReader.Close();

            SQL = "INSERT INTO `quizzes` (`quiz_id`, `name`, `open_date`, `due_date`) VALUES " +
                "(\"" + theQuiz.Id + "\", \"" + theQuiz.Name + "\", \"" + theQuiz.Open.ToString("yyyy-MM-dd") +
                "\", \"" + theQuiz.Due.ToString("yyyy-MM-dd") + "\");";

            InitializeCommand();


            int result = ExecuteStoredProcedure();

            if (result == 0)
                throw new Exception("Could Not add the quiz to the database");

            QuestionEntity temp = new QuestionEntity();

            for (int i = 0; i < theQuiz.Questions.Count; i++) {

                temp.CreateQuestion(theQuiz.Questions[i]);
                if (DataReader != null)
                    DataReader.Close();

                SQL = "INSERT INTO `rel_quizzes_questions` (`quiz_id`, `question_id`) VALUES (\"" +
                    theQuiz.Id + "\", \"" + theQuiz.Questions[i].Id + "\");";

                InitializeCommand();


                result = ExecuteStoredProcedure();

                if (result == 0)
                    throw new Exception("Cannot associate this question with this quiz");

            }



        }

        public void AddQuestion(QuizData theQuiz, QuestionData theQuestion) {

            if (DataReader != null)
                DataReader.Close();

            SQL = "INSERT INTO `rel_quizzes_questions` (`quiz_id`, `question_id`) VALUES (\"" + theQuiz.Id + "\", \"" + theQuestion.Id + "\");";

            InitializeCommand();

            int result = ExecuteStoredProcedure();

            if (result == 0)
                throw new Exception("Unable to add question to quiz");


        }

        #endregion

        #region READ

        public QuizData ReadQuiz(int id) {
            QuizData return_value = null;

            if (DataReader != null)
                DataReader.Close();

            SQL = "SELECT * FROM `quizzes` q WHERE q.`quiz_id` = \"" + id + "\";";

            InitializeCommand();
            OpenConnection();

            DataReader = Command.ExecuteReader();

            if (DataReader.HasRows) {
                DataReader.Read();
                return_value = new QuizData(DataReader.GetUInt16("quiz_id"));
                return_value.Name = DataReader.GetString("name");
                return_value.Open = DataReader.GetDateTime("open_date");
                return_value.Due = DataReader.GetDateTime("due_date");
            }

            //QuestionEntity temp = new QuestionEntity();

            //return_value.Questions.AddRange(temp.ReadQuestions(return_value));

            CloseConnection();

            if (return_value == null)
                throw new Exception("Could not find specified Quiz");
            
            return return_value;
        }

        public List<QuizData> ReadQuizzes(CourseData theCourse) {

            List<QuizData> return_data = new List<QuizData>();

            if (DataReader != null)
                DataReader.Close();

            SQL = "SELECT r.`quiz_id` FROM `rel_courses_quizzes` r WHERE r.`course_id` = \"" + theCourse.Id + "\";";

            InitializeCommand();
            OpenConnection();

            DataReader = Command.ExecuteReader();

            List<int> temp = new List<int>();

            if (DataReader.HasRows)
                while (DataReader.Read())
                    temp.Add(DataReader.GetInt16("quiz_id"));

            for (int i = 0; i < temp.Count; i++)
                return_data.Add(ReadQuiz(temp[i]));
            
            CloseConnection();

            return return_data;
        }

        #endregion

        #region UPDATE

        public void UpdateQuiz(QuizData theQuiz) {

            QuestionEntity temp = new QuestionEntity();

            for (int i = 0; i < theQuiz.Questions.Count; i++)
            {
                QuestionData questionToSave;
                questionToSave = theQuiz.Questions[i];
                if (questionToSave.Id == 0)
                {
                    temp.CreateQuestion(questionToSave);
                    AddQuestion(theQuiz, questionToSave);

                }
                else
                    temp.UpdateQuestion(questionToSave);
                

            }


            temp.Dispose();

            SQL = "UPDATE `quizzes` q SET q.`name` = \"" + theQuiz.Name + "\", q.`open_date` = \"" + theQuiz.Open.ToString("yyyy-MM-dd") + "\", q.`due_date` = \"" + theQuiz.Due.ToString("yyyy-MM-dd") + "\" WHERE q.`quiz_id` = \"" + theQuiz.Id + "\";";
            InitializeCommand();
            OpenConnection();

            int result = ExecuteStoredProcedure();
            CloseConnection();

            if (result == 0)
                throw new Exception("Unable to update the quiz on the database");

        }

        #endregion

        #region DELETE

        public void DeleteQuiz(QuizData theQuiz) {

            if (DataReader != null)
                DataReader.Close();

            QuestionEntity quest = new QuestionEntity();

            for (int i = 0; i < theQuiz.Questions.Count; i++)
                quest.DeleteQuestion(theQuiz.Questions[i]);

            quest.Dispose();

            SQL = "DELETE `quizzes`, `rel_courses_quizzes` FROM `quizzes` INNER JOIN `rel_courses_quizzes` ON `quizzes`.`quiz_id` = `rel_courses_quizzes`.`quiz_id` WHERE `quizzes`.`quiz_id` = \"" + theQuiz.Id + "\";";
            InitializeCommand();
            OpenConnection();

            int result = ExecuteStoredProcedure();
            CloseConnection();

            if (result == 0)
                throw new Exception("Could not delete the Quiz from Database");

        }

        #endregion

        #endregion

        #region Properties

        public int NextId {
            get {
                int return_data = 0;

                if (DataReader != null)
                    DataReader.Close();

                SQL = "SELECT IFNULL(MAX(quiz_id), 0) FROM quizzes;";

                InitializeCommand();

                DataReader = Command.ExecuteReader();

                if (DataReader.HasRows) {
                    DataReader.Read();
                    return_data = DataReader.GetUInt16("IFNULL(MAX(quiz_id), 0)");
                }

                CloseConnection();

                return_data++;

                return return_data;
            }

        }


        #endregion


    }
}
