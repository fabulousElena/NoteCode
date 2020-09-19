using CoreDemo02.Extensions;
using CoreDemo02.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreDemo02
{
    /// <summary>
    /// ����webӦ������Ҫ�ķ�����м�� --���ùܵ��ͷ���
    /// �涨 ����Ҫ�� Startup �����
    /// </summary>
    public class Startup
    {
        //��ѡ�ķ����� ����ע�����ķ��� ��������ִ�� 
        public void ConfigureServices(IServiceCollection services) //�������� ���񼯺�
        {
            //����ע��
            //ICO(���Ʒ�ת)������ְ��ע������  ����ʵ��  ΪʲôҪ�õ���  ��ΪҪ����ע��
            //��ת����Ҫʲô�� ��newʲô��  ��ת���������ת ������� �ɵ���������Ҫ�Ķ����ù������ù������þͿ����ˡ�
            //Ӧ�ó��򲢲����𴴽������ɵ���������  ����Ȩ��Ӧ�ó���ת���������ˡ�
            //������ע��Ĺ�ϵ��
            //һ������С��������Զ�����Ȼ���Ҹ�ĸ(IOC����)��Ȼ��ĸ�ͻ�����ʳ��(ʳ��������)��Ȼ�󽻸����ӳ�(����ע��)������ι�����ӳԡ�
            //һϵ�й��ߺ��ֶ� ������Ŀ���Ǵ���һ�� ����ϣ���ά�����ɲ��ԵĴ���ͳ���
            //ICO(���Ʒ�ת)��������ת�����ͽӿڵķ�ʽ����ֱ�ӲٿصĶ���Ŀ���Ȩ�����˵�������ͨ����������ʵ�ֶ��������װ��͹���
            //IOC�൱��һ��������Ĺ���   �������������  �������͵�����
            //IOC��������  һ����������ע�����ṩ�ģ���Ҫ������ӳ���������������Ĵ����������ڡ�
            //IOC(�ǼǴ�)������Ǹ�����ע�����ͣ����ܽ�����ĳ��������������Ķ���
            /*��ν������ע�룺���ǰ���������ϵ����ŵ�IOC�����У�Ȼ�������������ʵ��
             *����ע���� ������DI  unity  Autofac  Ninject ����dotnet�����
             *
             *�������Ĭ���Ѿ�ע����һЩ������
             * ����Ķ��Ƿ���Ҳ�з�������
             */

            //����˶Կ�������API��ع��ܵ�֧�֡����ǲ�֧����ͼ��ҳ�档
            services.AddControllers();
            //֧����ͼ ASP.NET CORE 3.x MVCģ��Ĭ��ʹ��
            services.AddControllersWithViews();
            //��ӵĶ�RazorPages����С��������֧��
            services.AddRazorPages();

            //���� ASP.NET CORE 2.x ʹ�õ�
            /*services.AddMvc(); */// == AddRazorPages(); + AddControllersWithViews(); ��3.x��
            //����
            services.AddCors();

            //������Щ�������õķ��� ==================================================

            //������ EF Core  ��־���  Swagger
            //ע���Զ������  
            //����������  ���͵���������
            //ע���Զ�������ʱ�򣬱���Ҫѡ��һ����������  
            /*
             * ��������������  ��
             * ˲ʱ  ÿ�δӷ���������������ʵ����ʱ�򶼻ᴴ��һ��ȫ�µ�ʵ����ÿ�ζ�new
             * ������  �̵߳��� ����ͬһ���̣߳������ֻʵ����һ��
             * ����  ȫ�ֵ�����֮��ÿ�ζ���ʹ����ͬ��ʵ��
             */
            //services.AddSingleton(); ˲ʱ
            //services.AddTransient(); ������
            //services.AddScoped(); ����

            //����ע��  ��˼������ͬ�ӿ�ע�����������ʱ�򣬵ڶ����ᡰ���ǡ���һ��
            //ͬ����Զ�������һ����������
            //                      �ӿ�         ��ʵ��
            services.AddSingleton<IMessageService, EmailService>();
            services.AddSingleton<IMessageService, SmsService>();
            //����Դ��ķ���ע����ò����ã�����ʹ�õ�����
            /*
             * ���������� ����Ҫ��Ҫ������
             * ��չ �淶�����װ������
             */
            services.AddMessage(builder => builder.UseEmail());
            //services.AddMessage(builder => builder.UseSms());
        }

        //�����м�����м����ɹܵ�  ��������Ǳ����
        /*
         * �м�� ���Ǵ���HTTP�������Ӧ�Ķ���  ·�ɣ���֤���Ự�����棬�����ɹܵ�����ġ�  MiddleWare
         * ���������Ժ������������  ��������Ĳ�����������ע�������
         * MVC  WebAPI ���ǽ�����ĳ��������м��֮�ϵġ�
         * �м������ְ�� ѡ���Ƿ����󴫵ݸ��ܵ��е���һ���м�����ڹܵ��е���һ���м����ǰ��ִ�й���
         * Ҳ����˵��ÿһ���м��������Ȩ�����Ƿ����󴫵ݸ���һ���м����Ҳ����ֱ��������Ӧ����ʹ�ܵ���·��
         * �м�����߹�����������AOP�����������̣���˼�롣���Ƕ�λ�͹�ע�㲻ͬ��
         * ��������ע�������ʵ�ֹ��� ������ҵ����һ�ֹ���
         * �м������˳��ģ� ����м����˳�����������Щ�м�ܵ���˳��
         * �������Ӧ���������෴��˳��Ҳ���෴�ġ�
         */
        public void Configure(IApplicationBuilder/*��������ܵ�*/ app, IWebHostEnvironment/*��������*/ env)
        {
            //Ҳ��ί�� �� next
            app.Use(async (context, next) => //Next ������һ��ί��
            {
                await context.Response.WriteAsync("MiddleWare 1 Begin \r\n");
                await next();//��Context������һ��  Ҳ����Run();  ������ķ�����
                await context.Response.WriteAsync("MiddleWare 1 End \r\n");
            });

            app.Use(async (context, next) => //Next ������һ��ί��
            {
                await context.Response.WriteAsync("MiddleWare 2 Begin \r\n");
                await next();//��Context������һ��  Ҳ����Run();  ������ķ�����
                await context.Response.WriteAsync("MiddleWare 2 End \r\n");
            });

            //run ����û�� next  ����ն��м��ί�е��ܵ���  �ն��м����ר��������·����ܵ��ġ��Ƿ���������
            //û���ն��м���ı������ ��������м��������ֻ�Ǳ���
            app.Run(async context =>
            {
                //�м����ʵ���Ǹ�ί��
                await context.Response.WriteAsync("this Is Run Function Response \r\n");
            });//����м�����ܵ���



            //�жϻ������� �ǲ���Development
            if (env.IsDevelopment())
            {
                //���������쳣ҳ���м��
                app.UseDeveloperExceptionPage();
            }

            //·���м��  �˵㣨�ս�㣩·���м����3.x����
            app.UseRouting();

            //�����л�������������м��
            /*
             * �Զ����м��
             * Լ������������ΪRequestDelegate�Ĳ����Ĺ������캯��
             * ��ΪInvoke����InvokeAsync�ķ��� =>���뷵��Task ���첽�� ������HttpContext�����������ǵ�һ��
             */

            //ͨ�õ�����м���ķ���
            app.UseMiddleware<TestMiddleware>();
            app.UseTest();

            //�˵㣨�ս�㣩�м�� ���������ã������м����·��֮��Ĺ�ϵ ӳ�� 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
