using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

using JiTU_CS.Entity;
using JiTU_CS.Data;

namespace JiTU_CS.Controller
{
    class UserController
    {
        #region Methods

        /// <summary>
        /// returns a user based on user name
        /// </summary>
        /// <param name="UserName">the user name to search for</param>
        /// <returns>user found in database with the specified user name</returns>
        public UserData getUser(string UserName)
        {
            UserEntity userEntity = new UserEntity();
            return userEntity.getUser(UserName);
        }

        /// <summary>
        /// Checks to see if the user has inputed a password matching the user
        /// </summary>
        /// <param name="theUser">the user trying to log in</param>
        /// <param name="Password">the password of the user</param>
        /// <returns></returns>
        public bool AuthenticateUser(UserData theUser, string Password)
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
        public void SaveUser(UserData theUser)
        {
            UserEntity userEntity = new UserEntity();

            if (theUser.ID > 0)
                userEntity.addUser(theUser);
            else
                userEntity.updateUser(theUser);
        }

        #endregion
    }
}
