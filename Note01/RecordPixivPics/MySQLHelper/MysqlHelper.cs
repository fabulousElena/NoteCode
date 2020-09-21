using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace MySQLHelper
{
    public class MysqlHelper
    {
        static string conStr = ConfigurationManager.AppSettings["conStr"];
        MySqlConnection msc;
        public MysqlHelper()
        {
            msc = new MySqlConnection(conStr);
            msc.Open();

            CheckTableExist();
        }

        private void CheckTableExist()
        {
            string sqlUrl2 = "SELECT TABLE_SCHEMA FROM information_schema.TABLE_CONSTRAINTS WHERE TABLE_NAME ='pixiv_pics_name';";
            MySqlCommand mcmd = new MySqlCommand(sqlUrl2, msc);
            

            if (mcmd.ExecuteScalar() == null)
            {
                string sqlUrl3 = "CREATE TABLE pixiv_pics_name (pid INT PRIMARY KEY AUTO_INCREMENT,pname VARCHAR(50))";
                mcmd = new MySqlCommand(sqlUrl3, msc);
                mcmd.ExecuteNonQuery();
                Console.WriteLine(DateTime.Now+ " : " +"数据库创建成功。");
            }
            else
            {
                Console.WriteLine(DateTime.Now + " : " + "数据库已经存在，无需创建，即将开始处理" +"\n"+"\n");
            }
        }

        public bool ExecuteQueryMysql(string picName)
        {
            string sqlUrl1 = "select COUNT(pid) from pixiv_pics_name where pname = '" + picName + "';";
            MySqlCommand mcmd = new MySqlCommand(sqlUrl1, msc);
            return Convert.ToInt32(mcmd.ExecuteScalar()) == 0;//等于True说明没有
        }

        /// <summary>
        /// 执行记录插入操作
        /// </summary>
        /// <param name="picName"></param>
        /// <param name="mysqlPass"></param>
        /// <returns></returns>
        public bool ExecuteOperateMysql(string picName)
        {
            string sqlUrl1 = "INSERT INTO pixiv_pics_name (pname) VALUE ('" + picName + "');";
            MySqlCommand mcmd = new MySqlCommand(sqlUrl1, msc);
            return mcmd.ExecuteNonQuery() > 0;
        }
    }
}
