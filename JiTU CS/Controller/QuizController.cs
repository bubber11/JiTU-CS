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

        public static List<QuizData> GetQuizzes(CourseData course)
        {
            // TODO replace with entity retrieving

            List<QuizData> quizzes = new List<QuizData>();
            QuizData quiz = new QuizData();
            quiz.Name = "My New Quiz";

            quizzes.Add(quiz);
            return quizzes;
        }

        public static void DeleteQuiz(QuizData quiz)
        {
            // TODO add code to remove quiz from database
            
        }

        public static void SaveQuiz(QuizData quiz)
        {
            // TODO add code to add quiz to database
        }

        public static void GetQuestions(QuizData quiz)
        {
            //TODO replace code to get questions from database

            quiz.questions.Clear();

            QuestionData newQuestion = new QuestionData(0);
            AnswerData correctAnswer = new AnswerData(0);
            AnswerData wrongAnswer = new AnswerData(0);
            correctAnswer.correct = true;
            correctAnswer.text = "This is the correct answer";
            wrongAnswer.text = "This is a wrong answer";

            newQuestion.Text = "This is a question";

            newQuestion.answers.Add(correctAnswer);
            newQuestion.answers.Add(wrongAnswer);
            newQuestion.answers.Add(wrongAnswer);
            newQuestion.answers.Add(wrongAnswer);

            for (int i = 0; i < 10; i++)
            {
                quiz.questions.Add(newQuestion);
            }
        }

    }
}
