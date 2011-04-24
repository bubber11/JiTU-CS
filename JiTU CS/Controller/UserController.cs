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
        public UserData getUser(string UserName)
        {
            UserEntity userEntity = new UserEntity();
            return userEntity.getUser(UserName);
        }

        public bool AuthenticateUser(UserData theUser, string Password)
        {
            SHA1 MyHasher = new SHA1CryptoServiceProvider();
            byte[] result = MyHasher.ComputeHash(Encoding.Default.GetBytes(Password));
            
            StringBuilder HexString = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
                HexString.Append(result[i].ToString("x2"));

            return (HexString.ToString().ToUpper() == theUser.Password.ToUpper());
        }

        public void SaveUser(UserData theUser)
        {
            UserEntity userEntity = new UserEntity();

            if (theUser.ID > 0)
                userEntity.addUser(theUser);
            else
                userEntity.updateUser(theUser);
        }
    }
}
