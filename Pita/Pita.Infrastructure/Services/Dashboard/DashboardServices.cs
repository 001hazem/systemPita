using Microsoft.EntityFrameworkCore;
using Pita.Core.ViewModels;
using Pita.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pita.Infrastructure.Services.Dashboard
{
   public class DashboardServices : IDashboardServices
    {

        private readonly PitaDbContext _db;

        public DashboardServices(PitaDbContext db)
        {
            _db = db;
        }

        public async Task<DashboardViewModels> GetData()
        {
            var data = new DashboardViewModels();
            data.CountZones = await _db.Zones.CountAsync(x => !x.IsDelete);
            data.CountCatougres = await _db.Categories.CountAsync(x => !x.IsDelete);
            
            return data;
        }



    }
}
