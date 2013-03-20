using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace HQAccessPoint.DAL.DTO
{
    //этот аттрибут необходим для правильной сериализации в JSON
    [DataContract]
    public class WidgetDTO
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public WidgetMetada MetaData {get; set;}

        /// <summary>
        /// Конструктор ьез параметров нужен для успешной дериализации
        /// </summary>
        public WidgetDTO()
        {
        }

        public WidgetDTO(Widget obj)
        {

        }

        public Widget GetObject()
        {
            throw new NotImplementedException();
        }
    }
}
