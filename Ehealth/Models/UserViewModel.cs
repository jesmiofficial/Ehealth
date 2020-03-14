using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Ehealth.Models
{
    public class UserViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Enter Username")]
        [Display(Name ="Username")]
        public string username { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string password { get; set; }
        [Display(Name ="Role")]

        [Required(ErrorMessage = "Enter Role")]
        public int role_id { get; set; }

        //Custom attribute
        [Display(Name ="Doctor Name")]
        [Required(ErrorMessage = "Enter Doctor's Name")]
        public string doctorName { get; set; }
        
        [Required(ErrorMessage = "Enter Doctor's Speciality")]
        [Display(Name = "Doctor Speciality")]
        public int speciality_id { get; set; }
        [Display(Name ="Available Time")]

        [Required(ErrorMessage = "Enter Doctor's Available time")]
        public System.DateTime availableTime { get; set; }
        [Display(Name ="Available Date")]
        [Required(ErrorMessage = "Enter Doctor's Available date")]

        public System.DateTime availableDate { get; set; }
        [Display(Name ="Contact")]
        [Required(ErrorMessage = "Enter Doctor's Contact")]

        public string doctorContact { get; set; }
        [Display(Name ="Email")]
        [Required(ErrorMessage = "Enter Doctor's Email")]

        public string doctorEmail { get; set; }
        public int user_id { get; set; }

    }
}