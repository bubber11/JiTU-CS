using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using JiTU_CS.Data;
using JiTU_CS.Entity;

namespace JiTU_CS.Controller
{
	static class ResultsController
	{
		static ResultsEntity theEntity = new ResultsEntity();

		public static int GetCorrectCount(QuestionData theQuestion)
		{
			return theEntity.CountCorrect(theQuestion);
		}

		public static int GetWrongCount(QuestionData theQuestion)
		{
			return theEntity.CountWrong(theQuestion);
		}

		public static DataTable GetCorrectCount(QuizData theQuiz)
		{
			return theEntity.CountCorrect(theQuiz);
		}

		public static DataTable GetWrongCount(QuizData theQuiz)
		{
			return theEntity.CountWrong(theQuiz);
		}

        public static double GetStudentPercentage(UserData student, QuizData quiz)
        {
            return theEntity.StudentResults(student, quiz);
        }

		public static void SaveResults(ResultData theResults)
		{
			if (theResults.Answers.Count == 0)
				System.Windows.Forms.MessageBox.Show("There are no answers to save.", "JiTU", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
			else
				if (theResults.Student.Id == 0)
					System.Windows.Forms.MessageBox.Show("The user id is invalid.", "JiTU", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				else
					theEntity.AddResult(theResults);
		}
	}
}
