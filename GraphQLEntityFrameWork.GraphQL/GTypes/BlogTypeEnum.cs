using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;
using GraphQLEntityFramework.Data.Entities;

namespace GraphQLEntityFrameWork.GraphQL.GTypes
{
    public class BlogTypeEnum : EnumerationGraphType<BlogType>
    {

        public BlogTypeEnum ()
            {
            Name = "type";
            Description = "Blog types for detail";
             }
    }
}
