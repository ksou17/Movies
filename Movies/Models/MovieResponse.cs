using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class MovieResponse
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        
        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        
        [Required(ErrorMessage ="Please enter movie title")]
        public string MovieTitle { get; set; }
        
        [Required (ErrorMessage ="Please enter the year")]
        public int Year { get; set; }
        
        [Required (ErrorMessage ="Please enter the director")]
        public string Director { get; set; }
        [Required (ErrorMessage ="Please enter the rating")]
        public string Rating { get; set; }
        public Boolean Edited { get; set; }
        public string LentTo { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }

    }
}
