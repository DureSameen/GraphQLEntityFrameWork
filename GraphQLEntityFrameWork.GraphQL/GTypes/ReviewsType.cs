using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;
using GraphQLEntityFramework.Data.Entities;

namespace GraphQLEntityFrameWork.GraphQL.GTypes
{
   public class ReviewsType : ObjectGraphType<Review>
    {

        public ReviewsType()
        {
            Field(f => f.ReviewId);
            Field(f => f.BlogId);
            Field(f => f.UserName);
            Field(f => f.Remarks);
        }
    }
}
