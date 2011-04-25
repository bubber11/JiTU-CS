using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JiTU_CS.Data
{
    public class UserData
    {
        public enum Roles{Instructor = 1, Student = 2};

        #region Variables


        private int myID;
        private string myUserName;
        private string myPassword;
        private string myFullName;
        private Roles myRole;

        #endregion

        #region Properties
        
        public int ID
        {
            get
            {
                return myID;
            }
        }

        public string UserName
        {
            get
            {
                return myUserName;
            }
            set
            {
                myUserName = value;
            }
        }

        public string Password
        {
            get
            {
                return myPassword;
            }
            set
            {
                myPassword = value;
            }
        }

        public string FullName
        {
            get
            {
                return myFullName;
            }
            set
            {
                myFullName = value;
            }
        }

        public Roles Role
        {
            get
            {
                return myRole;
            }
            set
            {
                myRole = value;
            }

        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Creates UserData with ID = 0
        /// </summary>
        public UserData()
        {
            myID = 0;
        }

        /// <summary>
        /// Creates UserData with specified ID
        /// </summary>
        /// <param name="ID">ID of the User</param>
        public UserData(int ID)
        {
            myID = ID;
        }

        #endregion
    }
}
