# Wenli.Data.Es
Wenli.Data.Es ��Elastic Search��һ��������������װ�⣬����ʹ���߸��ӿ�ݷ���Ľ��뵽Elastic Search��.

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
                 .SetServer("10.205.108.137:9200,10.205.46.139:9200,10.205.46.140:9200")
                 .SetUserName("elastic")
                 .SetPassword("SjCSCK0MW7A2d0hjWqIh")
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
