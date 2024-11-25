using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CommonLayer.DTOModels
{
    public class UserLoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserPassword { get; set; }
    }
    public class UserLoginResponseModel
    {
        public string UserName { get; set; }
        public string token { get; set; }

        public DateTime loginDateTime { get; set; }
    }
}
