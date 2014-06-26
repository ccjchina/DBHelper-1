﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DBHelper
{
    /// <summary>
    /// 数据库连接器
    /// </summary>
    public abstract class DataBaseAccess
    {
        #region 变量
        private IDbCommand command;
        private IDbDataAdapter dataadapter;
        private IDbConnection connection;
        private IDbCommand commandoffline;
        private IDbDataAdapter dataadapteroffline;
        private IDbConnection connectionoffline;
        private IDataReader datareader;
        #endregion

        #region 属性

        #region System.Data.ConnectionState State 数据库连接状态
        /// <summary>
        /// 数据库连接状态
        /// </summary>
        public System.Data.ConnectionState State
        {
            get
            {
                if (this.connection != null)
                {
                    return this.connection.State;
                }
                else
                {
                    return ConnectionState.Closed;
                }
            
            }
          
        }
        #endregion

        #region System.Data.ConnectionState StateOffline 离线数据库连接状态
        /// <summary>
        /// 离线数据库连接状态
        /// </summary>
        public System.Data.ConnectionState StateOffline
        {
            get
            {
                if (this.connection != null)
                {
                    return this.connectionoffline.State;
                }
                else
                {
                    return ConnectionState.Closed;
                }

            }

        }
        #endregion

        #region IDbConnection Connection 数据库连接
        /// <summary>
        /// 数据库连接
        /// </summary>
        public IDbConnection Connection
        {
            get
            {
                return connection;
            }
            set { connection = value; }
        }
        #endregion 

        #region IDbConnection ConnectionOffline 离线数据库连接
        /// <summary>
        /// 离线数据库连接
        /// </summary>
        public IDbConnection ConnectionOffline
        {
            get
            {
                return connectionoffline;
            }
            set { connectionoffline = value; }
        }
        #endregion 

        #region IDbCommand Command 数据库命令
        /// <summary>
        /// 数据库命令
        /// </summary>
        public IDbCommand Command
        {
            get
            {
                return command;
            }
            set { command = value; }
        }
        #endregion 

        #region IDbCommand CommandOffline 离线数据库命令
        /// <summary>
        /// 离线数据库命令
        /// </summary>
        public IDbCommand CommandOffline
        {
            get
            {
                return commandoffline;
            }
            set { commandoffline = value; }
        }
        #endregion 

        #region IDbDataAdapter DataAdapter 数据库适配器
        /// <summary>
        /// 数据库适配器
        /// </summary>
        public IDbDataAdapter DataAdapter
        {
            get
            {
                return dataadapter;
            }
            set { dataadapter = value; }
        }
        #endregion 

        #region IDbDataAdapter DataAdapterOffline 离线数据库适配器
        /// <summary>
        /// 离线数据库适配器
        /// </summary>
        public IDbDataAdapter DataAdapterOffline
        {
            get
            {
                return dataadapteroffline;
            }
            set { dataadapteroffline = value; }
        }
        #endregion 

        #region IDataReader DataReader 数据库DataReader
        /// <summary>
        /// 数据库DataReader
        /// </summary>
        public IDataReader DataReader
        {
            get
            {
                return datareader;
            }
            set { datareader = value; }
        }
        #endregion 

        #endregion

        #region 使用离线连接器的方法

        #region GetDataTable
        public abstract DataTable GetDataTable(string sql);

        public abstract DataTable GetDataTable(string sql, Dictionary<string, object> Parameters);

        #endregion

        #region GetDataTableReader

        public abstract IDataReader GetDataTableReader(string sql);

        public abstract IDataReader GetDataTableReader(string sql, Dictionary<string, object> Parameters);

        #endregion

        #region GetString

        public abstract string GetString(string sql);

        public abstract string GetString(string sql, Dictionary<string, object> Parameters);

        #endregion

        #region GetInt16

        public abstract Int16 GetInt16(string sql);

        public abstract Int16 GetInt16(string sql, Dictionary<string, object> Parameters);

        #endregion

        #region GetInt32

        public abstract Int32 GetInt32(string sql);

        public abstract Int32 GetInt32(string sql, Dictionary<string, object> Parameters);

        #endregion

        #region GetInt64

        public abstract Int64 GetInt64(string sql);

        public abstract Int64 GetInt64(string sql, Dictionary<string, object> Parameters);

        #endregion

        #region GetBool

        public abstract bool GetBool(string sql);

        public abstract bool GetBool(string sql, Dictionary<string, object> Parameters);

        #endregion

        #region GetDecimal

        public abstract decimal GetDecimal(string sql);

        public abstract decimal GetDecimal(string sql, Dictionary<string, object> Parameters);

        #endregion

        #region GetDouble

        public abstract double GetDouble(string sql);

        public abstract double GetDouble(string sql, Dictionary<string, object> Parameters);

        #endregion

        #region GetFloat

        public abstract float GetFloat(string sql);

        public abstract float GetFloat(string sql, Dictionary<string, object> Parameters);

        #endregion 

        #region GetChar

        public abstract char GetChar(string sql);

        public abstract char GetChar(string sql, Dictionary<string, object> Parameters);

        #endregion 

        #region GetDateTime

        public abstract DateTime  GetDateTime(string sql);

        public abstract DateTime GetDateTime(string sql, Dictionary<string, object> Parameters);

        #endregion 

        #endregion
    }
}
