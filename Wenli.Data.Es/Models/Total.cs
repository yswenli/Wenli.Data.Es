/****************************************************************************
*项目名称：Wenli.Data.Es.Models
*CLR 版本：4.0.30319.42000
*机器名称：WALLE-PC
*命名空间：Wenli.Data.Es.Models
*类 名 称：Total
*版 本 号：V1.0.0.0
*创建人： yswenli
*电子邮箱：yswenli@outlook.com
*创建时间：2020/9/3 16:37:45
*描述：
*=====================================================================
*修改时间：2020/9/3 16:37:45
*修 改 人： yswenli
*版 本 号： V1.0.0.0
*描    述：
*****************************************************************************/
using System.Runtime.Serialization;

namespace Wenli.Data.Es.Models
{
    [DataContract]
    public class Total
    {

        [DataMember(Name = "value")]
        public int Value { get; set; }

        [DataMember(Name = "relation")]
        public string Relation { get; set; }
    }
}
