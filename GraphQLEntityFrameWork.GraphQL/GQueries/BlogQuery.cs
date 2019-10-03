

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
                "blogs",
                arguments: new QueryArguments(
                new QueryArgument<IntGraphType>() { Name = "id" } )
                , resolve: context =>
                {
                    int? id = context.GetArgument<int>("id");
                    if (id != null)
                    {
                        return service.Get(id.Value);
                    }
                    else
                    { return service.GetAll(); }
                }); 

        }
    }
}
