/****************************************************************************
*项目名称：Wenli.Data.Es.Models
*CLR 版本：4.0.30319.42000
*机器名称：WALLE-PC
*命名空间：Wenli.Data.Es.Models
*类 名 称：Hit
*版 本 号：V1.0.0.0
*创建人： yswenli
*电子邮箱：yswenli@outlook.com
*创建时间：2020/9/3 16:38:23
*描述：
*=====================================================================
*修改时间：2020/9/3 16:38:23
*修 改 人： yswenli
*版 本 号： V1.0.0.0
*描    述：
*****************************************************************************/
using System.Runtime.Serialization;

namespace Wenli.Data.Es.Models
{
    [DataContract]
    public class Hit<T> where T : IESEntity
    {

        [DataMember(Name = "_index")]
        public string Index { get; set; }

        [DataMember(Name = "_type")]
        public string Type { get; set; }

        [DataMember(Name = "_id")]
        public string Id { get; set; }

        [DataMember(Name = "_score")]
        public double Score { get; set; }

        [DataMember(Name = "_source")]
        public T Data { get; set; }
    }
}
