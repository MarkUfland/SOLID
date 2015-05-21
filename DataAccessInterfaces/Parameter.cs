using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    public class Parameter
    {
        public Parameter(String name, Object value, DbType dbType, ParameterDirection direction, int size, bool nullable, byte precision, byte scale)
        {
            this.Name = name;
            this.Value = value;
            this.DbType = dbType;
            this.Direction = direction;
            this.Size = size;
            this.Nullable = nullable;
            this.Precision = precision;
            this.Scale = scale;
        }

        public Parameter(String name, Object value, DbType dbType, ParameterDirection direction)
            : this(name, value, dbType, direction,
                    (value == null) ? 0 : value.ToString().Length
                    , false, 0, 0)
        {


        }

        public Parameter(String name, Object value)
            : this(name, value, DbType.String, ParameterDirection.Input)
        {
        }

        public Parameter(String name, Object value, Criteria criteria)
        {
            this.Name = name;
            this.Value = value;
            this.Criteria = criteria;
        }

        public Parameter()
        {

        }

        public string Name { get; set; }

        public Object Value { get; set; }

        public DbType DbType { get; set; }

        public ParameterDirection Direction { get; set; }

        public int? Size { get; set; }

        public bool? Nullable { get; set; }

        public byte? Precision { get; set; }

        public byte? Scale { get; set; }

        public Criteria Criteria { get; set; }
    }
}
