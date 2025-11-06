using System.ComponentModel.DataAnnotations;

namespace ProductManagementApi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required ][MinLength(3)]
        public string Name{ get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Đơn giá phải là số lớn hơn 0")]
        public decimal Price { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Số tồn kho phải là số lớn hơn 0")]
        public int Stock { get; set; }
        public string? Description { get; set; }



    }
}