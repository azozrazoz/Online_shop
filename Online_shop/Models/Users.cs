using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Online_shop.Models
{
    public class Users
    {
        public Users()
        {
            Orders = new List<Orders>();
        }

        public List<Orders> Orders { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "* Это обязательное поле")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "* Имя должно быть больше одного символа")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* Это обязательное поле")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "* Введите правильную почту")]
        [Display(Name = "Почта")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "* Пароли не равны")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }
    }
}