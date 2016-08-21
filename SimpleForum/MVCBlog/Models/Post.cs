﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using SimpleForum.Models;

namespace SimpleForum.Models
{
    public class Post
    {
        public Post()
        {
            this.Date = DateTime.Now;
            this.Tags= new HashSet<Tag>();
            this.Comment= new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [ForeignKey("Author")]
        public string Author_Id { get; set; }

        public ApplicationUser Author { get; set; }
        public Category Category { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }

    }
}