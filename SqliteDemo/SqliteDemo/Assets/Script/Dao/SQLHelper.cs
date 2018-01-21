using System;
using System.Collections.Generic;
using Dapper;
using Mono.Data.Sqlite;
using UnityEngine;
using System.Data;
/*
 * 設計模式：門面模式
 * 原因：使用第三方插件，最好再多包一層
 * 一．日後第三方插件做修改只需要改一個地方
 * 二．日後可能不只連接SQLite，還可能連MSSQL．統一管理可幫助日後提取抽象
 * 
 * **/
namespace Dao
{
    /// <summary>
    /// 把Dapper多包一層，專門做Dapper操作
    /// </summary>
    public class SQLHelper
    {
        //連接資訊
        private string _Connstring;

        public SQLHelper()
        {
            string dbPath = string.Format("{0}/Data/{1}"
                ,Application.dataPath//取得執行程式跟目錄
                ,"Info.db"); //取得DB

            _Connstring  = string.Format("Data Source={0};Version=3;",dbPath);
        }

        public IEnumerable<T> Query<T>(string SqlText, object para = null)
        {
            return SQLExcute((conn)=>conn.Query<T>(SqlText, para));
        }

        public int Excute(string SqlText, object para = null)
        {
            return SQLExcute((conn) => conn.Execute(SqlText, para));
        }

        private T SQLExcute<T>(Func<IDbConnection, T> sqlExcutor)
        {
            using (IDbConnection conn = new SqliteConnection(_Connstring))
            {
                //2.打開連接
                conn.Open();
                //3.執行查詢
                return sqlExcutor(conn);
            }
        }
    }
}
