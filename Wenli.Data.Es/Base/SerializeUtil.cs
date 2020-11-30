/****************************************************************************
*项目名称：Wenli.Data.Es.Base
*CLR 版本：4.0.30319.42000
*机器名称：WALLE-PC
*命名空间：Wenli.Data.Es.Base
*类 名 称：SerializeUtil
*版 本 号：V1.0.0.0
*创建人： yswenli
*电子邮箱：yswenli@outlook.com
*创建时间：2020/9/3 15:09:11
*描述：
*=====================================================================
*修改时间：2020/9/3 15:09:11
*修 改 人： yswenli
*版 本 号： V1.0.0.0
*描    述：
*****************************************************************************/
using Wenli.Data.Es.Base.Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wenli.Data.Es.Base
{
    /// <summary>
    /// 序列化功能类
    /// </summary>
    public static class SerializeUtil
    {
        /// <summary>
        ///     newton.json序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize(object obj)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ObjectCreationHandling = ObjectCreationHandling.Replace;
            settings.DateFormatString = "yyyy-MM-dd HH:mm:ss.fff";
            return JsonConvert.SerializeObject(obj, settings);
        }

        /// <summary>
        ///     newton.json反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string json)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ObjectCreationHandling = ObjectCreationHandling.Replace;
            settings.DateFormatString = "yyyy-MM-dd HH:mm:ss.fff";
            return JsonConvert.DeserializeObject<T>(json, settings);
        }

        /// <summary>
        ///     newton.json反序列化
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type">反序列化的类型</param>
        /// <returns></returns>
        public static object Deserialize(string json, Type type)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ObjectCreationHandling = ObjectCreationHandling.Replace;
            settings.DateFormatString = "yyyy-MM-dd HH:mm:ss.fff";
            return JsonConvert.DeserializeObject(json, type, settings);
        }
    }
}
