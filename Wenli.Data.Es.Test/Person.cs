/****************************************************************************
*项目名称：Im.Data.Es.Test
*CLR 版本：4.0.30319.42000
*机器名称：WALLE-PC
*命名空间：Im.Data.Es.Test
*类 名 称：Person
*版 本 号：V1.0.0.0
*创建人： yswenli
*电子邮箱：yswenli@outlook.com
*创建时间：2020/9/3 15:18:43
*描述：
*=====================================================================
*修改时间：2020/9/3 15:18:43
*修 改 人： yswenli
*版 本 号： V1.0.0.0
*描    述：
*****************************************************************************/
using Wenli.Data.Es.Models;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Wenli.Data.Es.Test
{
    [DataContract]
    public class Person : IESEntity
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool Gender { get; set; }
        [DataMember]
        public DateTime Birthday { get; set; }
        [DataMember]
        public DateTime Created { get; set; }
        public string ESID { get; set; }

        public string Description { get; set; }
    }
}
