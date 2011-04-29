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

        public static void GetQuestions(QuizData quiz)
        {
            //TODO replace code to get questions from database

            quiz.Questions.Clear();

            QuestionData newQuestion = new QuestionData(0);
            AnswerData correctAnswer = new AnswerData(0);
            AnswerData wrongAnswer = new AnswerData(0);
            correctAnswer.Correct = true;
            correctAnswer.Text = "This is the correct answer";
            wrongAnswer.Text = "This is a wrong answer";

            newQuestion.Text = "This is a question";

            newQuestion.Answers.Add(correctAnswer);
            newQuestion.Answers.Add(wrongAnswer);
            newQuestion.Answers.Add(wrongAnswer);
            newQuestion.Answers.Add(wrongAnswer);

            for (int i = 0; i < 10; i++)
            {
                quiz.Questions.Add(newQuestion);
            }
        }

    }
}
