using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task2.Models
{
	public class Designation
	{
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Designation name is required")]
        [StringLength(50, ErrorMessage = "Designation cannot exceed 50 characters")]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}