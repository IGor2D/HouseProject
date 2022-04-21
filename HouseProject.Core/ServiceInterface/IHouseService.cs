using HouseProject.Core.Domain;
using HouseProject.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HouseProject.Core.ServiceInterface
{
    public interface IHouseService : IApplicationService
    {
        Task<House> Add(HouseDto dto);

        Task<House> Delete(Guid id);

        Task<House> Update(HouseDto dto);

        Task<House> GetAsync(Guid id);
    }
}
