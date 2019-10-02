using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace GraphQLEntityFramework.Data.Entities
{
    public class BlogModel
    {
       
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        public BlogType Type { get; set; }

        public List<ReviewModel> Reviews { get; set; }
    }
}
