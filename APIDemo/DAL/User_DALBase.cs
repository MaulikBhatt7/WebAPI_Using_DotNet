using APIDemo.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;

namespace APIDemo.DAL
{
    public class User_DALBase : DAL_Helpers
    {
        #region PR_Select_All_User()

        public List<UserModel> PR_Select_All_User()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_ALL_Person");
              
                List<UserModel> userModels = new List<UserModel>();
                using(IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        UserModel userModel = new UserModel();
                        userModel.PersonID = int.Parse(dr["PersonID"].ToString());
                        userModel.PersonName = dr["PersonName"].ToString();
                        userModel.Contact = dr["Contact"].ToString();
                        userModel.Email = dr["Email"].ToString();
                        userModels.Add(userModel);
                    }
                }
                return userModels;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_SelectByPK_User()

        public UserModel PR_SelectByPK_User(int UserID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Person_SelectByPK");
                sqlDatabase.AddInParameter(dbCommand, "PersonID", DbType.Int64, UserID);
                UserModel userModel = new UserModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                
                        userModel.PersonID = int.Parse(dr["PersonID"].ToString());
                        userModel.PersonName = dr["PersonName"].ToString();
                        userModel.Contact = dr["Contact"].ToString();
                        userModel.Email = dr["Email"].ToString();
                        
                    }
                }
                return userModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_Delete_User()

        public int PR_Delete_User(int UserID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_MST_Person_Delete");
                sqlDatabase.AddInParameter(dbCommand, "PersonID", DbType.Int64, UserID);
                return sqlDatabase.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                return 2;
            }
        }
        #endregion

        #region PR_Insert_User()

        public int PR_Insert_User(UserModel user)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Person_Insert");
                sqlDatabase.AddInParameter(dbCommand, "PersonName", DbType.String, user.PersonName);
                sqlDatabase.AddInParameter(dbCommand, "Contact", DbType.String, user.Contact);
                sqlDatabase.AddInParameter(dbCommand, "Email", DbType.String, user.Email);
                
                return sqlDatabase.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                return 2;
            }
        }
        #endregion

        #region PR_Update_User()

        public int PR_Update_User(UserModel user)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Person_Update");
                sqlDatabase.AddInParameter(dbCommand, "PersonID", DbType.Int64, user.PersonID);
                sqlDatabase.AddInParameter(dbCommand, "PersonName", DbType.String, user.PersonName);
                sqlDatabase.AddInParameter(dbCommand, "Contact", DbType.String, user.Contact);
                sqlDatabase.AddInParameter(dbCommand, "Email", DbType.String, user.Email);

                return sqlDatabase.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                return 2;
            }
        }
        #endregion

        #region PR_Filter_User()

        public List<UserModel> PR_Filter_User(String Username,String? Email)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Person_Filter");
                sqlDatabase.AddInParameter(dbCommand, "PersonName", DbType.String,Username);
                sqlDatabase.AddInParameter(dbCommand, "Email", DbType.String, Email);

                List<UserModel> userModels = new List<UserModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        UserModel userModel = new UserModel();
                        userModel.PersonID = int.Parse(dr["PersonID"].ToString());
                        userModel.PersonName = dr["PersonName"].ToString();
                        userModel.Contact = dr["Contact"].ToString();
                        userModel.Email = dr["Email"].ToString();
                        userModels.Add(userModel);
                    }
                }
                return userModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
