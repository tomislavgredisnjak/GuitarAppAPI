using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GuitarAPI.Models
{
    public class Guitar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int NumberOfStrings { get; set; }

        [Required]
        public int NumberOfFrets { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string ImageLink { get; set; }
    }
}