using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MySQLHelper;

namespace BLL
{
    public class BLLOperatePic
    {

        DALOperatePic dop = new DALOperatePic();
        List<string> savePicPath = new List<string>();
        MysqlHelper mh = new MysqlHelper();
        /// <summary>
        /// 查询数组内的图片是否存在于数据库中
        /// </summary>
        /// <param name="picPath">新增图片的数组</param>
        /// <param name="mysqlPass">数据库密码</param>
        /// <returns></returns>
        public void BllSearchPic(string[] picPath)
        {
            foreach (string picP in picPath)
            {
                //已经存在
                if (!dop.DalSearchPic(Path.GetFileName(picP), mh))
                {
                    File.Delete(picP);//就删除图片
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(DateTime.Now + ": 图片 " + Path.GetFileName(picP) + "删除成功");
                    Console.ResetColor();
                }
                else//没存在 加入剪切队列
                {


                    if (Path.GetFileName(picP).Split('_').Length >2)//判断是否重复
                    {
                        File.Delete(picP);//就删除图片
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(DateTime.Now + ": 图片 " + Path.GetFileName(picP) + "删除成功");
                        Console.ResetColor();
                    }
                    else
                    {
                        savePicPath.Add(picP);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(DateTime.Now + ": 图片 " + Path.GetFileName(picP) + "加入待剪切队列");
                        Console.ResetColor();
                    }
                }
            }
            picPath = null;

        }

        private List<string> picNameList = new List<string>();
        /// <summary>
        /// 进行剪切操作 然后把新增图片的名字放到一个集合中
        /// </summary>
        /// <param name="aimPath">目标文件夹</param>
        /// <returns></returns>
        public void CutPicAndInsertSql(string aimPath)
        {
            foreach (string fileP in savePicPath)
            {
                //移动图片
                File.Move(fileP, aimPath + Path.GetFileName(fileP));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(DateTime.Now + ": 图片 " + Path.GetFileName(fileP) + "移动成功");
                picNameList.Add(Path.GetFileName(fileP));
                Console.ResetColor();
            }

        }

        /// <summary>
        /// 把新增图片名字插入数据库
        /// </summary>
        /// <param name="mysqlPass">数据库密码</param>
        /// <returns></returns>
        public void InsertIntoMysql()
        {
            foreach (string picName in picNameList)
            {
                if (dop.DalInsertPic(picName, mh))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(DateTime.Now + ": " + " 图片 " + picName + " 录入数据库成功~");

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(DateTime.Now + ": " + " 图片 " + picName + " 录入数据库失败！");
                }
            }
            Console.ResetColor();
            picNameList = null;

        }

        /// <summary>
        /// 挑选未录入的链接，然后输出。
        /// </summary>
        /// <param name="Urllist"></param>
        /// <returns></returns>
        public List<string> CheckPicUrl(string[] Urllist)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            List<string> LastList = new List<string>();
            foreach (string fullUrl in Urllist)
            {
                if (dop.DalSearchPic(Path.GetFileName(fullUrl), mh))
                {
                    LastList.Add(fullUrl);
                    Console.WriteLine(DateTime.Now + " : " + "图片链接 "+ Path.GetFileName(fullUrl) +" 未记录，已经筛选。");
                }
                else
                {
                    Console.WriteLine(DateTime.Now + " : " + "图片链接 " + Path.GetFileName(fullUrl) + " 在记录中，准备丢弃。");
                }
            }
            Console.ResetColor();
            return LastList;
        }
    }
}

