using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pita.Core.Dtos;
using Pita.Core.Exceptions;
using Pita.Core.ViewModels;
using Pita.Data.Models;
using Pita.Infrastructure.Services.Category;
using Pita.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pita.Infrastructure
{
    public class CategoryServices : ICategoryServices
    {

        private readonly PitaDbContext _db;
        private readonly IMapper _mapper;

        public CategoryServices(PitaDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<List<CategoryViewModel>> GetCategoryList()
        {
            var categories = await _db.Categories.Where(x => !x.IsDelete).ToListAsync();
            return _mapper.Map<List<CategoryViewModel>>(categories);
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Categories.Where(x => !x.IsDelete && (x.Name.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var categories = _mapper.Map<List<CategoryViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = categories,
                meta = new Meta
                {
                    page = pagination.Page,
                    perpage = pagination.PerPage,
                    pages = pages,
                    total = dataCount,
                }
            };
            return result;
        }


        public async Task<int> Create(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return category.Id;
        }


        public async Task<int> Update(UpdateCategoryDto dto)
        {
            var category = await _db.Categories.SingleOrDefaultAsync(x => !x.IsDelete && x.Id == dto.Id);
            if (category == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedCategory = _mapper.Map<UpdateCategoryDto, Category>(dto, category);
            _db.Categories.Update(updatedCategory);
            await _db.SaveChangesAsync();
            return updatedCategory.Id;
        }


        public async Task<UpdateCategoryDto> Get(int Id)
        {
            var category = await _db.Categories.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (category == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateCategoryDto>(category);
        }


        public async Task<int> Delete(int Id)
        {
            var category = await _db.Categories.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (category == null)
            {
                throw new EntityNotFoundException();
            }
            category.IsDelete = true;
            _db.Categories.Update(category);
            await _db.SaveChangesAsync();
            return category.Id;
        }


    }
}
