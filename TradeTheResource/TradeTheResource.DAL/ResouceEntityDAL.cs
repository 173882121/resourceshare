using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeTheResource.Models;
using MySql.Data.MySqlClient;

namespace TradeTheResource.DAL
{
    public class ResouceEntityDAL
    {
        /// <summary>
        /// 获取资源实体信息（这里为了安全并没有取解压密码）
        /// </summary>
        /// <returns></returns>
        public List<ResouceEntity> GetAllResouce(int uid)
        {

            List<ResouceEntity> resouceEntities = new List<ResouceEntity>();
            string sql = "SELECT Id,Price,Url,UploadTime,PaymentTimes,LastPayTime,`Comment`,`Group`,UserId from resouceentity where UserId=@uid";
            MySqlDataReader reader = MySqlHelper.MySqlDataReaderExecute(sql, System.Data.CommandType.Text, new MySqlParameter("@uid", uid));
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ResouceEntity model = new ResouceEntity();
                    model.Id = reader.GetInt32(0);
                    model.Price = reader.GetDecimal(1);
                    model.Url = reader.GetString(2);
                    model.UploadTime = reader.GetDateTime(3);
                    model.PaymentTimes = reader.GetInt32(4);
                    model.LastPayTime = reader.IsDBNull(5) ? null : (DateTime?)reader.GetDateTime(5);
                    model.Comment = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                    model.Group = reader.GetInt32(7);
                    model.UserId = reader.GetInt32(8);
                    resouceEntities.Add(model);


                }


            }


            return resouceEntities;
        }

        public List<ResouceEntity> GetPageResouce(int pageIndex, int pageSize, out int total, int uid)
        {

            List<ResouceEntity> resouceEntities = new List<ResouceEntity>();
            string sql = "SELECT Id,Price,Url,UploadTime,PaymentTimes,LastPayTime,`Comment`,`Group`,UserId from resouceentity where UserId=@uid ORDER By Id  LIMIT @start , @end ";
            MySqlParameter[] pms = new MySqlParameter[] {
                 new MySqlParameter("@uid", uid),
                  new MySqlParameter("@start", pageSize*(pageIndex-1)),
                   new MySqlParameter("@end", pageSize*pageIndex)


            };

            MySqlDataReader reader = MySqlHelper.MySqlDataReaderExecute(sql, System.Data.CommandType.Text,pms);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ResouceEntity model = new ResouceEntity();
                    model.Id = reader.GetInt32(0);
                    model.Price = reader.GetDecimal(1);
                    model.Url = reader.GetString(2);
                    model.UploadTime = reader.GetDateTime(3);
                    model.PaymentTimes = reader.GetInt32(4);
                    model.LastPayTime = reader.IsDBNull(5) ? null : (DateTime?)reader.GetDateTime(5);
                    model.Comment = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                    model.Group = reader.GetInt32(7);
                    model.UserId = reader.GetInt32(8);
                    resouceEntities.Add(model);


                }


            }


            total = this.GetCount(uid);

            return resouceEntities;
        }

        public ResouceEntity GetResourceById(int id, int uid)
        {

            ResouceEntity resouceEntity = null;
            string sql = "SELECT Id,Price,Url,UploadTime,PaymentTimes,LastPayTime,`Comment`,`Group`,UnpackCode,UserId from resouceentity where Id=@id and UserId=@uid";
            MySqlDataReader reader = MySqlHelper.MySqlDataReaderExecute(sql, System.Data.CommandType.Text, new MySqlParameter[] {
                new MySqlParameter("@id",id),
                new MySqlParameter("@uid",uid)
            });

            if (reader.HasRows)
            {

                resouceEntity = new ResouceEntity();
                while (reader.Read())
                {
                    resouceEntity.Id = reader.GetInt32(0);
                    resouceEntity.Price = reader.GetDecimal(1);
                    resouceEntity.Url = reader.GetString(2);
                    resouceEntity.UploadTime = reader.GetDateTime(3);
                    resouceEntity.PaymentTimes = reader.GetInt32(4);
                    resouceEntity.LastPayTime = reader.IsDBNull(5) ? null : (DateTime?)reader.GetDateTime(5);
                    resouceEntity.Comment = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                    resouceEntity.Group = reader.GetInt32(7);
                    resouceEntity.UnpackCode = reader.GetString(8);
                    resouceEntity.UserId = reader.GetInt32(9);

                }
            }
            return resouceEntity;

        }

        public int Update(string rUrl, int userId, string unpackCode)
        {
            string sql = "UPDATE resouceentity set LastPayTime=@lpTime, PaymentTimes=PaymentTimes+1 where UserId=@uid and UnpackCode=@uCode and Url=@url";
            MySqlParameter[] pms = new MySqlParameter[] {
                new MySqlParameter("@lpTime",DateTime.Now),
                new MySqlParameter("@uid",userId),
                new MySqlParameter("@uCode",unpackCode),
                new MySqlParameter("@url",rUrl)

            };

            return MySqlHelper.ExecuteNoQuery(sql, System.Data.CommandType.Text, pms);
        }

        public int DeleteResourceById(int sid, int uid)
        {
            string sql = "delete from ResouceEntity where Id=@sid and UserId=@uid";
            return MySqlHelper.ExecuteNoQuery(sql, System.Data.CommandType.Text, new MySqlParameter[] { new MySqlParameter("@sid", sid), new MySqlParameter("@uid", uid) });
        }

        public int Insert(ResouceEntity resouceEntity)
        {
            //但是我们想要使用key当列名，使用"   "或者'   '或者[] 都是不行的

            //只能使用`  `符号。

            //这个符号是键盘上TAB按键上面的那个按键。

            string sql = "insert INTO resouceentity(Id,Price,Url,UploadTime,PaymentTimes,`Group`,UnpackCode,UserId) values(@id,@price,@url,@ultime,@ptimes,@grp,@ucode,@uid)";
            MySqlParameter[] pms = new MySqlParameter[] {
                new MySqlParameter("@id",null),
                new MySqlParameter("@price",resouceEntity.Price),
                new MySqlParameter("@url",resouceEntity.Url),
                new MySqlParameter("@ultime",resouceEntity.UploadTime),
                new MySqlParameter("@ptimes",resouceEntity.PaymentTimes),
                new MySqlParameter("@grp",resouceEntity.Group),
                 new MySqlParameter("@ucode",resouceEntity.UnpackCode),
                  new MySqlParameter("@uid",resouceEntity.UserId)

            };

            return MySqlHelper.ExecuteNoQuery(sql, System.Data.CommandType.Text, pms);
        }


        public int GetCount(int uid)
        {

            string sql = "select count(0) from ResouceEntity where UserId=@id ";

            return Convert.ToInt32(MySqlHelper.ExecuteScalar(sql, System.Data.CommandType.Text, new MySqlParameter("@id",uid)));


        }
    }
}
