using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstNetCore2MvcApplication.WebUI.Entity
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen ürün adını giriniz.")]
        [Display(Name="Ürün Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen ürün fiyatını giriniz.")]
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Lütfen ürün stoğunu giriniz.")]
        [Display(Name = "Stok")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Lütfen ürünün resmini seçiniz.")]
        [Display(Name = "Resim")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Lütfen ürünün markasını seçiniz.")]
        [Display(Name = "Marka")]
        public int BrandId { get; set; }

    }
}
