using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sign.Models.Business
{
    public class Building
    {
        public int Id { get; set; }
        [Display(Name = "إســـم العـمارة")]
        public string Name { get; set; }

        public Customer Customer { get; set; }
        [Display(Name = "إســـم المـالك")]
        public long CustomerId { get; set; }
        
        [Display(Name = "إســم الحـي")]
        public string Gada { get; set; }
        [Display(Name = "إســم الشــارع")]
        public string StreetName { get; set; }
        [Display(Name = "الخــدمـات")]
        public string Services { get; set; }
        [Display(Name = "عدد الشـــقق")]
        public int Count { get; set; }

        public List<Apartment> Apartments { get; set; }


    }
}
