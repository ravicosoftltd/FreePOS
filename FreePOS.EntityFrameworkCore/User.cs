using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreePOS.EntityFrameworkCore
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        public string address { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public string phone { get; set; }
        public string phone2 { get; set; }
        public string role { get; set; }
    }
}
