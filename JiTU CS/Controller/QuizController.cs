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
            if (quiz.Id == 0)
            {
                entity.CreateQuiz(quiz);
            }
            else
            {
                entity.UpdateQuiz(quiz);
            }
        }

    }
}
