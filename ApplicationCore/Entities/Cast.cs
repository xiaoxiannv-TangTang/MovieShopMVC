﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("Cast")]
    public class Cast
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(128)]
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? TmdbUrl { get; set; }
        [MaxLength(2084)]
        public string? ProfilePath { get; set; }

        //nagiation property 
        public ICollection<MovieCast>? Movies { get; set; }


    }
}
