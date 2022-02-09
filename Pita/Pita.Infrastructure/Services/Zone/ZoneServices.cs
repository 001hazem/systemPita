using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pita.Core.Dto;
using Pita.Core.Dtos;
using Pita.Core.Exceptions;
using Pita.Core.ViewModels;
using Pita.Data.Models;
using Pita.Infrastructure.Services.Zone;
using Pita.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pita.Infrastructure
{
   public class ZoneServices: IZoneServices
    {
        private readonly PitaDbContext _db;
        private readonly IMapper _mapper;

        public ZoneServices(PitaDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<List<ZoneViewModel>> GetZoneList()
        {
            var zones = await _db.Zones.Where(x => !x.IsDelete).ToListAsync();
            return _mapper.Map<List<ZoneViewModel>>(zones);
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Zones.Where(x => !x.IsDelete && (x.Name.Contains(query.GeneralSearch) || string.IsNullOrWhiteSpace(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var zone = _mapper.Map<List<ZoneViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = zone,
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


        public async Task<int> Create(CreateZoneDto dto)
        {
            var zone = _mapper.Map<Zone>(dto);
            await _db.Zones.AddAsync(zone);
            await _db.SaveChangesAsync();
            return zone.Id;
        }


        public async Task<int> Update(UpdateZoneDto dto)
        {
            var zone = await _db.Zones.SingleOrDefaultAsync(x => !x.IsDelete && x.Id == dto.Id);
            if (zone == null)
            {
                throw new EntityNotFoundException();
            }
            var updatedZone = _mapper.Map<UpdateZoneDto, Zone>(dto, zone);
            _db.Zones.Update(updatedZone);
            await _db.SaveChangesAsync();
            return updatedZone.Id;
        }


        public async Task<UpdateZoneDto> Get(int Id)
        {
            var zone = await _db.Zones.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (zone == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UpdateZoneDto>(zone);
        }


        public async Task<int> Delete(int Id)
        {
            var zone = await _db.Zones.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (zone == null)
            {
                throw new EntityNotFoundException();
            }
            zone.IsDelete = true;
            _db.Zones.Update(zone);
            await _db.SaveChangesAsync();
            return zone.Id;
        }
    }
}
