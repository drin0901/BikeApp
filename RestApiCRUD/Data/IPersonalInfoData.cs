using RestApiCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCRUD.PersonalInfoData
{
    public interface IPersonalInfoData
    {
        List<PersonalInfo> GetPersonalInfoList();

        PersonalInfo GetPersonalInfo(int? id);

        PersonalInfo AddPersonalInfo(PersonalInfo obj);

        PersonalInfo EditPersonalInfo(PersonalInfo obj);

        void DeletePersonalInfo(PersonalInfo obj);

    }
}
