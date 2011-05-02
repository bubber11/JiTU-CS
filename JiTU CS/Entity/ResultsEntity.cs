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
				this.SQL = "INSERT INTO `rel_answers_users` (`answer_id`, `user_id`) VALUES ";

				this.SQL += "(" + theResults.Student.Id + ", " + theResults.Answers[0].Id + ")";

                for (int index = 1; index < theResults.Answers.Count;  index++)
                    this.SQL += ", (" + theResults.Student.Id + ", " + theResults.Answers[index].Id + ")";

				this.InitializeCommand();

                int result = ExecuteStoredProcedure();

				if (result == 0)
					throw new System.Exception("Unable to save the user's answers.");

                SQL = "INSERT INTO `rel_quizzes_users` (`quiz_id`, `user_id`) VALUES (\"";



			}
			catch (System.Exception e)
			{
				throw new System.Exception(e.Message, e.InnerException);
			}
			finally
			{

			}
		}
	
	}
}
