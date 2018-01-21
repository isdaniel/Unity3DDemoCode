using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Mono.Data.Sqlite;
using UnityEngine;
using System.Data;
using Model;

namespace Dao
{
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
