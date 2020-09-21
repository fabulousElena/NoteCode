using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySQLHelper;

namespace DAL
{
    public class DALOperatePic
    {
        /// <summary>
        /// 查询图片是否记录在数据库
        /// </summary>
        /// <param name="picName">文件名</param>
        /// <param name="mysqlPass">数据库密码</param>
        /// <returns></returns>
        public bool DalSearchPic(string picName, MysqlHelper mh)
        {
            return mh.ExecuteQueryMysql(picName);
        }

        /// <summary>
        /// 插入数据库
        /// </summary>
        /// <param name="picName"></param>
        /// <param name="mysqlPass"></param>
        /// <returns></returns>
        public bool DalInsertPic(string picName, MysqlHelper mh)
        {
           return mh.ExecuteOperateMysql(picName);
        }


    }
}



