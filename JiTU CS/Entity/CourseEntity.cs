using System;
using System.Collections.Generic;
using System.Text;

using JiTU_CS.Data;

namespace JiTU_CS.Entity {

    class CourseEntity : BaseEntity {

        #region Constructor/Destructor
        public CourseEntity() {

        }

        ~CourseEntity() {
            Connection.Close();
        }
        #endregion

        #region CRUD

        #region CREATE

        /// <summary>
        /// Create c Course on the Database
        /// </summary>
        /// <param name="theCourse">a Course object to create on Database</param>
        public void CreateCourse(CourseData theCourse) {

            theCourse.Id = NextId;

            if (DataReader != null)
                DataReader.Close();

            SQL = "INSERT INTO `courses` (`course_id`, `name`) VALUES (\"" + theCourse.Id + "\", \"" + theCourse.Name + "\");";

            InitializeCommand();
            OpenConnection();

            int result = ExecuteStoredProcedure();

            CloseConnection();

            if (result == 0)
                throw new Exception("Unable to add Course to Database");


        }

        public void AddQuiz(CourseData theCourse, QuizData theQuiz) {

            if (DataReader != null)
                DataReader.Close();

            SQL = "INSERT INTO `rel_courses_quizzes` (`course_id`, `quiz_id`) VALUES (\"" +
                theCourse.Id + "\", \"" +
                theQuiz.Id + "\");";

            InitializeCommand();
            OpenConnection();

            int result = ExecuteStoredProcedure();

            CloseConnection();

            if (result == 0)
                throw new Exception("The Quiz could not be added to the Course");

        }

        public void AddUser(CourseData theCourse, UserData theUser) {

            if (DataReader != null)
                DataReader.Close();

            SQL = "INSERT INTO `rel_courses_users` (`course_id`, `user_id`) VALUES (\"" +
                theCourse.Id + "\", \"" +
                theUser.Id + "\");";

            InitializeCommand();
            OpenConnection();

            int result = ExecuteStoredProcedure();

            CloseConnection();

            if (result == 0)
                throw new Exception("The user could not be added to the course");

        }

        #endregion

        #region READ

        /// <summary>
        /// Read a Course from the Database given a courseID
        /// </summary>
        /// <param name="courseId"> The ID of the course</param>
        /// <returns>A Course object</returns>
        /// 
        public CourseData ReadCourse(int courseId) {

            CourseData return_data = null;

            if (DataReader != null)
                DataReader.Close();

            SQL = "SELECT * FROM `courses` c WHERE c.`course_id` = \"" + courseId + "\";";

            InitializeCommand();
            OpenConnection();

            DataReader = Command.ExecuteReader();

            if (DataReader.HasRows) {
                DataReader.Read();
                return_data = new CourseData(DataReader.GetUInt16("course_id"));
                return_data.Name = DataReader.GetString("name");
            }

            CloseConnection();


            return return_data;
        }

        /// <summary>
        /// Reads a Course from the database given the CourseName
        /// </summary>
        /// <param name="courseName">name of the Course to search</param>
        /// <returns>A Course object</returns>
        /// 
        public CourseData ReadCourse(string courseName) {

            CourseData return_data = null;

            if (DataReader != null)
                DataReader.Close();

            SQL = "SELECT * FROM `courses` c WHERE c.`name` = \"" + courseName + "\";";

            InitializeCommand();
            OpenConnection();

            DataReader = Command.ExecuteReader();

            if (DataReader.HasRows) {
                DataReader.Read();
                return_data = new CourseData(DataReader.GetUInt16("course_id"));
                return_data.Name = DataReader.GetString("name");
            }

            CloseConnection();

            return return_data;
        }

        /// <summary>
        /// Gets a List of courses a given user is enrolled in
        /// </summary>
        /// <param name="theUser">a User object that is being queried</param>
        /// <returns>A List of Course objects</returns>
        public List<CourseData> ReadCourses(UserData theUser) {

            List<CourseData> return_data = new List<CourseData>();

            if (DataReader != null)
                DataReader.Close();

            SQL = "SELECT * FROM `courses` c INNER JOIN `rel_courses_users` r ON r.`course_id` = c.`course_id` WHERE r.`user_id` = \"" + theUser.Id + "\";";

            InitializeCommand();
            OpenConnection();

            DataReader = Command.ExecuteReader();

            if (DataReader.HasRows) {
                while (DataReader.Read()) {
                    CourseData temp = new CourseData(DataReader.GetUInt16("course_id"));
                    temp.Name = DataReader.GetString("name");
                    return_data.Add(temp);
                }
            }
            CloseConnection();

            return return_data;
        }

        #endregion

        #region UPDATE 

        /// <summary>
        /// Update a Course on the Database given the Course data
        /// </summary>
        /// <param name="theCourse">a Course object of the Course to be updated</param>
        public void UpdateCourse(CourseData theCourse) {

            if (DataReader != null)
                DataReader.Close();

            SQL = "UPDATE `courses` c SET c.'name' = \"" + theCourse.Name + "\" WHERE c.`course_id` = \"" + theCourse.Id + "\";";

            InitializeCommand();
            OpenConnection();

            int result = ExecuteStoredProcedure();

            CloseConnection();

            if (result == 0)
                throw new Exception("Unable to update course information");

        }

        #endregion

        #region DELETE

        /// <summary>
        /// Delete a Course from the database
        /// </summary>
        /// <param name="theCourse">a Course object to delete from the Database</param>
        public void DeleteCourse(CourseData theCourse) {

            QuizEntity temp = new QuizEntity();

            List<QuizData> quizzes = temp.ReadQuizzes(theCourse);

            for (int i = 0; i < quizzes.Count; i++)
                temp.DeleteQuiz(quizzes[i]);

            if (DataReader != null)
                DataReader.Close();

            SQL = "DELETE FROM `courses` WHERE `courses`.`course_id` = \"" + theCourse.Id + "\";";

            InitializeCommand();
            OpenConnection();

            int result = ExecuteStoredProcedure();

            CloseConnection();

            if (result == 0)
                throw new Exception("Could not delete Course from the database");

        }

        public void RemoveUser(CourseData theCourse, UserData theUser) {
            if (DataReader != null)
                DataReader.Close();

            SQL = "DELETE FROM `rel_courses_users` WHERE `rel_courses_users`.`course_id` = \"" + theCourse.Id + "\" and `rel_courses_users`.`user_id` = \"" + theUser.Id + "\";";

            InitializeCommand();
            OpenConnection();

            int result = ExecuteStoredProcedure();

            CloseConnection();

            if (result == 0)
                throw new Exception("Unable to remove the user from the course");

        }

        #endregion

        #endregion

        #region Properties

        public int NextId {
            get {
                int return_data = 0;

                if (DataReader != null)
                    DataReader.Close();

                SQL = "SELECT IFNULL(MAX(course_id), 0) FROM courses;";

                InitializeCommand();
                OpenConnection();

                DataReader = Command.ExecuteReader();

                if (DataReader.HasRows)
                    if (DataReader.Read()) 
                        return_data = DataReader.GetUInt16("IFNULL(MAX(course_id), 0)");
                

                CloseConnection();
                return_data++;

                return return_data;
            }
        }

        #endregion

        #region DataMembers 

        const String Primary_Key = "`course_id`";

        String[] Fields = {"`course_id`", "`name`" };

        #endregion

    }
}
