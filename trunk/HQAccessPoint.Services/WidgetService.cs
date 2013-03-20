using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using HQAccessPoint.DAL.DTO;
using HQAccessPoint.Services.Contracts;
using HQAccessPoint.DAL;

namespace HQAccessPoint.Services
{
    //Этот аттрибут необходим для того, чтобы можно было отправлять JSON на клиента
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WidgetService : IWidgetService
    {
        public List<HQAccessPoint.DAL.DTO.WidgetDTO> GetAllWidgets()
        {
            return new List<WidgetDTO>() { new WidgetDTO() { Name = "test1", MetaData = new WidgetMetada() { Options = new List<WidgetMetadataEntry>() { new WidgetMetadataEntry() { Key = "url", Value = "lch" } } } }, new WidgetDTO() { Name = "test2" } };
            using (HQAccessPointContext ctx = new HQAccessPointContext())
            {
                ctx.Widgets.ToList().Select(w => DataAccessHelper.ToWidgetDTO(w));
            }
        }
    }
}
