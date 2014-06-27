﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;



namespace DBHelper
{
    /// <summary>
    /// SqlServer数据库连接器
    /// </summary>
    public class SqlServer:DataBaseAccess
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public SqlServer()
        {
            this.Connection = null;
            this.Command = null;
            this.DataAdapter = null;
            this.ConnectionOffline = null;
            this.CommandOffline = null;
            this.DataAdapterOffline = null;
            this.DataReader = null;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ConnectionText">连接字符串</param>
        public SqlServer(string ConnectionText)
        {
            this.Connection = new System.Data.SqlClient.SqlConnection(ConnectionText);
            this.Command = this.Connection.CreateCommand();
            this.DataAdapter = new System.Data.SqlClient.SqlDataAdapter();
            this.ConnectionOffline = new System.Data.SqlClient.SqlConnection(ConnectionText);
            this.CommandOffline = this.Connection.CreateCommand();
            this.DataAdapterOffline = new System.Data.SqlClient.SqlDataAdapter();
            this.DataReader = null;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Server">服务器</param>
        /// <param name="DataBaseName">数据库名称</param>
        /// <param name="UserId">数据库用户</param>
        /// <param name="Password">用户密码</param>
        public SqlServer(string Server, string DataBaseName, string UserId, string Password)
        {
            string ConnectionText = "server=" + Server + @";database=" + DataBaseName + @";user id=" + UserId + @";pwd=" + Password + ";";
            this.Connection = new System.Data.SqlClient.SqlConnection(ConnectionText);
            this.Command = this.Connection.CreateCommand();
            this.DataAdapter = new System.Data.SqlClient.SqlDataAdapter();
            this.ConnectionOffline = new System.Data.SqlClient.SqlConnection(ConnectionText);
            this.CommandOffline = this.Connection.CreateCommand();
            this.DataAdapterOffline = new System.Data.SqlClient.SqlDataAdapter();
            this.DataReader = null;

        } 

        #endregion

        #region 使用离线连接器的方法

        #region GetDataTable

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取DataTable对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <returns></returns>
        public override DataTable GetDataTable(string sql)
        {

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            try
            {
                this.ConnectionOffline.Open();
                this.CommandOffline = this.ConnectionOffline.CreateCommand();
                this.CommandOffline.CommandType = CommandType.Text;
                this.CommandOffline.CommandText = sql;
                this.CommandOffline.Parameters.Clear();

                this.DataAdapterOffline.SelectCommand = this.CommandOffline;

                this.DataAdapterOffline.Fill(ds);
                dt = ds.Tables[0];
            }
            catch { throw; }
            finally
            {
                ds.Dispose();
                this.ConnectionOffline.Close();
            }
            return dt;
        }

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取DataTable对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <param name="Parameters">参数</param>
        /// <returns></returns>
        public override DataTable GetDataTable(string sql, Dictionary<string, object> Parameters)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            try
            {

                this.ConnectionOffline.Open();
                this.CommandOffline = this.ConnectionOffline.CreateCommand();
                this.CommandOffline.CommandType = CommandType.Text;
                this.CommandOffline.CommandText = sql;
                this.CommandOffline.Parameters.Clear();
                foreach (string key in Parameters.Keys)
                {
                    this.CommandOffline.Parameters.Add(new System.Data.SqlClient.SqlParameter(key, Parameters[key]));
                }

                this.DataAdapterOffline.SelectCommand = this.CommandOffline;

                this.DataAdapterOffline.Fill(ds);
                dt = ds.Tables[0];
            }
            catch { throw ; }
            finally
            {
                ds.Dispose();
                this.ConnectionOffline.Close();
            }
            return dt;
        }

        #endregion

        #region GetDataTableReader

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取DataTableReader对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <returns></returns>
        public override IDataReader GetDataTableReader(string sql)
        {
            IDataReader dr = null;

            dr = this.GetDataTable(sql).CreateDataReader();

            return dr;
        }

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取DataTableReader对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <param name="Parameters">参数</param>
        /// <returns></returns>
        public override IDataReader GetDataTableReader(string sql, Dictionary<string, object> Parameters)
        {
            IDataReader dr = null;

            dr = this.GetDataTable(sql, Parameters).CreateDataReader();

            return dr;
        }

        #endregion

        #region GetString

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取String对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <returns></returns>
        public override string GetString(string sql)
        {
            string ret = null;

            IDataReader dr = this.GetDataTable(sql).CreateDataReader();

            if (dr.Read())
            {
                ret = dr[0].ToString();
            }

            return ret;
        }

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取String对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <param name="Parameters">参数</param>
        /// <returns></returns>
        public override string GetString(string sql, Dictionary<string, object> Parameters)
        {
            string ret = null;

            IDataReader dr = this.GetDataTable(sql, Parameters).CreateDataReader();

            if (dr.Read())
            {
                ret = dr[0].ToString();
            }

            return ret;
        }

        #endregion

        #region GetInt16

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取Int16对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <returns></returns>
        public override Int16 GetInt16(string sql)
        {
            Int16 ret = new short();

            IDataReader dr = this.GetDataTable(sql).CreateDataReader();

            if (dr.Read())
            {
                ret = Convert.ToInt16(dr[0]);
            }

            return ret;
        }

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取Int16对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <param name="Parameters">参数</param>
        /// <returns></returns>
        public override Int16 GetInt16(string sql, Dictionary<string, object> Parameters)
        {
            Int16 ret = new short();

            IDataReader dr = this.GetDataTable(sql, Parameters).CreateDataReader();

            if (dr.Read())
            {
                ret = Convert.ToInt16(dr[0]);
            }

            return ret;
        }

        #endregion

        #region GetInt32

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取Int32对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <returns></returns>
        public override Int32 GetInt32(string sql)
        {
            Int32 ret = new int();

            IDataReader dr = this.GetDataTable(sql).CreateDataReader();

            if (dr.Read())
            {
                ret = Convert.ToInt32(dr[0]);
            }

            return ret;
        }

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取Int32对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <param name="Parameters">参数</param>
        /// <returns></returns>
        public override Int32 GetInt32(string sql, Dictionary<string, object> Parameters)
        {
            Int32 ret = new int();

            IDataReader dr = this.GetDataTable(sql, Parameters).CreateDataReader();

            if (dr.Read())
            {
                ret = Convert.ToInt32(dr[0]);
            }

            return ret;
        }

        #endregion

        #region GetInt64

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取Int64对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <returns></returns>
        public override Int64 GetInt64(string sql)
        {
            Int64 ret = new long();

            IDataReader dr = this.GetDataTable(sql).CreateDataReader();

            if (dr.Read())
            {
                ret = Convert.ToInt64(dr[0]);
            }

            return ret;
        }

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取Int64对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <param name="Parameters">参数</param>
        /// <returns></returns>
        public override Int64 GetInt64(string sql, Dictionary<string, object> Parameters)
        {
            Int64 ret = new long();

            IDataReader dr = this.GetDataTable(sql, Parameters).CreateDataReader();

            if (dr.Read())
            {
                ret = Convert.ToInt64(dr[0]);
            }

            return ret;
        }

        #endregion

        #region GetBool

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取Bool对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <returns></returns>
        public override bool GetBool(string sql)
        {
            bool ret = new bool();

            IDataReader dr = this.GetDataTable(sql).CreateDataReader();

            if (dr.Read())
            {
                ret = Convert.ToBoolean(dr[0]);
            }

            return ret;
        }

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取Bool对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <param name="Parameters">参数</param>
        /// <returns></returns>
        public override bool GetBool(string sql, Dictionary<string, object> Parameters)
        {
            bool ret = new bool();

            IDataReader dr = this.GetDataTable(sql, Parameters).CreateDataReader();

            if (dr.Read())
            {
                ret = Convert.ToBoolean(dr[0]);
            }

            return ret;
        }

        #endregion

        #region GetDecimal

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取Decimal对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <returns></returns>
        public override decimal GetDecimal(string sql)
        {
            decimal ret = new decimal();

            IDataReader dr = this.GetDataTable(sql).CreateDataReader();

            if (dr.Read())
            {
                ret = Convert.ToDecimal(dr[0]);
            }

            return ret;
        }

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取Decimal对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <param name="Parameters">参数</param>
        /// <returns></returns>
        public override decimal GetDecimal(string sql, Dictionary<string, object> Parameters)
        {
            decimal ret = new decimal();

            IDataReader dr = this.GetDataTable(sql, Parameters).CreateDataReader();

            if (dr.Read())
            {
                ret = Convert.ToDecimal(dr[0]);
            }

            return ret;
        }

        #endregion

        #region GetDouble

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取Double对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <returns></returns>
        public override double GetDouble(string sql)
        {
            double ret = new double();

            IDataReader dr = this.GetDataTable(sql).CreateDataReader();

            if (dr.Read())
            {
                ret = Convert.ToDouble(dr[0]);
            }

            return ret;
        }

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取Double对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <param name="Parameters">参数</param>
        /// <returns></returns>
        public override double GetDouble(string sql, Dictionary<string, object> Parameters)
        {
            double ret = new double();

            IDataReader dr = this.GetDataTable(sql, Parameters).CreateDataReader();

            if (dr.Read())
            {
                ret = Convert.ToDouble(dr[0]);
            }

            return ret;
        }

        #endregion

        #region GetFloat

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取Float对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <returns></returns>
        public override float GetFloat(string sql)
        {
            float ret = new float();

            IDataReader dr = this.GetDataTable(sql).CreateDataReader();

            if (dr.Read())
            {
                ret = (float)Convert.ToDouble(dr[0]);
            }

            return ret;
        }

        /// <summary>
        ///使用离线数据库连接器，无需使用Open方法， 获取Float对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <param name="Parameters">参数</param>
        /// <returns></returns>
        public override float GetFloat(string sql, Dictionary<string, object> Parameters)
        {
            float ret = new float();

            IDataReader dr = this.GetDataTable(sql, Parameters).CreateDataReader();

            if (dr.Read())
            {
                ret = (float)Convert.ToDouble(dr[0]);
            }

            return ret;
        }

        #endregion

        #region GetChar

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取Char对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <returns></returns>
        public override char GetChar(string sql)
        {
            char ret = new char();

            IDataReader dr = this.GetDataTable(sql).CreateDataReader();

            if (dr.Read())
            {
                ret = Convert.ToChar(dr[0]);
            }

            return ret;
        }

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取Char对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <param name="Parameters">参数</param>
        /// <returns></returns>
        public override char GetChar(string sql, Dictionary<string, object> Parameters)
        {
            char ret = new char();

            IDataReader dr = this.GetDataTable(sql, Parameters).CreateDataReader();

            if (dr.Read())
            {
                ret = Convert.ToChar(dr[0]);
            }

            return ret;
        }

        #endregion

        #region GetDateTime

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取DateTime对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <returns></returns>
        public override DateTime GetDateTime(string sql)
        {
            DateTime ret = new DateTime();

            IDataReader dr = this.GetDataTable(sql).CreateDataReader();

            if (dr.Read())
            {
                ret = Convert.ToDateTime(dr[0]);
            }

            return ret;
        }

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取DateTime对象
        /// </summary>
        /// <param name="sql">命令</param>
        /// <param name="Parameters">参数</param>
        /// <returns></returns>
        public override DateTime GetDateTime(string sql, Dictionary<string, object> Parameters)
        {
            DateTime ret = new DateTime();

            IDataReader dr = this.GetDataTable(sql, Parameters).CreateDataReader();

            if (dr.Read())
            {
                ret = Convert.ToDateTime(dr[0]);
            }

            return ret;
        }

        #endregion 

        #region ExecuteProcedure

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，执行存储过程
        /// </summary>
        /// <param name="ProcedureName">存储过程名称</param>
        /// <param name="Parameters">参数</param>
        /// <returns></returns>
        public override Dictionary<string, object> ExecuteProcedure(string ProcedureName)
        {
            Dictionary<string, object> ret = new Dictionary<string, object>();
            int NORA = 0;
            ret.Add("IsSuccess", false);
            ret.Add("NORA", NORA);

            try
            {
                this.CommandOffline.CommandType = CommandType.StoredProcedure;
                
                this.CommandOffline.CommandText = ProcedureName;

                this.ConnectionOffline.Open();
                NORA = this.CommandOffline.ExecuteNonQuery();
                this.ConnectionOffline.Close();

                if (NORA > 0)
                {
                    ret["IsSuccess"] = true;
                    ret["NORA"] = NORA;
                }

                foreach (IDataParameter p in CommandOffline.Parameters)
                {
                    if (p.Direction == ParameterDirection.Output ||
                        p.Direction == ParameterDirection.InputOutput ||
                        p.Direction == ParameterDirection.ReturnValue)
                    {
                        ret.Add(p.ParameterName, p.Value);
                    }
                }

            }
            catch { throw; }
            finally { this.ConnectionOffline.Close(); }

            return ret;
        }

        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，执行存储过程
        /// </summary>
        /// <param name="ProcedureName">存储过程名称</param>
        /// <param name="Parameters">参数</param>
        /// <returns></returns>
        public override DataTable ExecuteProcedureToDataTable(string ProcedureName)
        {
            DataTable ret = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                this.CommandOffline.CommandType = CommandType.StoredProcedure;
               
                this.CommandOffline.CommandText = ProcedureName;

                this.ConnectionOffline.Open();
                this.DataAdapterOffline.SelectCommand = this.CommandOffline;
                this.DataAdapterOffline.Fill(ds);
                ret = ds.Tables[0];
                this.ConnectionOffline.Close();

            }
            catch { throw; }
            finally { this.ConnectionOffline.Close(); }

            return ret;
        }
        
