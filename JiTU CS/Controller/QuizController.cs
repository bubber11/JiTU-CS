using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JiTU_CS.Data;
using JiTU_CS.Entity;

namespace JiTU_CS.Controller
{
    static class QuizController
    {
        static QuizEntity entity = new QuizEntity();

        /// <summary>
        /// gets a list of all the quizzes associated with a course from the database
        /// through the quiz entity
        /// </summary>
        /// <param name="course">course to get quizzes in</param>
        /// <returns></returns>
        public static List<QuizData> GetQuizzes(CourseData course)
        {
            return entity.ReadQuizzes(course);
        }

        /// <summary>
        /// deletes a quiz from the database using the quiz entity
        /// </summary>
        /// <param name="quiz">the quiz to be removed</param>
        public static void DeleteQuiz(QuizData quiz)
        {
            entity.DeleteQuiz(quiz);
            
        }

        /// <summary>
        /// saves a quiz
        /// </summary>
        /// <param name="quiz"></param>
        public static void SaveQuiz(QuizData quiz)
        {
			try
			{
				if (quiz.Id == 0)
				{
					entity.CreateQuiz(quiz);
				}
				else
				{
					entity.UpdateQuiz(quiz);
				}
			}
			catch (System.Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.Message);
			}
        }

        /// <summary>
        /// validates data and if good saves it
        /// </summary>
        /// <param name="quiz">quiz to submit</param>
        /// <exception cref="Exception">data not correct.</exception>
        public static void SubmitQuiz(QuizData quiz)
        {
            //Validate data
            if (quiz.Due < quiz.Open)
                throw new Exception("The due date must be after the open date.");

            if (quiz.Questions.Count == 0)
                throw new Exception("The quiz must contain at least one question.");

            // TODO validate questions

            //Now that we validated save the quiz
            SaveQuiz(quiz);
        }
    }
}
