using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SportsStore.Models
{
    public class Order {
        [BindNever]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [Required(ErrorMessage ="请输入一个名字")]
        public string Name { get; set; }
        [Required(ErrorMessage ="请输入第一个地址")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        [Required(ErrorMessage ="请输入区（县）")]
        public string City { get; set; }
        [Required(ErrorMessage ="请输入省份（市）")]
        public string State { get; set; }
        public string Zip { get; set; }
        
        [Required(ErrorMessage ="请输入国家")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}