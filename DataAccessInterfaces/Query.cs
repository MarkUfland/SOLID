using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// This class is passed to the data access layer when you need to run
    /// an ad hoc stored procedure.  It contains the a QueryType parameter
    /// which lets the data access layer know which stored proc to run and
    /// a list of parameters that the data access layer can pass to the stored procedure
    /// </summary>
    public class Query
    {

        /// <summary>
        /// Stores a list of parameter objects
        /// </summary>
        IList<Parameter> _parameters;

        /// <summary>
        /// Get set the query type
        /// </summary>
        public QueryType TypeOfQuery { get; set; }

        /// <summary>
        /// Constructor that takes no arguments and initialises the parameters list
        /// </summary>
        public Query()
        {
            _parameters = new List<Parameter>();
        }

        /// <summary>
        /// Constructor that takes a query type and then calls the constructor with
        /// no parameters
        /// </summary>
        /// <param name="typeOfQuery">A query type object specifying the stored proc you want to run</param>
        public Query(QueryType typeOfQuery)
            : this()
        {
            this.TypeOfQuery = typeOfQuery;

        }

        /// <summary>
        /// This provides an iterator for the _parameters collection.  This enables client 
        /// code to loop through the collection of parameters
        /// </summary>
        /// <returns>A parameter enumerator</returns>
        public IEnumerable<Parameter> GetParameters()
        {
            foreach (Parameter p in _parameters)
            {
                yield return p;
            }
        }

        public IList<Parameter> GetParametersAsList()
        {
            return _parameters;
        }

        public void AddParameter(Parameter param)
        {
            _parameters.Add(param);
        }

        public Parameter GetParamByName(string name)
        {
            foreach (Parameter p in GetParameters())
            {
                if (p.Name == name)
                {
                    return p;
                }
            }

            return null;
        }
    }
}
