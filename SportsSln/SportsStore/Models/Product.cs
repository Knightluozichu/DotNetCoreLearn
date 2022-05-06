using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Models
{
    public class Product {
        public long ProductID { get; set; }
        [Required(ErrorMessage = "请输入商品名字")]
        public string Name { get; set; }
        [Required(ErrorMessage = "请输入商品描述")]
        public string Description { get; set; }
        
        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage = "请输入商品价格")]
        [Column(TypeName="decimal(8, 2)")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "请输入商品类型")]
        public string Category { get; set; }
    }
}