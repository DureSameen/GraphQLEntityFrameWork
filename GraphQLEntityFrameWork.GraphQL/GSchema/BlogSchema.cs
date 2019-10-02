using System;
using System.Collections.Generic;
using System.Text;
using GraphQL;
using GraphQL.Types;
using GraphQLEntityFrameWork.GraphQL.GQueries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GraphQLEntityFrameWork.GraphQL.GSchema
{ 
    public class BlogSchema : Schema
    {
        public BlogSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<BlogQuery>();

        }

    }
}
