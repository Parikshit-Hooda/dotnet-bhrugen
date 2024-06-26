﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyRazorWeb_Temp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "displayorder should be between 1 and 100 inclusive.")]
        public int DisplayOrder { get; set; }
    }
}

