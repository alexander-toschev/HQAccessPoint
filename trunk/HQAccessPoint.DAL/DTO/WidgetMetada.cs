using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HQAccessPoint.DAL.DTO
{
    [DataContract]
    public class WidgetMetada
    {
        [DataMember]
        public List<WidgetMetadataEntry> Options { get; set; }
    }
}
