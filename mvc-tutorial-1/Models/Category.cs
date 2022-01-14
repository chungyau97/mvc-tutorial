using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc_tutorial_1.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, long.MaxValue, ErrorMessage = "The Display Order field must be greater than 0.")]
        public int DisplayOrder { get; set; }
    }
}
