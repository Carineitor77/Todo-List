using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TodoList.Api.Models;
using TodoList.Data.Entities;
using TodoList.Data.Repository;

namespace TodoList.Api.Controllers
{
    // TODO: return json format
    [Route("api/[controller]")]
    [ApiController]
    public class AffairsController : ControllerBase
    {
        public IRepository<Affair> contextAffairs { get; private set; }

        public AffairsController(IRepository<Affair> contextAffairs)
        {
            this.contextAffairs = contextAffairs;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Affair>> Get()
        {
            return contextAffairs.All.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Affair> Get(int id)
        {
            return contextAffairs.FindById(id);
        }

        [HttpPost]
        public void Post([FromBody]Affair affair)
        {
            // TODO: if unique title
            contextAffairs.Update(affair);
        }

        [HttpPut]
        public void Put([FromBody]InputModel model)
        {
            // TODO: if startDate < endDate
            // TODO: if unique title

            Affair affair = new Affair()
            {
                Title = model.Title,
                Annotation = model.Annotation,
                StartDate = DateTime.Now,
                EndDate = DateTime.Parse(model.EndDate),
            };

            contextAffairs.Add(affair);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Affair affair = contextAffairs.FindById(id);
            contextAffairs.Delete(affair);
        }
    }
}
