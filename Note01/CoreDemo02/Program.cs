using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CoreDemo02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //build根据给定的配置进行生成，初始化主机对象，不会运行，只是创建出来并返回主机。
            //Run 运行主机 
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            //创建默认生成器  默认配置有
            //加载环境变量  （dotnet开头的）
            //加载命令行参数配置
            //加载应用配置
            //配置默认的日志组件
            //还可以进行自定义配置
            Host.CreateDefaultBuilder(args)
                //调用这里面的一些拓展方法，进行自定义的配置
                //默认配置 最重要： 启用Kestrel
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //组件配置 
                    //webBuilder.ConfigureKestrel((context,options)=>options.Limits.MaxRequestBodySize = 1024);//最大请求体尺寸，最大请求报文尺寸
                    //webBuilder.ConfigureLogging((context,builder)=>builder.AddDebug());

                    //主机配置项
                    webBuilder.UseStartup<Startup>();
                    //webBuilder.Build();
                    //硬编码配置
                    //webBuilder.UseUrls("http://*:6000");
                });
    }
}
