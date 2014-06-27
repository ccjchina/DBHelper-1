﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DBHelper
{
    /// <summary>
    /// MySQL数据库连接器
    /// </summary>
    public class MySQL:DataBaseAccess
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public MySQL()
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
        public MySQL(string ConnectionText)
        {
            this.Connection = new MySql.Data.MySqlClient.MySqlConnection(ConnectionText);
            this.Command = this.Connection.CreateCommand();
            this.DataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.ConnectionOffline = new MySql.Data.MySqlClient.MySqlConnection(ConnectionText);
            this.CommandOffline = this.Connection.CreateCommand();
            this.DataAdapterOffline = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.DataReader = null;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Server">服务器</param>
        /// <param name="DataBaseName">数据库名称</param>
        /// <param name="UserId">数据库用户</param>
        /// <param name="Password">用户密码</param>
        public MySQL(string Server, string DataBaseName, string UserId, string Password)
        {
            string ConnectionText = "server=" + Server + @";database=" + DataBaseName + @";uid=" + UserId + @";pwd=" + Password + ";";
            this.Connection = new MySql.Data.MySqlClient.MySqlConnection(ConnectionText);
            this.Command = this.Connection.CreateCommand();
            this.DataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.ConnectionOffline = new MySql.Data.MySqlClient.MySqlConnection(ConnectionText);
            this.CommandOffline = this.Connection.CreateCommand();
            this.DataAdapterOffline = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.DataReader = null;

        } 

        #endregion

    }
}