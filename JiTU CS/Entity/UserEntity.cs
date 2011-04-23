using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JiTU_CS.Data;

namespace JiTU_CS.Entity
{
    class UserEntity : BaseEntity
    {
        public void addUser (UserData userData)
        {
            try
            {

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
            try
            {

            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message, e.InnerException);
            }
            finally
            {
                this.CloseConnectioin();
            }

            return null;
        }

        public UserData getUser(int userID)
        {
            try
            {

            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message, e.InnerException);
            }
            finally
            {
                this.CloseConnectioin();
            }

            return null;
        }

         
    }
}
