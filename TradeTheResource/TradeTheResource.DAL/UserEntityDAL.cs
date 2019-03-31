using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeTheResource.Models;
using TradeTheResource.Utility;

namespace TradeTheResource.DAL
{
    public class UserEntityDAL
    {

        public UserEntity GetUserById(int id)
        {
            UserEntity userEntity = null;
            string sql = "SELECT Id,Account,`Password`,Role,ShowName,QQ,Email,Phone,Balance,PaymentAccount,PaymentMethods  from UserEntity where Id=@id";
            MySqlDataReader reader = MySqlHelper.MySqlDataReaderExecute(sql, System.Data.CommandType.Text,new MySqlParameter("@id", id));

            if (reader.HasRows)
            {

                userEntity = new UserEntity();
                while (reader.Read())
                {
                    userEntity.Id = reader.GetInt32(0);
                    userEntity.Account = reader.GetString(1);
                    userEntity.Password = reader.GetString(2);
                    userEntity.Role = reader.GetChar(3)=='0'?Role.Admin:reader.GetChar(3)=='1'?Role.User:Role.Visitor;
                    userEntity.ShowName =reader.IsDBNull(4)?userEntity.Account: reader.GetString(4);//如果ShowName是null，则显示Account
                    userEntity.QQ=reader.IsDBNull(5)?string.Empty: reader.GetString(5);
                    userEntity.Email = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                    userEntity.Phone = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                    userEntity.Balance = reader.GetDecimal(8);
                    userEntity.PaymentAccount= reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                    userEntity.PaymentMethods=reader.IsDBNull(10)?PaymentMethods.PendingStatus: reader.GetChar(10)=='0'?PaymentMethods.Wechat:PaymentMethods.Alipay;
             

                }

            }


            return userEntity;
        }

        public int Update(UserEntity userEntity)
        {
            string sql = "UPDATE userentity set ShowName=@sName, Email=@email,QQ=@qq,Phone=@phone,PaymentMethods=@payMethods WHERE Id=@id";
            MySqlParameter[] pms = new MySqlParameter[] {
                 new MySqlParameter("@id",userEntity.Id),
                   new MySqlParameter("@sName",userEntity.ShowName),
                new MySqlParameter("@email",userEntity.Email),
                 new MySqlParameter("@qq",userEntity.QQ),
                  new MySqlParameter("@phone",userEntity.Phone),
                   new MySqlParameter("@payMethods",userEntity.PaymentMethods),
                
            };
            return MySqlHelper.ExecuteNoQuery(sql, System.Data.CommandType.Text, pms);
        }


        public int Update(int uid,decimal money)
        {
            string sql = "UPDATE userentity set Balance=Balance+@money WHERE Id=@id";
            MySqlParameter[] pms = new MySqlParameter[] {
                 new MySqlParameter("@id",uid),
                 new MySqlParameter("@money",money),

            };
            return MySqlHelper.ExecuteNoQuery(sql, System.Data.CommandType.Text, pms);
        }

    }
}
