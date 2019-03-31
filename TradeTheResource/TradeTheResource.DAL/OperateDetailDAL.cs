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
    public class OperateDetailDAL
    {

        public OperateDetail GetOperateDetailByFromUrlStrAndStatus(string fromurlstr, int uid, Status status)
        {

            OperateDetail model = null;
            string sql = "SELECT Id,FromUrlStr,ToResourceUrl,FileName,UserId,UnpackCode,Price,`Status` FROM operatedetail where FromUrlStr=@fustr and UserId=@uid and `Status`=@status";
            MySqlParameter[] pms = new MySqlParameter[]
            {
                new MySqlParameter("@fustr",fromurlstr),
                new MySqlParameter("@uid",uid),
                  new MySqlParameter("@status",status)
            };

            MySqlDataReader reader = MySqlHelper.MySqlDataReaderExecute(sql, System.Data.CommandType.Text, pms);

            if (reader.HasRows)
            {

                model = new OperateDetail();
                while (reader.Read())
                {
                    model.Id = reader.GetInt32(0);
                    model.FromUrlStr = reader.GetString(1);
                    model.ToResourceUrl = reader.GetString(2);
                    model.FileName = reader.GetString(3);
                    
                    model.UserId = reader.GetInt32(4);
                    model.UnpackCode = reader.GetString(5);
                    model.Price = reader.GetDecimal(6);
                    model.Status = reader.GetChar(7) == '0' ? Status.NonPay : reader.GetChar(7) == '1' ? Status.InPay : Status.Paid;

                }
            }

            return model;

        }

        public int Update(int id, Status status)
        {
            string sql = "UPDATE operatedetail set `Status`=@status where Id=@id";
            MySqlParameter[] pms = new MySqlParameter[] {
                new MySqlParameter("@id",id),
                new MySqlParameter("@status",status)
            };

            return MySqlHelper.ExecuteNoQuery(sql, System.Data.CommandType.Text, pms);
        }

        public int Insert(OperateDetail operateDetail)
        {
            string sql = "insert into operatedetail(FromUrlStr,ToResourceUrl,FileName,UserId,UnpackCode,Price,`Status`) values(@fromurl,@tourl,@fname,@uid,@ucode,@price,@status)";
            MySqlParameter[] pms = new MySqlParameter[]
            {
                new MySqlParameter("@fromurl",operateDetail.FromUrlStr),
                new MySqlParameter("@tourl",operateDetail.ToResourceUrl),
                new MySqlParameter("@fname",operateDetail.FileName),
                new MySqlParameter("@uid",operateDetail.UserId),
                new MySqlParameter("@ucode",operateDetail.UnpackCode),
                 new MySqlParameter("@price",operateDetail.Price),
                  new MySqlParameter("@status",operateDetail.Status)
            };

            return MySqlHelper.ExecuteNoQuery(sql, System.Data.CommandType.Text, pms);
        }

        public OperateDetail GetOperateDetailById(int id)
        {

            OperateDetail model = null;
            string sql = "SELECT Id,FromUrlStr,ToResourceUrl,FileName,UserId,UnpackCode,Price,`Status` FROM operatedetail where Id=@id";
            MySqlParameter[] pms = new MySqlParameter[]
            {
                new MySqlParameter("@id",id)

            };

            MySqlDataReader reader = MySqlHelper.MySqlDataReaderExecute(sql, System.Data.CommandType.Text, pms);

            if (reader.HasRows)
            {

                model.Id = reader.GetInt32(0);
                model.FromUrlStr = reader.GetString(1);
                model.ToResourceUrl = reader.GetString(2);
                model.FileName = reader.GetString(3);

                model.UserId = reader.GetInt32(4);
                model.UnpackCode = reader.GetString(5);
                model.Price = reader.GetDecimal(6);
                model.Status = reader.GetChar(7) == '0' ? Status.NonPay : reader.GetChar(7) == '1' ? Status.InPay : Status.Paid;
            }

            return model;

        }
    }
}
