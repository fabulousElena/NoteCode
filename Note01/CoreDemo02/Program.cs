using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CoreDemo02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //build���ݸ��������ý������ɣ���ʼ���������󣬲������У�ֻ�Ǵ�������������������
            //Run �������� 
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            //����Ĭ��������  Ĭ��������
            //���ػ�������  ��dotnet��ͷ�ģ�
            //���������в�������
            //����Ӧ������
            //����Ĭ�ϵ���־���
            //�����Խ����Զ�������
            Host.CreateDefaultBuilder(args)
                //�����������һЩ��չ�����������Զ��������
                //Ĭ������ ����Ҫ�� ����Kestrel
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //������� 
                    //webBuilder.ConfigureKestrel((context,options)=>options.Limits.MaxRequestBodySize = 1024);//���������ߴ磬��������ĳߴ�
                    //webBuilder.ConfigureLogging((context,builder)=>builder.AddDebug());

                    //����������
                    webBuilder.UseStartup<Startup>();
                    //webBuilder.Build();
                    //Ӳ��������
                    //webBuilder.UseUrls("http://*:6000");
                });
    }
}
