﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

using JiTU_CS.Data;

namespace JiTU_CS.Entity
{
    class UserEntity : BaseEntity
    {
        #region Methods

        /// <summary>
        /// Adds the user data to the database
        /// </summary>
        /// <param name="userData"></param>
        public void addUser (UserData userData)
        {
            try
            {
				SHA1 MyHasher = new SHA1CryptoServiceProvider();
				byte[] result = MyHasher.ComputeHash(Encoding.Default.GetBytes(userData.Password));

				StringBuilder HexString = new StringBuilder();

				for (int i = 0; i < result.Length; i++)
					HexString.Append(result[i].ToString("x2"));


                this.SQL = "INSERT INTO `users` (`user_name`, `full_name`, `role_id`, `password`) " +
                    "VALUES (\"" + userData.UserName + "\", \"" + userData.FullName + "\", " + (int)userData.Role + ", \"" + HexString.ToString().ToUpper() + "\");";
                this.InitializeCommand();
                this.OpenConnection();

				if (this.ExecuteStoredProcedure() == 0)
					throw new Exception("Unable to add the user to the database.");
				else
				{
					this.SQL = "SELECT MAX(u.`user_id`) FROM `users` u;";
					this.InitializeCommand();

					this.DataReader = this.Command.ExecuteReader();

					if (this.DataReader.HasRows)
					{
						this.DataReader.Read();

						userData.Id = this.DataReader.GetInt32(0);
					}
				}

            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message, e.InnerException);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Updated the user data in the database
        /// </summary>
        /// <param name="userData"></param>
        public void updateUser(UserData userData)
        {
			SHA1 MyHasher = new SHA1CryptoServiceProvider();
			byte[] result = MyHasher.ComputeHash(Encoding.Default.GetBytes(userData.Password));

			StringBuilder HexString = new StringBuilder();

			for (int i = 0; i < result.Length; i++)
				HexString.Append(result[i].ToString("X2"));
 
           
            DataReader.Close();
            this.SQL = "UPDATE `users` u SET " +
                "u.`user_name` = \"" + userData.UserName + "\", " +
                "u.`full_name` = \"" + userData.FullName + "\", " +
                "u.`role_id` = \"" + (int)userData.Role + "\", " +
                "u.`password` = \"" + HexString.ToString() + "\" " +
                "WHERE u.`user_id` = " + userData.Id + ";";

            InitializeCommand();
            OpenConnection();

			if (ExecuteStoredProcedure() == 0)
                throw new Exception("Unable to update User Data");


			CloseConnection();
			DataReader.Close();

        }

        /// <summary>
        /// Deletes the given user from the database
        /// </summary>
        /// <param name="userData"></param>
        public void deleteUser(UserData userData)
        {
            try
            {
                this.SQL = "DELETE FROM `users` WHERE `user_id` = " + userData.Id + ";";
				this.InitializeCommand();
				this.OpenConnection();

				if (this.ExecuteStoredProcedure() == 0)
					throw new System.Exception("Unable to delete the user.");

            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message, e.InnerException);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Gets a UserData object based on the user's name
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public UserData getUser(string userName)
        {
            UserData newUser = null;

            try
            {

                this.SQL = "SELECT * FROM users u WHERE u.user_name = \"" + userName + "\";";
                this.InitializeCommand();
                this.OpenConnection();

                this.DataReader = this.Command.ExecuteReader();

                if (this.DataReader.HasRows)
                {
                    this.DataReader.Read();
                    newUser = new UserData(this.DataReader.GetInt32("user_id"));
                    newUser.FullName = this.DataReader.GetString("full_name");
                    newUser.Password = this.DataReader.GetString("password");
                    newUser.Role = (UserData.Roles) this.DataReader.GetInt32("role_id");
                    newUser.UserName = this.DataReader.GetString("user_name");
                }
                else
                    throw new Exception("Unable find user with user name \"" + userName + "\".");
            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message, e.InnerException);
            }
            finally
            {
                this.CloseConnection();
            }

            return newUser;
        }

        /// <summary>
        /// Gets a UserData object based on the user's ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public UserData getUser(int userID)
        {
            UserData newUser = null;

            try
            {

                this.SQL = "SELECT * FROM users u WHERE u.user_id = \"" + userID + "\";";
                this.InitializeCommand();
                this.OpenConnection();

                this.DataReader = this.Command.ExecuteReader();

                if (this.DataReader.HasRows)
                {
                    DataReader.Read();
                    newUser = new UserData(this.DataReader.GetInt32("user_id"));
                    newUser.FullName = this.DataReader.GetString("full_name");
                    newUser.Password = this.DataReader.GetString("password");
                    newUser.Role = (UserData.Roles)this.DataReader.GetInt32("role_id");
                    newUser.UserName = this.DataReader.GetString("user_name");
                }
                else
                    throw new Exception("Unable find user with user ID \"" + userID + "\".");
            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message, e.InnerException);
            }
            finally
            {
                this.CloseConnection();
            }

            return newUser;
        }


