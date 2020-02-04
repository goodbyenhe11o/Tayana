using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TayanaSystem
{
    public class ListNumber
    {
        readonly SqlConnection _connection;
        #region "建構子"
        /// <summary>
        /// 建構子，預設使用web.config裡連線字串名稱為ConnectionString
        /// </summary>
        public ListNumber()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TayanaConnectionString"].ToString());
        }
        /// <summary>
        /// 建構子，傳入SqlConnection物件
        /// </summary>
        /// <param name="conn">傳入SqlConnection物件</param>
        public ListNumber(SqlConnection conn)
        {
            _connection = conn;
        }
        /// <summary>
        /// 建構子，傳入連線字串
        /// </summary>
        /// <param name="connectionString"></param>
        public ListNumber(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }
        #endregion



        #region "後台動態發布系統列表"

        /// <summary>
        /// 後台動態發布系統列表
        /// </summary>
        /// <param name="moduleId">moduleID</param>
        /// <param name="orgId">機關編號</param>
        /// <param name="pClassId">第一層編號</param>
        /// <param name="title">標題關鍵字</param>
        /// <param name="sortMethed">排序方式</param>
        /// <param name="litimDate">是否顯示開始時間與結束時間</param>
        /// <param name="pageSize">一頁幾筆</param>
        /// <param name="currentPage">第幾頁</param>
        /// <returns>DataTable</returns>



        public int GetDataCount()
        {
            string commandString = "select count(*) from News where 1=1";
            SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill((dataTable));
            return dataTable.Rows.Count > 0 ? Convert.ToInt32(dataTable.Rows[0][0].ToString()) : 0;
        }

        public enum SortMethed
        {
            OrderByInitDate,
            OrderBylistNum,
            OrderByCounts
        }

        //模仿 C:\Users\erich\source\repos\WebSite_Justin 專案寫的, 有些是用不到的如:搜尋字串區塊, 處裡參數區塊的程式碼
        public DataTable GetMyDataList(string enable, string customerId, string startDate, string endDate, string strOrderBy, int pageSize, int currentPage)
        {
            string commandString = "WITH NewsA AS\n"
                                 + "(\n"
                                 + "SELECT ROW_NUMBER() OVER(order by [Top] desc, id desc) AS RowNumber\n"
                                 + ", News.*\n"
                                 + "FROM  News\n"
                                 + "where 1=1\n"
                                 + ")\n"
                                 + "select * from NewsA WHERE RowNumber >=@start  and RowNumber <=@end";

            //搜尋字串
            string searchString = "";

            if (enable != "")
            {
                searchString += " and enable = @enable ";
            }
            if (customerId != "")
            {
                searchString += " and customerID = @customerID ";
            }
            if (strOrderBy != "")
            {
                commandString = commandString.Replace("ORDER BY InputData.initDate desc", strOrderBy);
            }

            if ((!string.IsNullOrEmpty(startDate)) && (!string.IsNullOrEmpty(endDate)))
            {
                searchString += " and (payDate between @startDate and @endDate)";
            }

            commandString = commandString.Replace("/*--where begin --*/", string.Format("/*--where begin --*/ {0}{1}", Environment.NewLine, searchString));

            SqlCommand sqlCommand = new SqlCommand(commandString, _connection);
            //處裡參數
            sqlCommand.Parameters.Add("@enable", SqlDbType.NVarChar);
            sqlCommand.Parameters["@enable"].Value = enable;
            sqlCommand.Parameters.Add("@customerID", SqlDbType.NVarChar);
            sqlCommand.Parameters["@customerID"].Value = customerId;
            sqlCommand.Parameters.Add("@startDate", SqlDbType.NVarChar, 20);
            sqlCommand.Parameters.Add("@endDate", SqlDbType.NVarChar, 20);
            sqlCommand.Parameters["@startDate"].Value = startDate;
            sqlCommand.Parameters["@endDate"].Value = endDate;
            //分頁用
            sqlCommand.Parameters.Add("@start", SqlDbType.Int);
            sqlCommand.Parameters["@start"].Value = ((currentPage - 1) * pageSize) + 1;
            sqlCommand.Parameters.Add("@end", SqlDbType.Int);
            sqlCommand.Parameters["@end"].Value = currentPage * pageSize;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill((dataTable));
            return dataTable;
        }

        #endregion





    }
}