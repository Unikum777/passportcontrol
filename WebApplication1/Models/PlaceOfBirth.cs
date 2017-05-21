using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication1.Models
{
    public class PlaceOfBirth
    {
        public int Id { get; set; }

        [DisplayName("Название населенного пункта")]
        public string Name { get; set; }

        [DisplayName("Код ОКАТО")]
        public int Code { get; set; }
        public virtual List<PassportItem> PassportsByCity { get; set; }
    }
}