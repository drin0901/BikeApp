using RestApiCRUD.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestApiCRUD.PersonalInfoData
{
    public class MockPersonalInfoData : IPersonalInfoData
    {
        private List<PersonalInfo> personalInfoList = new List<PersonalInfo>()
        {
            new PersonalInfo()
            {
                Id = 1,
                FirstName = "Aldrin",
                LastName = "Angeles",
                PhoneNumber = 09351409804
            },
            new PersonalInfo()
            {
                Id = 2,
                FirstName = "Ailyn",
                LastName = "Senal",
                PhoneNumber = 09051287739
            }
        };

        public PersonalInfo AddPersonalInfo(PersonalInfo obj)
        {
            personalInfoList.Add(obj);
            return obj;
        }

        public void DeletePersonalInfo(PersonalInfo obj)
        {
            personalInfoList.Remove(obj);
        }

        public PersonalInfo EditPersonalInfo(PersonalInfo obj)
        {
            var existingPersonalInfo = GetPersonalInfo(obj.Id);

            existingPersonalInfo.FirstName = obj.FirstName;
            existingPersonalInfo.LastName = obj.LastName;
            existingPersonalInfo.PhoneNumber = obj.PhoneNumber;
            existingPersonalInfo.EmailAddress = obj.EmailAddress;
            existingPersonalInfo.Address = obj.Address;
            existingPersonalInfo.BirthDay = obj.BirthDay;

            return existingPersonalInfo;

        }

        public PersonalInfo GetPersonalInfo(int? id)
        {
            return personalInfoList.SingleOrDefault(x => x.Id == id);
        }

        public List<PersonalInfo> GetPersonalInfoList()
        {
            return personalInfoList;
        }
    }
}
