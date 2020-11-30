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
using Wenli.Data.Es.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wenli.Data.Es.Core
{
    /// <summary>
    /// ElaticsSearch客户端
    /// </summary>
    public interface IESClient
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        Task<bool> AddAsync<T>(T t, string index) where T : IESEntity;

        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> AddAsync<T>(T t) where T : IESEntity;

        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        bool Add<T>(T t, string index) where T : IESEntity;

        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Add<T>(T t) where T : IESEntity;







        /// <summary>
        /// 批量添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        //Task<bool> BulkAsync<T>(IEnumerable<T> data) where T : IESEntity;


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        Task<bool> DelAsync(string id, string index);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DelAsync<T>(string esid) where T : IESEntity;


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="esid"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        bool Del(string esid, string index);

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="esid"></param>
        /// <returns></returns>
        bool Del<T>(string esid) where T : IESEntity;

        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string id, string index) where T : IESEntity;

        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string id) where T : IESEntity;

        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="esid"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        T Get<T>(string esid, string index) where T : IESEntity;

        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="esid"></param>
        /// <returns></returns>
        T Get<T>(string esid) where T : IESEntity;

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> SearchAsync<T>(object where, string index) where T : IESEntity;
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> SearchAsync<T>(object where) where T : IESEntity;
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="from"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> SearchAsync<T>(string name, int from, int size) where T : IESEntity;


        IEnumerable<T> Search<T>(object where, string index) where T : IESEntity;
    }
}