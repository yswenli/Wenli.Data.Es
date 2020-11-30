/****************************************************************************
*项目名称：Wenli.Data.Es
*CLR 版本：4.0.30319.42000
*机器名称：WALLE-PC
*命名空间：Wenli.Data.Es
*类 名 称：ESClientFactory
*版 本 号：V1.0.0.0
*创建人： yswenli
*电子邮箱：yswenli@outlook.com
*创建时间：2020/9/3 14:17:30
*描述：
*=====================================================================
*修改时间：2020/9/3 14:17:30
*修 改 人： yswenli
*版 本 号： V1.0.0.0
*描    述：
*****************************************************************************/
using Wenli.Data.Es.Core;

namespace Wenli.Data.Es
{
    /// <summary>
    /// IESClient工厂类
    /// </summary>
    public static class ESClientFactory
    {
        static object _locker = new object();

        static IESClient _esClient;

        /// <summary>
        /// IESClient工厂类
        /// </summary>
        static ESClientFactory()
        {
            _esClient = null;
        }

        /// <summary>
        /// 创建 IESClient
        /// </summary>
        /// <param name="esConfig"></param>
        /// <returns></returns>
        public static IESClient Create(ESConfig esConfig)
        {
            lock (_locker)
            {
                if (_esClient == null)
                    _esClient = new ESClient(esConfig);
                return _esClient;
            }
        }
    }
}
