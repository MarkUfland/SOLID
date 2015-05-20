using DataAccessInterfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FXDataRepository : IDataRepository<FXData>
    {
        public void Create(FXData item)
        {
            throw new NotImplementedException();
        }

        public void Update(FXData item)
        {
            throw new NotImplementedException();
        }

        public void Delete(FXData item)
        {
            throw new NotImplementedException();
        }

        public IList<FXData> GetAll()
        {
            IList<FXData> data = new List<FXData>();

            FXData data1 = new FXData() { FXRate = 0.01m, FXDate = DateTime.Parse("19/01/2012") };
            FXData data2 = new FXData() { FXRate = 0.02m, FXDate = DateTime.Parse("20/01/2012") };

            data.Add(data1);
            data.Add(data2);

            return data;
        }

        public FXData GetByKey(object key)
        {
            return new FXData() { FXRate = 0.01m, FXDate = DateTime.Parse("17/01/2012") };
        }


        public IList<FXData> GetByCriteria(string query)
        {
            throw new NotImplementedException();
        }

        
    }
}
