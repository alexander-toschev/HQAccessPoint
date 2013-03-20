using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using HQAccessPoint.DAL.DTO;
using System.ServiceModel;

namespace HQAccessPoint.Services.Contracts
{
    [ServiceContract(Namespace = "")]
    public interface IWidgetService
    {
        [OperationContract]
        List<WidgetDTO> GetAllWidgets();
    }
}
