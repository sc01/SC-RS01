using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sign.Models.Business
{
    public class Apartment
    {
        public long Id { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "تاريخ اضافه الشقه")]
        public DateTime EntryDate { get; set; }
        [Display(Name = "اسم تعريفي للشقة")]
        public string Name { get; set; }
        [Display(Name = "نــوع العــرض")]
        public string ShowType { get; set; }
        [Display(Name = "نــوع الشــقة")]
        public string ApartmentType { get; set; }
       
        [Display(Name = "مســاحة الشــقة")]
        public string Area { get; set; }
        [Display(Name = "عــدد الغرف")]
        public int RoomCount { get; set; }
        [Display(Name = "عــدد الصالات")]
        public int HallCount { get; set; }
        [Display(Name = "عــدد الحمامات")]
        public int BathRoomCount { get; set; }
        [Display(Name = "حــالة الشــقة")]
        public string AqarState { get; set; }
        [Display(Name = "مكــان الشــقة")]
        public string ApartmentPlace { get; set; }
        [Display(Name = "رقم الــدور")]
        public string FloorNumber { get; set; }
        [Display(Name = "المــدخل")]
        public string GateState { get; set; }
        [Display(Name = "مكيفـات الاسبليت")]
        public int SplitCount { get; set; }
        [Display(Name = "تكيــف جداري")]
        public int WallTypeCount { get; set; }
        [Display(Name = "عــدد السخــانات")]
        public int HeaterCount { get; set; }
        [Display(Name = "المطبــخ")]
        public string KitchinIsFound { get; set; }
        [Display(Name = "فــاتورة الكهربـاء")]
        public string ElectricBill { get; set; }
        [Display(Name = "فــاتورة المياه")]
        public string WaterBill { get; set; }

        public List<AttachmentForApartment> AttachmentForApartments { get; set; }

        public List<Contract> Contracts { get; set; }

        [Display(Name = "تتبع الي عمارة")]
        public int BuildingId { get; set; }

        public Building Building { get; set; }



    }
}
