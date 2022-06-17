using Aplications.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplications.Services
{
    public interface IComissionsService
    {
        ComissionResponseDTO[] CalculateCommissions(List<SaleRequestDTO> dataTransferObject);
    }
}
