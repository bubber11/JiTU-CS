using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JiTU_CS
{
    static class GlobalData
    {
        public static UI.Screens.BaseScreen currentScreen;
        
        /// <summary>
        /// represents the current logged in user
        /// </summary>
        public static Data.UserData currentUser;

        public static Data.CourseData currentCourse;
        public static Data.QuizData currentQuiz;
    }
}
