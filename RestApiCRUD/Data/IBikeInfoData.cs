using WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
