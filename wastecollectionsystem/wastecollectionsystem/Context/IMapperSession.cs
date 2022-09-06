using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using wastecollectionsystem.Models;
using Container = wastecollectionsystem.Models.Container;

namespace wastecollectionsystem.Context
{
    public interface IMapperSession
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void CloseTransaction();
        void Save(Vehicle entity);
        void Update(Vehicle entity);
        void Delete(Vehicle entity);

        void Save(Container entity);
        void Update(Container entity);
        void Delete(Container entity);

        IQueryable<Container> Containers { get; }
        IQueryable<Vehicle> Vehicles { get; }

    }
}