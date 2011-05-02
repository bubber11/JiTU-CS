using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JiTU_CS.Data;
using System.Data;

namespace JiTU_CS.Entity
{
	class ResultsEntity : BaseEntity
	{

        public ResultsEntity() {
            if (Connection == null)
                OpenConnection();

        }

		/// <summary>
		/// Gets the number of correct answers for a question
		/// </summary>
		/// <param name="theQuestion"></param>
		/// <returns></returns>
		public int CountCorrect(QuestionData theQuestion)
		{
			try
			{
				this.SQL = "SELECT COUNT(ra.`user_id`) AS `CountCorrect` FROM `questions` q " +
					"JOIN `rel_questions_answers` qa ON q.`question_id` = qa.`question_id` " +
					"JOIN `answers` a ON qa.`answer_id` = a.`answer_id` " +
					"JOIN `rel_answers_users` ra ON a.`answer_id` = ra.`answer_id` " +
					"WHERE a.`is_correct` = 1 AND q.`question_id` = " + theQuestion.Id + " " +
					"GROUP BY q.`question_id`;";
				this.InitializeCommand();
                OpenConnection();

				this.DataReader = this.Command.ExecuteReader();

				if (this.DataReader.HasRows)
				{
					this.DataReader.Read();
					return (int)this.DataReader[0];
				}
				else
					return 0;
			}
			catch (System.Exception e)
			{
				throw new System.Exception(e.Message, e.InnerException);
			}
			finally
			{

			}
		}

		/// <summary>
		/// Gets the number of correct answers for each question with in a quiz.
		/// </summary>
		/// <param name="theQuiz"></param>
		/// <returns></returns>
		public DataTable CountCorrect(QuizData theQuiz)
		{
			DataTable myTable = new DataTable();
			myTable.Columns.Add("Question", typeof(QuestionData));
			myTable.Columns.Add("Count", typeof(int));

			DataRow myNewRow;

			foreach (QuestionData theQuestion in theQuiz.Questions)
			{
				myNewRow = myTable.NewRow();
				myNewRow[0] = theQuestion;
				myNewRow[1] = CountCorrect(theQuestion);
			}
			
			return myTable;
		}

		/// <summary>
		/// Gets the number of wrong answers for a question
		/// </summary>
		/// <param name="theQuestion"></param>
		/// <returns></returns>
		public int CountWrong(QuestionData theQuestion)
		{
			try
			{
				this.SQL = "SELECT COUNT(ra.`user_id`) AS `CountCorrect` FROM `questions` q " +
					"JOIN `rel_questions_answers` qa ON q.`question_id` = qa.`question_id` " +
					"JOIN `answers` a ON qa.`answer_id` = a.`answer_id` " +
					"JOIN `rel_answers_users` ra ON a.`answer_id` = ra.`answer_id` " +
					"WHERE a.`is_correct` = 0 AND q.`question_id` = " + theQuestion.Id + " " +
					"GROUP BY q.`question_id`;";
				this.InitializeCommand();


				this.DataReader = this.Command.ExecuteReader();

				if (this.DataReader.HasRows)
				{
					this.DataReader.Read();
					return (int)this.DataReader[0];
				}
				else
					return 0;
			}
			catch (System.Exception e)
			{
				throw new System.Exception(e.Message, e.InnerException);
			}
			finally
			{

			}
		}

		/// <summary>
		/// Gets the number of correct answers for each question with in a quiz.
		/// </summary>
		/// <param name="theQuiz"></param>
		/// <returns></returns>
		public DataTable CountWrong(QuizData theQuiz)
		{
			DataTable myTable = new DataTable();
			myTable.Columns.Add("Question", typeof(QuestionData));
			myTable.Columns.Add("Count", typeof(int));

			DataRow myNewRow;

			foreach (QuestionData theQuestion in theQuiz.Questions)
			{
				myNewRow = myTable.NewRow();
				myNewRow[0] = theQuestion;
				myNewRow[1] = CountWrong(theQuestion);
			}

			return myTable;
		}

		/// <summary>
		/// Writes the result of the quiz to the database
		/// </summary>
		/// <param name="theResults"></param>
		public void AddResult(ResultData theResults)
		{
			try
			{
				this.SQL = "INSERT INTO `rel_answers_users` (`user_id`, `answer_id`) VALUES ";

				this.SQL += "(\"" + theResults.Student.Id + "\", \"" + theResults.Answers[0].Id + "\")";

                for (int index = 1; index < theResults.Answers.Count - 1;  index++)
                    this.SQL += ", (\"" + theResults.Student.Id + "\", \"" + theResults.Answers[index].Id + "\")";

                SQL += ", (\"" + theResults.Student.Id + "\", \"" + theResults.Answers[theResults.Answers.Count - 1].Id + "\");";

				this.InitializeCommand();
                OpenConnection();

                int result = ExecuteStoredProcedure();

				if (result == 0)
					throw new System.Exception("Unable to save the user's answers.");

                if (DataReader != null)
                    DataReader.Close();

                SQL = "INSERT INTO `rel_quizzes_users` (`quiz_id`, `user_id`) VALUES (\"" + theResults.Quiz.Id + "\", \"" + theResults.Student.Id + "\");";
                InitializeCommand();

                result = ExecuteStoredProcedure();

                CloseConnection();

                if (result == 0)
                    throw new Exception("Unable to save the user\'s answers");





			}
			catch (System.Exception e)
			{
				throw new System.Exception(e.Message, e.InnerException);
			}
			finally
			{

			}
		}


        public double StudentResults(UserData theUser, QuizData theQuiz) {
            double return_val = 100.00;

            int quest_count;
            int correct_count;

            if (DataReader != null)
                DataReader.Close();

            SQL = "SELECT IFNULL(COUNT(`question_id`), 0) FROM `rel_quizzes_questions` WHERE `rel_quizzes_questions`.`quiz_id` = \"" + theQuiz.Id + "\";";

            InitializeCommand();
            OpenConnection();
            DataReader = Command.ExecuteReader();
            DataReader.Read();
            quest_count = DataReader.GetUInt16("IFNULL(COUNT(`question_id`), 0)");
            
            if (DataReader != null)
                DataReader.Close();

            SQL = "SELECT IFNULL(COUNT(r.`question_id`), 0) FROM `rel_quizzes_questions` r INNER JOIN `questions` q on q.`question_id` = r.`question_id` INNER JOIN `rel_questions_answers` s ON s.`question_id` = q.`question_id` INNER JOIN `answers` a ON a.`answer_id` = s.`answer_id` INNER JOIN `rel_answers_users` t ON t.`answer_id` = a.`answer_id` WHERE r.`quiz_id` = \"" + theQuiz.Id + "\" and a.`is_correct` = \"1\" and t.`user_id` = \"" + theUser.Id + "\";";

            InitializeCommand();

            DataReader = Command.ExecuteReader();
            DataReader.Read();

            correct_count = DataReader.GetUInt16("IFNULL(COUNT(r.`question_id`), 0)");

            if (DataReader != null)
                DataReader.Close();

            if (correct_count == 0)
                return_val = 0;

            else {
                if (quest_count == 0)
                    return_val = 0;
                else
                    return_val = ((double)correct_count / (double)quest_count) * 100.00;
            }
            CloseConnection();

            return return_val;
        }

	}
}
