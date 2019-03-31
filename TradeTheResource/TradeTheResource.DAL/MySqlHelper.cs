using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;

namespace TradeTheResource.DAL
{
    public static class MySqlHelper
    {
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["mysqlConStr"].ConnectionString;
        /// <summary>
        /// 执行没返回的sql
        /// </summary>
        /// <param name="sql">sql语句或存储过程</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="pms">命令参数</param>
        /// <returns>影响行数</returns>
        public static int ExecuteNoQuery(string sql, CommandType cmdType, params MySqlParameter[] pms)
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.CommandText = sql;
                    cmd.CommandType = cmdType;
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();

                }
            }
        }


        /// <summary>
        /// 执行返回一个数据的sql命令
        /// </summary>
        /// <param name="sql">sql语句或存储过程</param>
        /// <param name="cmdType">执行命令类型</param>
        /// <param name="pms">命令参数</param>
        /// <returns>单一数据</returns>
        public static object ExecuteScalar(string sql, CommandType cmdType, params MySqlParameter[] pms)
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.CommandText = sql;
                    cmd.CommandType = cmdType;
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    conn.Open();
                    return cmd.ExecuteScalar();

                }
            }

        }

        /// <summary>
        /// 执行返回MySqlDataReader的sql语句
        /// </summary>
        /// <param name="sql">sql语句或存储过程</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="pms">命令参数</param>
        /// <returns>MySqlDataReader</returns>
        public static MySqlDataReader MySqlDataReaderExecute(string sql, CommandType cmdType, params MySqlParameter[] pms)
        {

            MySqlConnection conn = new MySqlConnection(conStr);

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandText = sql;
            cmd.CommandType = cmdType;
            if (pms != null)
            {
                cmd.Parameters.AddRange(pms);

            }
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                // return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return cmd.ExecuteReader();
            }
            catch (MySqlException e)
            {

                conn.Close();
                conn.Dispose();
                throw e;
            }





        }

        /// <summary>
        /// 执行返回DataTable的sql语句
        /// </summary>
        /// <param name="sql">sql语句或存储过程</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="pms">命令参数</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTable(string sql, CommandType cmdType, params MySqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conStr))
            {
                adapter.SelectCommand.CommandType = cmdType;
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(dt);

            }
            return dt;
        }




    }

}
