using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeCommon
{

    public class FormatFactory
    {
        /// <summary>
        /// 返回所选的格式
        /// </summary>
        /// <param name="thisSelectedItem">选择的格式</param>
        /// <returns></returns>
        public static List<object> GetSelectFormat(string thisSelectedItem)
        {
            List<object> formatList = new List<object>();
            switch (thisSelectedItem)
            {
                case "Png":
                    formatList.Add(".png");
                    formatList.Add(ImageFormat.Png);
                    break;
                case "Jpeg":
                    formatList.Add(".jpg");
                    formatList.Add(ImageFormat.Jpeg);
                    break;
                case "Icon":
                    formatList.Add(".ico");
                    formatList.Add(ImageFormat.Icon);
                    break;
                case "Bmp":
                    formatList.Add(".bmp");
                    formatList.Add(ImageFormat.Bmp);
                    break;
                case "Tiff":
                    formatList.Add(".tiff");
                    formatList.Add(ImageFormat.Tiff);
                    break;
                case "Emf":
                    formatList.Add(".emf");
                    formatList.Add(ImageFormat.Emf);
                    break;
                default:
                    return null;
            }
            return formatList;
        }
    }
}
