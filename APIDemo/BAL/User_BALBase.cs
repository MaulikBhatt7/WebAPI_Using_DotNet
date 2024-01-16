using APIDemo.DAL;
using APIDemo.Models;

namespace APIDemo.BAL
{
    public class User_BALBase 
    {
        public List<UserModel> PR_Select_All_User()
        {
            try
            {
                User_DALBase user_DALBase = new User_DALBase();
                List<UserModel> userModels  = user_DALBase.PR_Select_All_User();
                return userModels;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public UserModel PR_SelectByPK_User(int UserID)
        {
            try
            {
                User_DALBase user_DALBase = new User_DALBase();
                UserModel userModel = user_DALBase.PR_SelectByPK_User(UserID);
                return userModel;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public int PR_Delete_User(int UserID)
        {
            try
            {
                User_DALBase user_DALBase = new User_DALBase();
                int delete = user_DALBase.PR_Delete_User(UserID);
                return delete;

            }
            catch (Exception ex)
            {
                return 2;
            }
        }

        public int PR_Insert_User(UserModel user)
        {
            try
            {
                User_DALBase user_DALBase = new User_DALBase();
                int insert = user_DALBase.PR_Insert_User(user);
                return insert;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int PR_Update_User(UserModel user)
        {
            try
            {
                User_DALBase user_DALBase = new User_DALBase();
                int update = user_DALBase.PR_Update_User(user);
                return update;

            }
            catch (Exception ex)
            {
                return 2;
            }
        }

        public List<UserModel> PR_Filter_User(String Username, String? Email)
        {
            try
            {
                User_DALBase user_DALBase = new User_DALBase();
                List<UserModel> userModels = user_DALBase.PR_Filter_User(Username,Email);
                return userModels;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
