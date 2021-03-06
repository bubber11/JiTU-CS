﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

using JiTU_CS.Entity;
using JiTU_CS.Data;

namespace JiTU_CS.Controller
{
    static class UserController
    {
        #region Members

        static UserEntity userEntity = new UserEntity();

        #endregion

        #region Methods

        /// <summary>
        /// returns a user based on user name
        /// </summary>
        /// <param name="UserName">the user name to search for</param>
        /// <returns>user found in database with the specified user name</returns>
        public static UserData GetUser(string userName)
        {
            return userEntity.getUser(userName);
        }

        /// <summary>
        /// Checks to see if the user has inputed a password matching the user
        /// </summary>
        /// <param name="theUser">the user trying to log in</param>
        /// <param name="Password">the password of the user</param>
        /// <returns></returns>
        public static bool AuthenticateUser(UserData theUser, string Password)
        {
            SHA1 MyHasher = new SHA1CryptoServiceProvider();
            byte[] result = MyHasher.ComputeHash(Encoding.Default.GetBytes(Password));
            
            StringBuilder HexString = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
                HexString.Append(result[i].ToString("x2"));

            return (HexString.ToString().ToUpper() == theUser.Password.ToUpper());
        }

        /// <summary>
        /// Saves a user
        /// </summary>
        /// <param name="theUser">User to be saved</param>
        public static void SaveUser(UserData theUser)
        {
			try
			{
				if (theUser.Id == 0)
					userEntity.addUser(theUser);
				else
					userEntity.updateUser(theUser);

			}
			catch (System.Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.Message);
			}
        }

        /// <summary>
        /// gets the list of all students in the database
        /// </summary>
        /// <returns>list of all students</returns>
        public static List<UserData> GetStudents()
        {
            return userEntity.GetStudents();
        }

        /// <summary>
        /// gets the list of all students in a specified course
        /// </summary>
        /// <param name="course">the course to search in</param>
        /// <returns>list of student in the course</returns>
        public static List<UserData> GetStudents(CourseData course)
        {
            return userEntity.GetStudentsByCourse(course.Id);
        }

        /// <summary>
        /// deletes a specified user from the database
        /// </summary>
        /// <param name="theUser">user to delete</param>
        public static void DeleteUser(UserData theUser)
        {
            userEntity.deleteUser(theUser);
        }

        #endregion
    }
}
