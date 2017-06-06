using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Restoran;
using RestoranApi.ViewModel.UnitViewModel;

namespace RestoranApi.Controllers
{
    [RoutePrefix("unit")]
    public class UnitController : ApiController
    {
        private RestoranContext context;
        public UnitController()
        {
            context = new RestoranContext();
        }

        public IEnumerable<UnitViewModel> GetAllUnits()
        {
            var units = context.Unit.ToList();
            var model = units.Select(x => new UnitViewModel
            {
                Id=x.UnitId,
                Name=x.Name,
                Symbol=x.Symbol,
            });
            return model;
        }
    }
}
