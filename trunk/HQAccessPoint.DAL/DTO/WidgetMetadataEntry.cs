using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HQAccessPoint.DAL
{
    [DataContract]
    public class WidgetMetadataEntry
    {
        [DataMember]
        public string Key { get; set; }


        [DataMember]
        public string Value { get; set; }
    }
}
