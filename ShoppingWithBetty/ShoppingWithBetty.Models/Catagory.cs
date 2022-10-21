﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShoppingWithBetty.Models
{
    public class Catagory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

    }
}