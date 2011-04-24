using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JiTU_CS.Data;

namespace JiTU_CS.Entity
{
    class UserEntity : BaseEntity
    {
        #region Methods

        public void addUser (UserData userData)
        {
            try
            {
                this.SQL = "INSERT INTO `users` (`user_name`, `full_name`, `role_id`, `password) " +
                    "VALUES (\"" + userData.UserName + "\", \"" + userData.FullName + "\", " + userData.Role + ", \"" + userData.Password + "\");";
                this.InitializeCommand();
                this.OpenConnection();

                if (this.ExecuteStoredProcedure() == 0)
                    throw new Exception("Unable to add the user to the database.");

            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message, e.InnerException);
            }
            finally
            {
                this.CloseConnectioin();
            }
        }

        public void updateUser(UserData userData)
        {
            try
            {
                this.SQL = "UPDATE `users` u SET " +
                    "u.`user_name` = \"" + userData.UserName + "\", " +
                    "u.`full_name` = \"" + userData.FullName + "\", " +
                    "u.`role_id` = \"" + userData.Role + "\", " +
                    "u.`password` = \"" + userData.Password + "\" " +
                    "WHERE u.`user_id` = " + userData.ID + ";";


                if (this.ExecuteStoredProcedure() == 0)
                    throw new Exception("Unable to update the user's data.");

            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message, e.InnerException);
            }
            finally
            {
                this.CloseConnectioin();
            }
        }

        public void deleteUser(UserData userData)
        {
            try
            {
                this.SQL = "DELETE FROM `users` WHERE `user_id` = " + userData.ID + ";";
            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message, e.InnerException);
            }
            finally
            {
                this.CloseConnectioin();
            }
        }

        public UserData getUser(string userName)
        {
            UserData newUser = null;

            try
            {

                this.SQL = "SELECT * FROM `users` u WHERE u.`user_name` = \"" + userName + "\";";
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
                this.CloseConnectioin();
            }

            return newUser;
        }

        public UserData getUser(int userID)
        {
            UserData newUser = null;

            try
            {

                this.SQL = "SELECT * FROM `users` u WHERE u.`user_id` = \"" + userID + ";";
                this.InitializeCommand();
                this.OpenConnection();

                this.DataReader = this.Command.ExecuteReader();

                if (this.DataReader.HasRows)
                {
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
                this.CloseConnectioin();
            }

            return newUser;
        }

        #endregion
    }
}
