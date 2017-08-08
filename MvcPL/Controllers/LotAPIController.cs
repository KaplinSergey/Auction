using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using MvcPL.Infrastructure.Mappers;
using MvcPL.ViewModels;

namespace MvcPL.Controllers
{
    public class LotAPIController : ApiController
    {
        private readonly ILotService _lotService;
        public LotAPIController(ILotService lotService)
        {
            _lotService = lotService;
        }


        [HttpGet]
        public IEnumerable<LotViewModel> GetLots()
        {
            return _lotService.GetAllLotEntities().Select(l => l.ToMvcLot()).ToList();
        }

        //[HttpGet]
        //public string GetTest()
        //{
        //    return "Test";
        //}
        //// GET api/lotapi/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/lotapi
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/lotapi/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/lotapi/5
        //public void Delete(int id)
        //{
        //}
    }
}
