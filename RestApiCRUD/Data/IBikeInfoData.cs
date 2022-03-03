using WebAPI.Models;
using System.Collections.Generic;

namespace WebAPI.BikeInfoData
{
    public interface IBikeInfoData
    {
        List<BikeInfo> GetBikeInfoList();

        BikeInfo GetBikeInfo(int? id);

        BikeInfo AddBikeInfo(BikeInfo obj);

        BikeInfo EditBikeInfo(BikeInfo obj);

        void DeleteBikeInfo(BikeInfo obj);

    }
}
