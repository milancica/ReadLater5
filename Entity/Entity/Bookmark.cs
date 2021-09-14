using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Bookmark
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(maximumLength: 500)]
        public string URL { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public DateTime CreateDate { get; set; }

        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public IEnumerable<Category> Categories { get; set; }

        public long NumberOfClicks { get; set; }
    }
}
