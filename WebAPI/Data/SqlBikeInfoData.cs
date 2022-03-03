using WebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.BikeInfoData
{
    public class SqlBikeInfoData : IBikeInfoData
    {
        private BikeInfoContext _bikeInfoContext;
        public SqlBikeInfoData(BikeInfoContext BikeInfoContext)
        {
            _bikeInfoContext = BikeInfoContext;
        }
        public BikeInfo AddBikeInfo(BikeInfo obj)
        {
            obj.Id = null;
            _bikeInfoContext.BikeInfoList.Add(obj);
            _bikeInfoContext.SaveChanges();

            return obj;
        }

        public void DeleteBikeInfo(BikeInfo obj)
        {
            _bikeInfoContext.BikeInfoList.Update(obj);
            _bikeInfoContext.SaveChanges();
        }

        public BikeInfo EditBikeInfo(BikeInfo obj)
        {
            _bikeInfoContext.BikeInfoList.Update(obj);
            _bikeInfoContext.SaveChanges();

            return obj;
        }

        public BikeInfo GetBikeInfo(int? id)
        {
            var BikeInfo = _bikeInfoContext.BikeInfoList.Find(id);
            return BikeInfo;
        }

        public List<BikeInfo> GetBikeInfoList()
        {
           return _bikeInfoContext.BikeInfoList.Where(x => x.IsActive == true).ToList();
        }
    }
}
