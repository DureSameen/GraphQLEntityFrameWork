using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GraphQLEntityFramework.Data.Entities
{
    public class ReviewModel
    {
       
        public int Id { get; set; }

        public int BlogId { get; set; }
        public string UserName { get; set; }
        public string Remarks { get; set; }
    }
}
