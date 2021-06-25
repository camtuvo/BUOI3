namespace Lab3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Required(ErrorMessage = "ID khong duoc trong")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Tieu de khong duoc trong")]
        [StringLength(100, ErrorMessage ="Tieu de khong qua 100 ky tu")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Mo ta khong duoc trong")]
        [StringLength(255)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Tac gia khong duoc trong")]
        [StringLength(30, ErrorMessage ="Ten tac gia khong qua 30 ky tu")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Anh khong duoc trong")]
        [StringLength(255)]
        public string Images { get; set; }

        [Required(ErrorMessage = "Gia sach khong duoc trong")]
        [Range(1000, 1000000, ErrorMessage = "Gia sach tu 1000 den 1000000")]
        public int Price { get; set; }
    }
}
