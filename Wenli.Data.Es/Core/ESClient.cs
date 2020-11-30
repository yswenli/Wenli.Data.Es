/****************************************************************************
*项目名称：Wenli.Data.Es.Core
*CLR 版本：4.0.30319.42000
*机器名称：WALLE-PC
*命名空间：Wenli.Data.Es.Core
*类 名 称：ESClient
*版 本 号：V1.0.0.0
*创建人： yswenli
*电子邮箱：yswenli@outlook.com
*创建时间：2020/9/3 14:17:56
*描述：
*=====================================================================
*修改时间：2020/9/3 14:17:56
*修 改 人： yswenli
*版 本 号： V1.0.0.0
*描    述：
*****************************************************************************/
using Elasticsearch.Net;
using Wenli.Data.Es.Base;
using Wenli.Data.Es.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wenli.Data.Es.Core
{
    /// <summary>
    /// ElaticsSearch客户端
    /// </summary>
    public class ESClient : IESClient
    {
        ESConfig _esConfig;

        ElasticLowLevelClient _lowlevelClient;

        /// <summary>
        /// ElaticsSearch客户端
        /// </summary>
        /// <param name="esConfig"></param>
        internal ESClient(ESConfig esConfig)
        {
            _esConfig = esConfig;

            ConnectionConfiguration settings;

            if (_esConfig.Pooled)
            {
                var arr = _esConfig.Servers.Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries);

                var uris = new Uri[arr.Length];

                for (int i = 0; i < arr.Length; i++)
                {
                    uris[i] = new Uri("http://" + arr[i]);
                }

                var connectionPool = new SniffingConnectionPool(uris);

                settings = new ConnectionConfiguration(connectionPool);
            }
            else
            {
                settings = new ConnectionConfiguration(new Uri("http://" + _esConfig.Servers));
            }

            settings.BasicAuthentication(_esConfig.UserName, _esConfig.Password);

            settings.RequestTimeout(TimeSpan.FromMinutes(_esConfig.Timeout));

            _lowlevelClient = new ElasticLowLevelClient(settings);
        }

        string GetLowerIndexName(string indexName)
        {
            return indexName.ToLower();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync<T>(T t, string index) where T : IESEntity
        {
            var response = await _lowlevelClient.IndexAsync<StringResponse>(GetLowerIndexName(index), t.ESID, PostData.Serializable(t));
            //Console.WriteLine(SerializeUtil.Serialize(response));
            return response.Success;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync<T>(T t) where T : IESEntity
        {
            return await AddAsync(t, typeof(T).Name);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool Add<T>(T t, string index) where T : IESEntity
        {
            var response = _lowlevelClient.Index<StringResponse>(GetLowerIndexName(index), t.ESID, PostData.Serializable(t));

            return response.Success;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Add<T>(T t) where T : IESEntity
        {
            return Add(t, typeof(T).Name);
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        //public async Task<bool> BulkAsync<T>(IEnumerable<T> data, string index) where T : IESEntity
        //{
        //    var inputs = new List<object>();

        //    foreach (var item in data)
        //    {
        //        inputs.Add(item);
        //    }

        //    var response = await _lowlevelClient.BulkAsync<StringResponse>(GetIndexName(index), PostData.MultiJson(inputs));

        //    Console.WriteLine($"BulkAsync index:{index},result:{SerializeUtil.Serialize(response)}");

        //    return response.Success;
        //}
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        //public async Task<bool> BulkAsync<T>(IEnumerable<T> data) where T : IESEntity
        //{
        //    return await BulkAsync(data, typeof(T).Name);
        //}

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="esid"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public async Task<bool> DelAsync(string esid, string index)
        {
            var response = await _lowlevelClient.DeleteAsync<StringResponse>(GetLowerIndexName(index), esid);

            return response.Success;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="esid"></param>
        /// <returns></returns>
        public async Task<bool> DelAsync<T>(string esid) where T : IESEntity
        {
            return await DelAsync(esid, typeof(T).Name);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="esid"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool Del(string esid, string index)
        {
            var response = _lowlevelClient.Delete<StringResponse>(GetLowerIndexName(index), esid);

            return response.Success;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="esid"></param>
        /// <returns></returns>
        public bool Del<T>(string esid) where T : IESEntity
        {
            return Del(esid, typeof(T).Name);
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="esid"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string esid, string index) where T : IESEntity
        {
            var response = await _lowlevelClient.GetAsync<StringResponse>(GetLowerIndexName(index), esid);

            if (response.Success)
            {
                var responseJson = response.Body;

                return SerializeUtil.Deserialize<ESResult<T>>(responseJson).Source;
            }
            return default(T);
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="esid"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string esid) where T : IESEntity
        {
            return await GetAsync<T>(esid, typeof(T).Name);
        }


        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="esid"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Get<T>(string esid, string index) where T : IESEntity
        {
            var response = _lowlevelClient.Get<StringResponse>(GetLowerIndexName(index), esid);

            if (response.Success)
            {
                var responseJson = response.Body;

                return SerializeUtil.Deserialize<ESResult<T>>(responseJson).Source;
            }
            return default(T);
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="esid"></param>
        /// <returns></returns>
        public T Get<T>(string esid) where T : IESEntity
        {
            return Get<T>(esid, typeof(T).Name);
        }

        /// <summary>
        /// 查询,
        /// https://www.elastic.co/guide/cn/elasticsearch/guide/current/search-in-depth.html
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> SearchAsync<T>(object where, string index) where T : IESEntity
        {
            var searchResponse = await _lowlevelClient.SearchAsync<StringResponse>(GetLowerIndexName(index), PostData.Serializable(where));

            if (searchResponse.Success)
            {
                var responseJson = searchResponse.Body;

                var result = SerializeUtil.Deserialize<SearchResult<T>>(responseJson);

                if (result.Hits.Total.Value > 0)
                {
                    var list = new List<T>();

                    foreach (var item in result.Hits.List)
                    {
                        list.Add(item.Data);
                    }

                    return list;
                }
            }
            return null;
        }

        /// <summary>
        /// 查询,
        /// https://www.elastic.co/guide/cn/elasticsearch/guide/current/search-in-depth.html
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> SearchAsync<T>(object where) where T : IESEntity
        {
            return await SearchAsync<T>(where, typeof(T).Name);
        }


        /// <summary>
        /// 查询,
        /// https://www.elastic.co/guide/cn/elasticsearch/guide/current/search-in-depth.html
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="from"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> SearchAsync<T>(string name, int from, int size) where T : IESEntity
        {
            return await SearchAsync<T>(new
            {
                from = from,
                size = size,
                query = new
                {
                    match = new
                    {
                        Name = new
                        {
                            query = name
                        }
                    }
                }
            }, typeof(T).Name);
        }


        /// <summary>
        /// 查询,
        /// https://www.elastic.co/guide/cn/elasticsearch/guide/current/search-in-depth.html
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public IEnumerable<T> Search<T>(object where, string index) where T : IESEntity
        {
            var searchResponse = _lowlevelClient.Search<StringResponse>(GetLowerIndexName(index), PostData.Serializable(where));

            if (searchResponse.Success)
            {
                var responseJson = searchResponse.Body;

                var result = SerializeUtil.Deserialize<SearchResult<T>>(responseJson);

                if (result.Hits.Total.Value > 0)
                {
                    var list = new List<T>();

                    foreach (var item in result.Hits.List)
                    {
                        list.Add(item.Data);
                    }

                    return list;
                }
            }
            return null;
        }
    }
}
