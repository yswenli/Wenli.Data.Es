/****************************************************************************
*项目名称：Wenli.Data.Es.Models
*CLR 版本：4.0.30319.42000
*机器名称：WALLE-PC
*命名空间：Wenli.Data.Es.Models
*类 名 称：Hits2
*版 本 号：V1.0.0.0
*创建人： yswenli
*电子邮箱：yswenli@outlook.com
*创建时间：2020/9/3 16:38:56
*描述：
*=====================================================================
*修改时间：2020/9/3 16:38:56
*修 改 人： yswenli
*版 本 号： V1.0.0.0
*描    述：
*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Wenli.Data.Es.Models
{
    [DataContract]
    public class Hits<T> where T : IESEntity
    {

        [DataMember(Name = "total")]
        public Total Total { get; set; }

        [DataMember(Name = "max_score")]
        public double MaxScore { get; set; }

        [DataMember(Name = "hits")]
        public IList<Hit<T>> List { get; set; }
    }
}