        /// <summary>
        /// Checks to see if the user has taken the given test
        /// </summary>
        /// <param name="theUser"></param>
        /// <param name="theQuiz"></param>
        /// <returns></returns>
        public bool TestTaken(UserData theUser, QuizData theQuiz) {
            bool return_val = false;

            if (DataReader != null)
                DataReader.Close();

            SQL = "select IFNULL(COUNT(`user_id`), 0) FROM `rel_quizzes_users` r WHERE r.`user_id` = \"" + theUser.Id + "\" and r.`quiz_id` = \"" + theQuiz.Id + "\";";
            InitializeCommand();
            OpenConnection();

            DataReader = Command.ExecuteReader();

            DataReader.Read();
            return_val = DataReader.GetUInt16("IFNULL(COUNT(`user_id`), 0)") == 1;
            CloseConnection();

            return return_val;
        }


        /// <summary>
        /// Gets a list of UserData objects representing all students currently in the database
        /// </summary>
        /// <returns></returns>
        public List<UserData> GetStudents()
        {

            List<UserData> theList = new List<UserData>();

            try
            {
                this.SQL = "SELECT * FROM `users` u WHERE u.role_id = 2;";
                this.InitializeCommand();
                this.OpenConnection();

                this.DataReader = this.Command.ExecuteReader();

                if (this.DataReader.HasRows)
                {
                    UserData newUser;

                    while (this.DataReader.Read())
                    {
                        newUser = new UserData(this.DataReader.GetInt32("user_id"));
                        newUser.FullName = this.DataReader.GetString("full_name");
                        newUser.Password = this.DataReader.GetString("password");
                        newUser.Role = (UserData.Roles)this.DataReader.GetInt32("role_id");
                        newUser.UserName = this.DataReader.GetString("user_name");

                        theList.Add(newUser);
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                this.CloseConnection();
            }

            return theList;
        }

        /// <summary>
        /// Gets a list of UserData objects representing the students enrolled in a particular course
        /// </summary>
        /// <param name="CourseID"></param>
        /// <returns></returns>
        public List<UserData> GetStudentsByCourse(int CourseID)
        {
            List<UserData> theList = new List<UserData>();

            try
            {
                this.SQL = "SELECT u.* FROM `users` u JOIN `rel_courses_users` uc ON u.`user_id` = uc.`user_id` " +
                    "WHERE u.`role_id` = 2 AND uc.`course_id` = " + CourseID + ";";
                this.InitializeCommand();
                this.OpenConnection();

                this.DataReader = this.Command.ExecuteReader();

                if (this.DataReader.HasRows)
                {
                    UserData newUser;

                    while (this.DataReader.Read())
                    {
                        newUser = new UserData(this.DataReader.GetInt32("user_id"));
                        newUser.FullName = this.DataReader.GetString("full_name");
                        newUser.Password = this.DataReader.GetString("password");
                        newUser.Role = (UserData.Roles)this.DataReader.GetInt32("role_id");
                        newUser.UserName = this.DataReader.GetString("user_name");

                        theList.Add(newUser);
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                this.CloseConnection();
            }

            return theList;
        }

        #endregion
    }
}
