using System;
using System.Collections.Generic;
using System.Linq;
using wastecollectionsystem.Context;
using wastecollectionsystem.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace AtikYonetimSistemi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ContainerController : ControllerBase
    {
        private readonly IMapperSession session;


        public ContainerController(IMapperSession session)
        {
            this.session = session;

        }

        //get all containers
        [HttpGet]
        public List<Container> Get()
        {
            var containers = session.Containers.ToList();

            return containers;
        }

        // get containers which have this id
        [HttpGet("{id}")]
        public Container GetById(int id)
        {
            var container = session.Containers.Where(x => x.Id == id).FirstOrDefault();
            return container;
        }

        //get containers which have this vehicle id
        [HttpGet("id/{vehicleid}")]
        public List<Container> GetContainerByVehicleId(int vehicleid)
        {
            List<Container> containers = session.Containers.Where(x => x.VehicleId == vehicleid).ToList();
            return containers;
        }

        //add container
        [HttpPost]
        public void Post([FromBody] Container container)
        {
            try
            {
                session.BeginTransaction();
                session.Save(container);
                session.Commit();
            }
            catch (Exception ex)
            {
                session.Rollback();
                Log.Error(ex, "Post Error");

            }
            finally
            {
                session.CloseTransaction();
            }
        }

        //update vehicle which have this id
        [HttpPut]
        public ActionResult<Container> Put([FromBody] Container request)
        {
            Container container = session.Containers.Where(x => x.Id == request.Id).FirstOrDefault();
            if (container == null)
            {
                return NotFound();
            }

            try
            {
                session.BeginTransaction();

                container.ContainerName = request.ContainerName;
                container.Latitude = request.Latitude;
                container.Longitude = request.Longitude;

                session.Update(container);

                session.Commit();
            }
            catch (Exception ex)
            {
                session.Rollback();
                Log.Error(ex, " Update Error");

            }
            finally
            {
                session.CloseTransaction();
            }

            return Ok();
        }

        //delete container which have this id 
        [HttpDelete("{id}")]
        public ActionResult<Container> Delete(int id)
        {
            Container container = session.Containers.Where(x => x.Id == id).FirstOrDefault();
            if (container == null)
            {
                return NotFound();
            }

            try
            {
                session.BeginTransaction();
                session.Delete(container);
                session.Commit();
            }
            catch (Exception ex)
            {
                session.Rollback();
                Log.Error(ex, "Delete Error");
            }
            finally
            {
                session.CloseTransaction();
            }

            return Ok();

        }


    }

}