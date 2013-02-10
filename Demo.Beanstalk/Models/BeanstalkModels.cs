using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Demo.Beanstalk.Models
{
    public class BeanstalkModels : DbContext
    {
        public BeanstalkModels()
            : base("DefaultConnection") { }

        public DbSet<Movie> Movies { get; set; }
        //public DbSet<Rating> Ratings { get; set; }
        //public DbSet<User> Users { get; set; }
    }

    public class Movie
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(256)]
        public string Title { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }

    public class Rating
    {
        public int Id { get; set; }

        public byte RatingValue { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual User User { get; set; }
    }

    public class User
    {
        public int Id { get; set; }

        public char Gender { get; set; }

        public byte Age { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}