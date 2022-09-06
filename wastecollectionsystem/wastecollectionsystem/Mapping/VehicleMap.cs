using wastecollectionsystem.Models;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace wastecollectionsystem.Mapping
{
    public class VehicleMap : ClassMapping<Vehicle>
    {
        public VehicleMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int64);
                x.Column("id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);

            });

            Property(x => x.VehicleName, x => {
                x.Type(NHibernateUtil.String);
                x.Column("vehiclename");
                x.Length(50);
                x.NotNullable(true);
            });

            Property(x => x.VehiclePlate, x => {
                x.Type(NHibernateUtil.String);
                x.Column("vehicleplate");
                x.Length(14);
                x.NotNullable(true);
            });

            Table("vehicle");
        }

    }
}