        #endregion

        #endregion

        #region 使用在线连接器的方法

        #region ExecuteReader

        /// <summary>
        /// 使用在线连接器获取DataReader,使用完毕后记得用Close
        /// </summary>
        /// <param name="sql">命令</param>
        /// <returns></returns>
        public override void ExecuteReader(string sql)
        {
            this.Command.CommandType = CommandType.Text;
            this.Command.CommandText = sql;
            this.Command.Parameters.Clear();

            this.DataReader = this.Command.ExecuteReader();
        }

        /// <summary>
        /// 使用在线连接器获取DataReader,使用完毕后记得用Close
        /// </summary>
        /// <param name="sql">命令</param>
        /// <param name="Parameters">参数</param>
        public override void ExecuteReader(string sql, Dictionary<string, object> Parameters)
        {

            this.Command.CommandType = CommandType.Text;
            this.Command.CommandText = sql;
            this.Command.Parameters.Clear();
            foreach (string key in Parameters.Keys)
            {
                this.Command.Parameters.Add(new System.Data.SqlClient.SqlParameter(key, Parameters[key]));
            }

            this.DataReader = this.Command.ExecuteReader();
        }

        #endregion

        #region ExecuteNonQuery

        /// <summary>
        /// 执行命令并返回影响行数
        /// </summary>
        /// <param name="sql">命令</param>
        /// <returns></returns>
        public override int ExecuteNonQuery(string sql)
        {
            this.Command.CommandType = CommandType.Text;
            this.Command.CommandText = sql;
            this.Command.Parameters.Clear();

            return this.Command.ExecuteNonQuery();
        }

        /// <summary>
        /// 执行命令并返回影响行数
        /// </summary>
        /// <param name="sql">命令</param>
        /// <param name="Parameters">参数</param>
        public override int ExecuteNonQuery(string sql, Dictionary<string, object> Parameters)
        {
            this.Command.CommandType = CommandType.Text;
            this.Command.CommandText = sql;
            this.Command.Parameters.Clear();
            foreach (string key in Parameters.Keys)
            {
                this.Command.Parameters.Add(new System.Data.SqlClient.SqlParameter(key, Parameters[key]));
            }

            return  this.Command.ExecuteNonQuery();
        }

        #endregion

        #endregion
    }
}
