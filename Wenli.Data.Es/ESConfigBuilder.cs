/****************************************************************************
*项目名称：Wenli.Data.Es
*CLR 版本：4.0.30319.42000
*机器名称：WALLE-PC
*命名空间：Wenli.Data.Es
*类 名 称：ESConfigBuilder
*版 本 号：V1.0.0.0
*创建人： yswenli
*电子邮箱：yswenli@outlook.com
*创建时间：2020/9/3 14:13:17
*描述：
*=====================================================================
*修改时间：2020/9/3 14:13:17
*修 改 人： yswenli
*版 本 号： V1.0.0.0
*描    述：
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace Wenli.Data.Es
{
    /// <summary>
    /// ESConfigBuilder
    /// </summary>
    public class ESConfigBuilder
    {
        ESConfig _esConfig;

        /// <summary>
        /// ESConfigBuilder
        /// </summary>
        public ESConfigBuilder()
        {
            _esConfig = new ESConfig();
        }

        /// <summary>
        /// 启用池化
        /// </summary>
        /// <returns></returns>
        public ESConfigBuilder UsePool()
        {
            _esConfig.Pooled = true;
            return this;
        }

        /// <summary>
        /// 设置服务器地址
        /// </summary>
        /// <param name="servers"></param>
        /// <returns></returns>
        public ESConfigBuilder SetServer(string servers)
        {
            _esConfig.Servers = servers;
            return this;
        }
        /// <summary>
        /// 设置用户名
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public ESConfigBuilder SetUserName(string userName)
        {
            _esConfig.UserName = userName;
            return this;
        }
        /// <summary>
        /// 设置密码
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public ESConfigBuilder SetPassword(string password)
        {
            _esConfig.Password = password;
            return this;
        }
        /// <summary>
        /// 设置超时
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public ESConfigBuilder SetTimeout(int timeout)
        {
            _esConfig.Timeout = timeout;
            return this;
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <returns></returns>
        public ESConfig Build()
        {
            return _esConfig;
        }

    }
}
