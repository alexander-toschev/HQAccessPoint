using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQAccessPoint.Services.Contracts;
using HQAccessPoint.DAL;

namespace HQAccessPoint.Services
{
    public class WidgetService : IWidgetService 
    {
        public List<HQAccessPoint.DAL.DTO.WidgetDTO> GetAllWidgets()
        {
            throw new NotImplementedException();
            using (HQAccessPointContext ctx = new HQAccessPointContext())
            {
                ctx.Widgets.ToList().Select(w => DataAccessHelper.ToWidgetDTO(w));
            }
        }
    }
}
