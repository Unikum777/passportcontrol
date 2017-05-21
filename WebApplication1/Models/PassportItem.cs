using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication1.Models
{
    public enum SexTypes
    {
        MALE,
        FEMALE
    }
    public class CustomDateAttribute : RangeAttribute
    {
        public CustomDateAttribute()
          : base(typeof(DateTime),
                  DateTime.Now.AddYears(-120).ToShortDateString(),
                  DateTime.Now.AddYears(-14).ToShortDateString())
        { }
    }
    public class DateLessThanNowAttribute : RangeAttribute
    {
        public DateLessThanNowAttribute()
          : base(typeof(DateTime),
                  DateTime.Now.AddYears(-120).ToShortDateString(),
                  DateTime.Now.ToShortDateString())
        { }
    }
    public class PassportItem : IComparable
    {
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            PassportItem otherTemperature = obj as PassportItem;
            if (otherTemperature != null)
                return this.Surname.CompareTo(otherTemperature.Surname);
            else
                throw new ArgumentException("Object is not a PassportItem");
        }
        public int Id { get; set; }

        [DisplayName("Фамилия")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [RegularExpression(@"^[\p{IsCyrillic}]{1,40}$", ErrorMessage = "Допускается только кириллица, длина поля до 40 симв.")]
        public string Surname { get; set; }

        [DisplayName("Имя")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [RegularExpression(@"^[\p{IsCyrillic}]{1,60}$", ErrorMessage = "Допускается только кириллица, длина поля до 60 симв.")]
        public string Name { get; set; }

        [DisplayName("Отчество")]
        [RegularExpression(@"^[\p{IsCyrillic}]{0,40}$", ErrorMessage = "Допускается только кириллица, длина поля до 40 симв.")]
        public string MiddleName { get; set; }

        [DisplayName("Дата рождения")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [CustomDateAttribute(ErrorMessage = "Паспорт может быть выдан гражданину в возрасте старше 14 лет")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public DateTime Birthday { get; set; }

        [DisplayName("Пол")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public SexTypes Sex { get; set; }

        [DisplayName("Серия паспорта")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [RegularExpression(@"^[0-9\s]{4}$", ErrorMessage = "Допускаются только цифры и пробел - ровно 4")]
        public string Series { get; set; }

        [DisplayName("Номер паспорта")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [RegularExpression(@"^[0-9]{6}$", ErrorMessage = "Допускаются только цифры - ровно 6")]
        public string Number { get; set; }

        [DisplayName("Дата выдачи паспорта")]
        [DateLessThanNowAttribute(ErrorMessage ="Дата выдачи паспорта не может быть позже текущей даты")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        public DateTime DateOfIssue { get; set; }

        [DisplayName("Код департамента")]
        [RegularExpression(@"^[0-9\-]{7}$", ErrorMessage = "Допускается только цифры и знак \"-\" - ровно 7")]
        public string IssuaDepartmentCode { get; set; }

        [DisplayName("ИД места рождения")]
        public int PlaceOfBirthId { get; set; }

        [DisplayName("Место рождения")]
        public virtual PlaceOfBirth PlaceOfBirthItem { get; set; }

        [DisplayName("Орган выдачи")]
        public string PlaceOfIssue { get; set; }
   }
}