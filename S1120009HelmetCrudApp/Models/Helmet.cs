using System;
using System.ComponentModel.DataAnnotations;

namespace HelmetCrudApp.Models
{
    public class Helmet
    {
        public int Id { get; set; } // 資料庫主鍵 (必備)

        [Display(Name = "品牌")]
        [Required(ErrorMessage = "必須填寫品牌 (如: SHOEI, ARAI)")]
        public string Brand { get; set; }

        [Display(Name = "型號")]
        [Required]
        public string ModelName { get; set; } // 如: X-Fifteen, RX-7X

        [Display(Name = "購買價格")]
        public int Price { get; set; }

        [Display(Name = "已做 PFS 量身調整?")]
        public bool HasPFS { get; set; }

        [Display(Name = "購買日期")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
    }
}