/****************************************************************************
*项目名称：Wenli.Data.Es
*CLR 版本：4.0.30319.42000
*机器名称：WALLE-PC
*命名空间：Wenli.Data.Es
*类 名 称：ESConfig
*版 本 号：V1.0.0.0
*创建人： yswenli
*电子邮箱：yswenli@outlook.com
*创建时间：2020/9/3 14:11:58
*描述：
*=====================================================================
*修改时间：2020/9/3 14:11:58
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
    /// ElasticsSearchConfig
    /// </summary>
    public class ESConfig
    {
        /// <summary>
        /// 是否启用Pool
        /// </summary>
        public bool Pooled { get; set; } = false;

        /// <summary>
        /// 服务器地址
        /// </summary>
        public string Servers { get; set; } = "127.0.0.1";
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = "elastic";
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } = "12321";
        /// <summary>
        /// 超时（秒）
        /// </summary>
        public int Timeout { get; set; } = 2;
    }
}
