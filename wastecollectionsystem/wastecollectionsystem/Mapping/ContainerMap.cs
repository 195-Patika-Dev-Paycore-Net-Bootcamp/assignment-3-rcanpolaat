using wastecollectionsystem.Models;
using NHibernate;
using NHibernate.Mapping;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace wastecollectionsystem.Mapping
{
    public class ContainerMap : ClassMapping<Container>
    {
        public ContainerMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int64);
                x.Column("id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(x => x.ContainerName, x => {
                x.Type(NHibernateUtil.String);
                x.Column("containername");
                x.Length(50);
                x.NotNullable(true);
            });

            Property(x => x.Latitude, x => {
                x.Type(NHibernateUtil.Double);
                x.Column("latitude");
                x.NotNullable(true);
            });

            Property(x => x.Longitude, x => {
                x.Type(NHibernateUtil.Double);
                x.Column("longitude");
                x.NotNullable(true);
            });

            Property(x => x.VehicleId,
               x =>
               {
                   x.Type(NHibernateUtil.Int64);
                   x.Column("vehicleid");
                   x.NotNullable(true);
               });

            Table("container");
        }
    }
}
