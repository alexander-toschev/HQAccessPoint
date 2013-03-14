using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HQAccessPoint.DAL.DTO;
using System.ServiceModel;

namespace HQAccessPoint.Services.Contracts
{
    [ServiceContract]
    public interface IWidgetService
    {
        [OperationContract]
        List<WidgetDTO> GetAllWidgets();
    }
}
