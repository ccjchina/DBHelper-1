﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;



namespace DBHelper
{
    /// <summary>
    /// Oracle数据库连接器
    /// </summary>
    public class Oracle:DataBaseAccess
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public Oracle()
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
        public Oracle(string ConnectionText)
        {
            this.Connection = new System.Data.Odbc.OdbcConnection(ConnectionText);
            this.Command = this.Connection.CreateCommand();
            this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
            this.ConnectionOffline = new System.Data.Odbc.OdbcConnection(ConnectionText);
            this.CommandOffline = this.Connection.CreateCommand();
            this.DataAdapterOffline = new System.Data.Odbc.OdbcDataAdapter();
            this.DataReader = null;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Server">服务器</param>
        /// <param name="UserId">数据库用户</param>
        /// <param name="Password">用户密码</param>
        public Oracle(string Server, string UserId,string Password)
        {
            string ConnectionText =  "Driver={Microsoft ODBC for Oracle};Server=" + Server + ";Uid=" + UserId + ";Pwd=" + Password + ";";
            this.Connection = new System.Data.Odbc.OdbcConnection(ConnectionText);
            this.Command = this.Connection.CreateCommand();
            this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
            this.ConnectionOffline = new System.Data.Odbc.OdbcConnection(ConnectionText);
            this.CommandOffline = this.Connection.CreateCommand();
            this.DataAdapterOffline = new System.Data.Odbc.OdbcDataAdapter();
            this.DataReader = null;

        } 

        #endregion
    }
}