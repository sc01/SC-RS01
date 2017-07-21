﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sign.Models.Business
{
    public class Customer
    {
        public long id { get; set; }
        [Display(Name= "إســم العـمـيل")]
        public string Name { get; set; }
        [Display(Name = "رقــم الهــوية")]
        public string  CustomerId { get; set; }
        [Display(Name = "الـجـنـــســــية")]
        public string Nationality { get; set; }
        [Display(Name = "رقــم الهــاتف")]
        public string  PhoneNumber { get; set; }
        [Display(Name = "مـكـان الـعـمـل")]
        public string  WorkPalce { get; set; }
        [Display(Name = "هــاتـف الـعـمل")]
        public string WorkPhone { get; set; }
        [Display(Name = "نـوع العـميل")]
        public string CustomerType { get; set; }
        [Display(Name = "العـنوان")]
        public string Address { get; set; }

    }
}