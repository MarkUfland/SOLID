using Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHDataAccess.MappingFiles
{
    public class FXDataMapper : ClassMap<FXData>
    {
        public FXDataMapper()
        {
            Table("FXData");
            Id(x => x.Id).Column("Id")
                                 .GeneratedBy
                                 .Identity();
            Map(x => x.FXRate);
            Map(x => x.FXDate);
            
        }
    }
}
