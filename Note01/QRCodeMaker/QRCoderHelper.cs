using System.Drawing;
using QRCoder;

namespace QRCodeMaker
{
    public class QRCoderHelper
    {
        /// <summary>
        /// 字符串二维码生成-带图标
        /// </summary>
        /// <param name="msg">信息</param>
        /// <param name="version">版本:1-22</param>
        /// <param name="pixel">像素点大小</param>
        /// <param name="iconPath">图标路径</param>
        /// <param name="iconSize">图标尺寸</param>
        /// <param name="iconBorder">图标边框厚度</param>
        /// <param name="whiteEdge">二维码是否有白边</param>
        /// <returns></returns>
        public static Bitmap QrMaker(string msg, int version, int pixel, string iconPath, int iconSize, int iconBorder, bool whiteEdge)
        {
            QRCodeGenerator codeGenerator = new QRCodeGenerator();
            //ECCLevel.Q 代表被遮挡一部分时候的识别纠错能力 H最高 L最低
            QRCodeData codeData = codeGenerator.CreateQrCode(msg, QRCodeGenerator.ECCLevel.Q, true, true, QRCodeGenerator.EciMode.Utf8, version);

            QRCode code = new QRCode(codeData);

            Bitmap icon = new Bitmap(iconPath);

            Bitmap bmp = code.GetGraphic(pixel, Color.Black, Color.White, icon, iconSize, iconBorder, whiteEdge);

            return bmp;
        }

        /// <summary>
        /// 字符串二维码生成-无图标
        /// </summary>
        /// <param name="msg">二维码信息</param>
        /// <param name="version">版本:1-22</param>
        /// <param name="pixel"></param>
        /// <param name="whiteEdge"></param>
        /// <returns></returns>
        public static Bitmap QrMaker(string msg, int version, int pixel, bool whiteEdge)
        {
            QRCodeGenerator codeGenerator = new QRCodeGenerator();
            //ECCLevel.Q 代表被遮挡一部分时候的识别纠错能力 H最高 L最低
            QRCodeData codeData = codeGenerator.CreateQrCode(msg, QRCodeGenerator.ECCLevel.Q, true, true, QRCodeGenerator.EciMode.Utf8, version); 
            QRCode code = new QRCode(codeData);

            Bitmap bmp = code.GetGraphic(pixel, Color.Black, Color.White, whiteEdge);

            return bmp;
        }
    }
}
