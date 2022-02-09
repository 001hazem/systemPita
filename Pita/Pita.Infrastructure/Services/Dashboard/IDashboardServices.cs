using Pita.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pita.Infrastructure.Services.Dashboard
{
   public interface IDashboardServices
    {

        Task<DashboardViewModels> GetData();


    }
}
