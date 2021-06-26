namespace Lab_04.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [Required(ErrorMessage = "Không được trống ")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Không được trống ")]
        [StringLength(250, ErrorMessage = "Tiêu đề sách không được vượt quá 100 ký tự")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Không được trống ")]
        [StringLength(50)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Không được trống ")]
        [StringLength(50)]
        public string Author { get; set; }

        [Required(ErrorMessage = "Không được trống ")]
        [StringLength(50)]
        public string Images { get; set; }

        [Required(ErrorMessage = "Không được trống ")]
        [Range(1000, 100000, ErrorMessage = "không dược vượt quá 100000 ")]
        public double? Price { get; set; }
    }
}
