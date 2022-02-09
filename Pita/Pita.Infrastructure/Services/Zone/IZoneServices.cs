using Pita.Core.Dto;
using Pita.Core.Dtos;
using Pita.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pita.Infrastructure.Services.Zone
{
   public interface IZoneServices
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);
        Task<int> Create(CreateZoneDto dto);
        Task<int> Update(UpdateZoneDto dto);

        Task<UpdateZoneDto> Get(int Id);

        Task<List<ZoneViewModel>> GetZoneList();

       Task<int> Delete(int Id);
    }
}
