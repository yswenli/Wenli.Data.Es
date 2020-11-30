# Wenli.Data.Es
Wenli.Data.Es 是Elastic Search的一个轻量级操作封装库，方便使用者更加快捷方便的接入到Elastic Search中.

[![NuGet version (Wenli.Data.Es)](https://img.shields.io/nuget/v/Wenli.Data.Es.svg?style=flat-square)](https://www.nuget.org/packages?q=Wenli.Data.Es)
[![License](https://img.shields.io/badge/license-Apache%202-4EB1BA.svg)](https://www.apache.org/licenses/LICENSE-2.0.html)

```CSharp
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Wenli.Data.Es.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Wenli.Data.Es.Test";
            Console.WriteLine("Wenli.Data.Es.Test");

            _ = ESTest();


            Console.ReadLine();
        }


        static async Task ESTest()
        {
            Console.WriteLine($"创建客户端");

            //创建客户端
            var esConfig = new ESConfigBuilder()
                 .UsePool()
                 .SetServer("127.0.0.1")
                 .SetUserName("elastic")
                 .SetPassword("12321")
                 .SetTimeout(2)
                 .Build();

            var esClient = ESClientFactory.Create(esConfig);

            //Person
            var p = new Person()
            {
                ESID = Guid.NewGuid().ToString("N"),
                Birthday = new DateTime(2000, 1, 1),
                Created = DateTime.Now,
                Gender = true,
                Name = "yswenli",
                Description = "新京报快讯 据国家卫健委网站消息，11月10日0—24时，31个省(自治区、直辖市)和新疆生产建设兵团报告新增确诊病例17例，其中境外输入病例16例(天津6例，上海5例，四川2例，辽宁1例，江苏1例，陕西1例)，本土病例1例(在安徽);无新增死亡病例;无新增疑似病例。新京报快讯 据国家卫健委网站消息，11月10日0—24时，31个省(自治区、直辖市)和新疆生产建设兵团报告新增确诊病例17例，其中境外输入病例16例(天津6例，上海5例，四川2例，辽宁1例，江苏1例，陕西1例)，本土病例1例(在安徽);无新增死亡病例;无新增疑似病例。新京报快讯 据国家卫健委网站消息，11月10日0—24时，31个省(自治区、直辖市)和新疆生产建设兵团报告新增确诊病例17例，其中境外输入病例16例(天津6例，上海5例，四川2例，辽宁1例，江苏1例，陕西1例)，本土病例1例(在安徽);无新增死亡病例;无新增疑似病例。新京报快讯 据国家卫健委网站消息，11月10日0—24时，31个省(自治区、直辖市)和新疆生产建设兵团报告新增确诊病例17例，其中境外输入病例16例(天津6例，上海5例，四川2例，辽宁1例，江苏1例，陕西1例)，本土病例1例(在安徽);无新增死亡病例;无新增疑似病例。"
            };

            //添加实体
            var result = await esClient.AddAsync(p);
            Console.WriteLine($"AddAsync:{result}");

            //获取实体
            var pp = await esClient.GetAsync<Person>(p.ESID);
            Console.WriteLine($"GetAsync:{pp.Name}");

            //移除实体
            result = await esClient.DelAsync<Person>(p.ESID);
            Console.WriteLine($"DelAsync:{result}");


            //
            for (int i = 0; i < 10; i++)
            {
                var sp = new Person()
                {
                    ESID = Guid.NewGuid().ToString("N"),
                    Birthday = new DateTime(2000, 1, 1),
                    Created = DateTime.Now,
                    Gender = true,
                    Name = "yswenli",
                    Description = ""
                };
                //_ = await esClient.AddAsync(sp);
            }


            //查询实体
            var ps = await esClient.SearchAsync<Person>("yswenli", 0, 1000);
            Console.WriteLine($"SearchAsync:{ps?.Count()}");
            Console.Read();

        }
    }
}


```
