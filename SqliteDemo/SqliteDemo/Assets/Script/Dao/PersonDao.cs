using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dao
{
    public class PersonDao
    {
        SQLHelper _sqlHelper = new SQLHelper();

        /// <summary>
        /// 取得Person列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PersonModel> GetPersonInfo()
        {
            string sqlText = "SELECT Rowid,Name,Age From Person";
            return _sqlHelper.Query<PersonModel>(sqlText, null);
        }

        /// <summary>
        /// 新增一個Person
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddPerson(PersonModel model)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO Person (NAME,AGE) ");
            sb.AppendLine("Values ");
            sb.AppendLine("(@NAME,@AGE) ");

            return _sqlHelper.Excute(sb.ToString(), model);
        }


        /// <summary>
        /// 刪除Person資料
        /// </summary>
        /// <param name="Rowid"></param>
        /// <returns></returns>
        public int DeletePerson(int Rowid)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Delete FROM Person ");
            sb.AppendLine("WHERE Rowid = @Rowid ");
            return _sqlHelper.Excute(sb.ToString(), new { Rowid = Rowid });
        }
    }
}
