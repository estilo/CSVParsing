using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Engine;
using NHibernate.Id;

namespace DBLayer.Models.Map
{
    public class GuidStringGenerator : IIdentifierGenerator
    {
        public object Generate(ISessionImplementor session, object obj)
        {
            return new GuidCombGenerator().Generate(session, obj).ToString();
        }

    }
}
