using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ST10085591_CLDV6211_POE.Models
{
    public class UserAccount
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Inspector Fisrt Name is Required.")]
        public string InspectorFirstName { get; set; }
        [Required(ErrorMessage ="Inspector Last Name is Required.")]
        public string InspectorLastName { get; set; } = string.Empty;
        [Required(ErrorMessage ="Your Email is Required.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-z]{2,4}|[0-9]{1,3})(\]?)$",ErrorMessage ="Please Enter valid Email.")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Enter Username")]
        public string InspectorUserName { get; set; } 
        [Required(ErrorMessage ="Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage ="Please Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        
    }
}