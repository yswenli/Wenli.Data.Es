# Wenli.Data.Es
Wenli.Data.Es ��Elastic Search��һ��������������װ�⣬����ʹ���߸��ӿ�ݷ���Ľ��뵽Elastic Search��.

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
            Console.WriteLine($"�����ͻ���");

            //�����ͻ���
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
                Description = "�¾�����Ѷ �ݹ�������ί��վ��Ϣ��11��10��0��24ʱ��31��ʡ(��������ֱϽ��)���½�����������ű�������ȷ�ﲡ��17�������о������벡��16��(���6�����Ϻ�5�����Ĵ�2��������1��������1��������1��)����������1��(�ڰ���);��������������;���������Ʋ������¾�����Ѷ �ݹ�������ί��վ��Ϣ��11��10��0��24ʱ��31��ʡ(��������ֱϽ��)���½�����������ű�������ȷ�ﲡ��17�������о������벡��16��(���6�����Ϻ�5�����Ĵ�2��������1��������1��������1��)����������1��(�ڰ���);��������������;���������Ʋ������¾�����Ѷ �ݹ�������ί��վ��Ϣ��11��10��0��24ʱ��31��ʡ(��������ֱϽ��)���½�����������ű�������ȷ�ﲡ��17�������о������벡��16��(���6�����Ϻ�5�����Ĵ�2��������1��������1��������1��)����������1��(�ڰ���);��������������;���������Ʋ������¾�����Ѷ �ݹ�������ί��վ��Ϣ��11��10��0��24ʱ��31��ʡ(��������ֱϽ��)���½�����������ű�������ȷ�ﲡ��17�������о������벡��16��(���6�����Ϻ�5�����Ĵ�2��������1��������1��������1��)����������1��(�ڰ���);��������������;���������Ʋ�����"
            };

            //���ʵ��
            var result = await esClient.AddAsync(p);
            Console.WriteLine($"AddAsync:{result}");

            //��ȡʵ��
            var pp = await esClient.GetAsync<Person>(p.ESID);
            Console.WriteLine($"GetAsync:{pp.Name}");

            //�Ƴ�ʵ��
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


            //��ѯʵ��
            var ps = await esClient.SearchAsync<Person>("yswenli", 0, 1000);
            Console.WriteLine($"SearchAsync:{ps?.Count()}");
            Console.Read();

        }
    }
}


```
