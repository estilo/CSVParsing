using FluentNHibernate.Mapping;

namespace DBLayer.Models.Map
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Id(x => x.Id);
                //.CustomType(typeof (string))
                //.GeneratedBy.Custom(typeof (GuidStringGenerator))
                //.Length(36);
            Map(x => x.FirstName);
            Map(x => x.LastName);
        }
    }

    //refer:https://gist.github.com/gshutler/353739
    //http://stackoverflow.com/questions/1995579/how-do-i-use-the-guid-comb-strategy-in-a-mysql-db
}