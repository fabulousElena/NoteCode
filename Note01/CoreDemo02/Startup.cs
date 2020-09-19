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
    /// 配置web应用所需要的服务和中间件 --配置管道和服务
    /// 规定 必须要有 Startup 这个类
    /// </summary>
    public class Startup
    {
        //可选的方法。 用来注册服务的方法 由主机来执行 
        public void ConfigureServices(IServiceCollection services) //服务容器 服务集合
        {
            //依赖注入
            //ICO(控制反转)容器：职责：注册类型  请求实例  为什么要用到呢  因为要依赖注入
            //正转：需要什么类 就new什么类  反转：相对于正转 被动获得 由第三方把需要的东西拿过来，拿过来就用就可以了。
            //应用程序并不负责创建，是由第三方负责  控制权从应用程序转到第三方了。
            //和依赖注入的关系。
            //一个四岁小孩饿了想吃东西，然后找父母(IOC容器)，然后父母就会做好食物(食物是依赖)，然后交给孩子吃(依赖注入)，甚至喂给孩子吃。
            //一系列工具和手段 ，最终目的是创建一个 松耦合，可维护，可测试的代码和程序
            //ICO(控制反转)容器：反转依赖和接口的方式，把直接操控的对象的控制权交给了第三方，通过第三方来实现对象组件的装配和管理。
            //IOC相当于一个升级版的工厂   不仅制造和生产  还有配送到手里
            //IOC哪里来呢  一般是由依赖注入框架提供的，主要是用来映射依赖，管理对象的创建和生存期。
            //IOC(登记处)本身就是个对象。注册类型，功能解析，某个类所依赖的类的对象
            /*所谓的依赖注入：就是把有依赖关系的类放到IOC容器中，然后解析出这个类的实例
             *依赖注入框架 ：内置DI  unity  Autofac  Ninject 都是dotnet下面的
             *
             *这个方法默认已经注册了一些方法。
             * 这里的都是服务，也叫服务容器
             */

            //添加了对控制器和API相关功能的支持。但是不支持视图和页面。
            services.AddControllers();
            //支持视图 ASP.NET CORE 3.x MVC模板默认使用
            services.AddControllersWithViews();
            //添加的对RazorPages和最小控制器的支持
            services.AddRazorPages();

            //这是 ASP.NET CORE 2.x 使用的
            /*services.AddMvc(); */// == AddRazorPages(); + AddControllersWithViews(); 在3.x中
            //跨域
            services.AddCors();

            //以上这些都是内置的服务 ==================================================

            //第三方 EF Core  日志框架  Swagger
            //注册自定义服务  
            //服务生存期  类型的生命周期
            //注册自定义服务的时候，必须要选择一个生命周期  
            /*
             * 有三种生命周期  ：
             * 瞬时  每次从服务容器进行请求实例的时候都会创建一个全新的实例。每次都new
             * 作用域  线程单例 ，在同一个线程（请求）里，只实例化一次
             * 单例  全局单例，之后每次都会使用相同的实例
             */
            //services.AddSingleton(); 瞬时
            //services.AddTransient(); 作用域
            //services.AddScoped(); 单例

            //服务注册  意思就是相同接口注册两个服务的时候，第二个会“覆盖”第一个
            //同名永远都是最后一个才起作用
            //                      接口         ，实现
            services.AddSingleton<IMessageService, EmailService>();
            services.AddSingleton<IMessageService, SmsService>();
            //如果自带的服务注册觉得不好用，可以使用第三方
            /*
             * 服务生存期 服务要不要配置呢
             * 拓展 规范服务封装方法。
             */
            services.AddMessage(builder => builder.UseEmail());
            //services.AddMessage(builder => builder.UseSms());
        }

        //配置中间件，中间件组成管道  这个方法是必须的
        /*
         * 中间件 就是处理HTTP请求和响应的东西  路由，认证，会话，缓存，都是由管道处理的。  MiddleWare
         * 主机运行以后启动这个方法  方法里面的参数都是主机注入进来的
         * MVC  WebAPI 都是建立在某个特殊的中间件之上的。
         * 中间件两个职责： 选择是否将请求传递给管道中的下一个中间件；在管道中的下一个中间件的前后执行工作
         * 也就是说，每一个中间件，都有权做出是否将请求传递给下一个中间件，也可以直接做出相应来促使管道短路。
         * 中间件或者过滤器，都是AOP（面向切面编程）的思想。但是定位和关注点不同。
         * 过滤器关注的是如何实现功能 ，不是业务，是一种功能
         * 中间件是有顺序的， 添加中间件的顺序就是请求这些中间管道的顺序。
         * 请求和响应，方向是相反，顺序也是相反的。
         */
        public void Configure(IApplicationBuilder/*配置请求管道*/ app, IWebHostEnvironment/*主机环境*/ env)
        {
            //也是委托 有 next
            app.Use(async (context, next) => //Next 是另外一个委托
            {
                await context.Response.WriteAsync("MiddleWare 1 Begin \r\n");
                await next();//把Context交给下一个  也就是Run();  找里面的方法体
                await context.Response.WriteAsync("MiddleWare 1 End \r\n");
            });

            app.Use(async (context, next) => //Next 是另外一个委托
            {
                await context.Response.WriteAsync("MiddleWare 2 Begin \r\n");
                await next();//把Context交给下一个  也就是Run();  找里面的方法体
                await context.Response.WriteAsync("MiddleWare 2 End \r\n");
            });

            //run 方法没有 next  添加终端中间件委托到管道中  终端中间件是专门用来短路请求管道的。是放在最后面的
            //没有终端中间件的报错才是 真的最终中间件，作用只是报错。
            app.Run(async context =>
            {
                //中间件其实就是个委托
                await context.Response.WriteAsync("this Is Run Function Response \r\n");
            });//添加中间件到管道中



            //判断环境名称 是不是Development
            if (env.IsDevelopment())
            {
                //开发环境异常页面中间件
                app.UseDeveloperExceptionPage();
            }

            //路由中间件  端点（终结点）路由中间件。3.x特性
            app.UseRouting();

            //在其中还可以添加其他中间件
            /*
             * 自定义中间件
             * 约定：具有类型为RequestDelegate的参数的公共构造函数
             * 名为Invoke或者InvokeAsync的方法 =>必须返回Task 是异步的 必须有HttpContext参数，而且是第一个
             */

            //通用的添加中间件的方法
            app.UseMiddleware<TestMiddleware>();
            app.UseTest();

            //端点（终结点）中间件 这里是配置，配置中间件和路由之间的关系 映射 
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
