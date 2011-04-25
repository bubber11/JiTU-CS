using System;
using System.Collections.Generic;
using System.Text;

using JiTU_CS.Data;

namespace JiTU_CS.Entity {
    class CourseEntity : BaseEntity {


        #region constructor
        public CourseEntity() {

        }
        #endregion

        #region destructor
        ~CourseEntity() {
            Connection.Close();
        }
        #endregion

        #region functions

        /// <summary>
        /// Get a Course from corresponding ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CourseData getCourse(int id) {
             CourseData return_value = null;
             this.SQL = "SELECT * FROM courses c WHERE c.course_id = \"" + id + "\";";
             this.InitializeCommand();
             this.OpenConnection();

             try {
                 this.DataReader = Command.ExecuteReader();

                 if (DataReader.HasRows) {
                     this.DataReader.Read();

                     return_value = new CourseData(DataReader.GetUInt16("course_id"));
                     return_value.name = DataReader.GetString("name");

                 } else
                     throw new Exception(JiTU_CS.GlobalData.currentUser.FullName + " is not enrolled in any classes.");


             } catch (Exception e) {
                 throw new Exception(e.Message);
             } finally {
                 CloseConnection();
             }
            

             return return_value;
         }

         /// <summary>
        /// 
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns></returns>
        public CourseData getCourse(String courseName) {
             CourseData return_value = null;

             SQL = "SELECT * FROM courses c WHERE c.name = \"" + courseName + "\";";
             InitializeCommand();
             OpenConnection();

             try {
                 DataReader = Command.ExecuteReader();

                 if (DataReader.HasRows) {
                     DataReader.Read();

                     return_value = new CourseData(DataReader.GetInt32("course_id"));
                     return_value.name = DataReader.GetString("name");

                 } else
                     throw new Exception(JiTU_CS.GlobalData.currentUser.FullName + " is not enrolled in any classes");

             } catch (Exception e) {
                 throw new Exception(e.Message, e.InnerException);
             } finally {
                 CloseConnection();
             }

             return return_value;
        }

        public List<CourseData> getCourses(UserData theUser) {
            
            List<CourseData> return_value = new List<CourseData>();
            SQL = "SELECT * FROM courses c INNER JOIN rel_courses_users r ON r.course_id = c.course_id WHERE r.user_id = \"" + theUser.ID + "\";";
            InitializeCommand();
            OpenConnection();
            DataReader = Command.ExecuteReader();

            if (DataReader.HasRows) {

                while (DataReader.Read()) {
                    CourseData temp = new CourseData(DataReader.GetUInt16("course_id"));
                    temp.name = DataReader.GetString("name");
                    return_value.Add(temp);
                }
            }
            return return_value;
        }

        public void addCourse(Data.CourseData theCourse) {
            SQL = "INSERT INTO courses (name) VALUES (\"" + theCourse.name + "\");";
            InitializeCommand();
            OpenConnection();
            try {

                if (ExecuteStoredProcedure() == 0)
                    throw new Exception("Unable add course to Database");

                CloseConnection();
            } catch (Exception e) {  
                CloseConnection();
                throw e;
            }

        }

        public void updateCourse(Data.CourseData theCourse) {
           
            DataReader.Close();

            SQL = "UPDATE courses c SET c.name = \"" + theCourse.name + "\" WHERE c.course_id = \"" + theCourse.id + "\";";
            InitializeCommand();
            OpenConnection();
            int result = ExecuteStoredProcedure();
            CloseConnection();

            if (result == 0)
                throw new Exception("Could Not update Course Information");
           
            
        }

        public void deleteCourse(Data.CourseData theCourse) {
            DataReader.Close();
            SQL = "DELETE FROM courses WHERE courses.course_id = \"" + theCourse.id + "\";";
            InitializeCommand();
            OpenConnection();
            int result = ExecuteStoredProcedure();
            CloseConnection();
            if (result == 0)
                throw new Exception("Could Not Delete Course from Database");

        }

        #endregion

        #region properties

        public int CourseCount {
             get {
                 int count = 0;
                 this.SQL = "SELECT COUNT(*) FROM courses c INNER JOIN rel_courses_users r on r.course_id = c.course_id WHERE r.user_id = \"" + GlobalData.currentUser.ID + "\";";
                 this.InitializeCommand();
                 this.OpenConnection();
                 this.DataReader = this.Command.ExecuteReader();
                 this.DataReader.Read();
                 count = this.DataReader.GetUInt16("COUNT(*)");
                 this.CloseConnection();
                 return count;
             }



         }

        #endregion
    }
}
