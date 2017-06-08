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
        private readonly RestoranContext context;
        public UnitController()
        {
            this.context = new RestoranContext();
        }
        /// <summary>
        /// Получение списка единиц измерений
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("units")]
        public HttpResponseMessage GetAllUnits()
        {
            var units = context.Unit.ToList();
            var model = units.Select(x => new UnitViewModel
            {
                Id = x.UnitId,
                Name = x.Name,
                Symbol = x.Symbol,
            });
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
        /// <summary>
        /// Получение единицы измерения по Id
        /// </summary>
        /// <param name="unitId">Id единицы измерения</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{unitId:int}")]
        public HttpResponseMessage GetUnit(int unitId)
        {
            var entity = context.Unit.Find(unitId);
            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Единица измерения не найдена");
            }
            var model = new UnitViewModel();
            model.Name = entity.Name;
            model.Id = entity.UnitId;
            model.Symbol = entity.Symbol;
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
        /// <summary>
        /// Создание единицы измерения
        /// </summary>
        /// <param name="unit">Модель единицы измерения</param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(UnitViewModel unit)
        {
            var entity=new Unit();
            entity.Name = unit.Name;
            entity.Symbol = unit.Symbol;
            context.Unit.Add(entity);
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.Created);
        }
        /// <summary>
        /// Удаление единицы измерения по Id
        /// </summary>
        /// <param name="unitId">Id единицы измерения</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{unitId:int}")]
        public HttpResponseMessage Delete(int unitId)
        {
            var entity = context.Unit.Find(unitId);
            if (entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            context.Unit.Remove(entity);
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Обновление информации о единице измерения
        /// </summary>
        /// <param name="unit">Модель единицы измерения</param>
        /// <returns></returns>
        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(UnitViewModel unit)
        {
            var entity = context.Unit.Find(unit.Id);
            if(entity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            entity.Name = unit.Name;
            entity.Symbol = unit.Symbol;
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
