using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<PassportControlEntities>
    {
        protected override void Seed(PassportControlEntities context)
        {
            var places = new List<PlaceOfBirth>
            {
                new PlaceOfBirth { Id = 1, Name = "Москва", Code = 45 },
                new PlaceOfBirth { Id = 2, Name = "Санкт-Петербург", Code = 40 },
                new PlaceOfBirth { Id = 3, Name = "Нижний Новгород", Code = 77 },
                new PlaceOfBirth { Id = 4, Name = "Новосибирск", Code = 50 },
                new PlaceOfBirth { Id = 5, Name = "Рязань", Code = 61 },
                new PlaceOfBirth { Id = 6, Name = "Ярославль", Code = 78 },
                new PlaceOfBirth { Id = 7, Name = "Самара", Code = 36 },
                new PlaceOfBirth { Id = 8, Name = "Челябинск", Code = 75 },
                new PlaceOfBirth { Id = 9, Name = "Владивосток", Code = 05 },
                new PlaceOfBirth { Id = 10, Name = "Хабаровск", Code = 08 }
            };
            new List<PassportItem> {
                new PassportItem {Id = 1, Surname = "Громов", Name = "Анатолий", MiddleName = "Петрович", Birthday = new DateTime(1971, 09, 29),
                    DateOfIssue = new DateTime(1998, 04, 06), Series = "1508", Number = "647382", IssuaDepartmentCode = "157-456",
                    PlaceOfBirthId = 2, PlaceOfIssue = "ОВД Михайловского района", Sex = SexTypes.MALE },

                new PassportItem {Id = 2, Surname = "Акимова", Name = "Евгения", MiddleName = "Игоревна", Birthday = new DateTime(1969, 12, 20),
                    DateOfIssue = new DateTime(1998, 10, 12), Series = "1101", Number = "548454", IssuaDepartmentCode = "157-928",
                    PlaceOfBirthId = 1, PlaceOfIssue = "ОВД района Марьина Роща САО города Москвы", Sex = SexTypes.FEMALE },

                new PassportItem {Id = 3, Surname = "Калугина", Name = "Елена", MiddleName = "Руслановна", Birthday = new DateTime(1966, 05, 02),
                    DateOfIssue = new DateTime(2000, 08, 01), Series = "1744", Number = "920158", IssuaDepartmentCode = "036-654",
                    PlaceOfBirthId = 1, PlaceOfIssue = "УФМС района Жулебино ВАО города Москвы", Sex = SexTypes.FEMALE }
                }.ForEach(a => context.Passports.Add(a));
        }
    }
}