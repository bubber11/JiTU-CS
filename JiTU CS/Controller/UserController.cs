using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
