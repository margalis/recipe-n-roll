using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILayer.Models
{
    public class User_AccountDTO
    { 
        public int UserID { get; set; }
        public string UserFullName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserImage_Url { get; set; }
        public DateTime UserRegDate { get; set; }

    }
}
