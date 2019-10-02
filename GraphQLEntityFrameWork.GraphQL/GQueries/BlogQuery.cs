

using GraphQL.Types;
using GraphQLEntityFramework.Data.Entities;
using GraphQLEntityFramework.Data.Repositories;
using GraphQLEntityFrameWork.GraphQL.GTypes;

namespace GraphQLEntityFrameWork.GraphQL.GQueries
{
    public class BlogQuery : ObjectGraphType
    {
        public BlogQuery(BlogRepository service)
        {
            Field<ListGraphType<BlogGType>>(
                "blogs"
                , resolve: context => service.GetAll()
                ); 

        }
    }
}
