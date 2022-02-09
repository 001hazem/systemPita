using Pita.Core.Dtos;
using Pita.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pita.Infrastructure.Services.Category
{
   public interface ICategoryServices
    {
        Task<ResponseDto> GetAll(Pagination pagination, Query query);

        Task<int> Create(CreateCategoryDto dto);

        Task<int> Update(UpdateCategoryDto dto);

        Task<UpdateCategoryDto> Get(int Id);

        Task<List<CategoryViewModel>> GetCategoryList();

        Task<int> Delete(int Id);



    }
}
