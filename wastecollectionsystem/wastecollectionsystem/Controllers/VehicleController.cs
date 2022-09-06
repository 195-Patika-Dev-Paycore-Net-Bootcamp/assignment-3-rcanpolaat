using System;
using System.Linq;
using wastecollectionsystem.Context;
using wastecollectionsystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Serilog;

namespace wastecollectionsystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class VehicleController : ControllerBase
    {
        private readonly IMapperSession session;


        public VehicleController(IMapperSession session)
        {
            this.session = session;

        }

        //get all containers
        [HttpGet]
        public List<Vehicle> Get()
        {
            List<Vehicle> vehicles = session.Vehicles.ToList();
            return vehicles;
        }

        // get containers which have this id
        [HttpGet("{id}")]
        public Vehicle GetById(int id)
        {
            var vehicle = session.Vehicles.Where(x => x.Id == id).FirstOrDefault();
            return vehicle;
        }

        //add vehicle
        [HttpPost]
        public void Post([FromBody] Vehicle vehicle)
        {
            try
            {
                session.BeginTransaction();
                session.Save(vehicle);
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
        public ActionResult<Vehicle> Put([FromBody] Vehicle request)
        {
            Vehicle vehicle = session.Vehicles.Where(x => x.Id == request.Id).FirstOrDefault();
            if (vehicle == null)
            {
                return NotFound();
            }

            try
            {
                session.BeginTransaction();

                vehicle.VehicleName = request.VehicleName;
                vehicle.VehiclePlate = request.VehiclePlate;

                session.Update(vehicle);

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

        //delete vehicle which have this id
        [HttpDelete("{id}")]
        public ActionResult<Vehicle> Delete(int id)
        {
            Vehicle vehicle = session.Vehicles.Where(x => x.Id == id).FirstOrDefault();

            if (vehicle == null)
            {
                return NotFound();
            }

            try
            {
                session.BeginTransaction();
                session.Delete(vehicle);
                session.Commit();
                Container container = session.Containers.Where(x => x.VehicleId == vehicle.Id).FirstOrDefault(); //ayni vehicleIdye sahip container varsa onu da siliyor
                if (container != null)
                {
                    session.Delete(container);
                    session.Commit();
                }
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