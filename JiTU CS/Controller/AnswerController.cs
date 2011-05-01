using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JiTU_CS.Entity;
using JiTU_CS.Data;

namespace JiTU_CS.Controller
{
	static class AnswerController
	{
		static AnswerEntity entity = new AnswerEntity();

		public static void ValidateAnswer(AnswerData theAnswer)
		{
			return string.IsNullOrEmpty(theAnswer.Text);
		}
	}
}
