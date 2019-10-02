using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLEntityFramework.Data.Entities;
using GraphQLEntityFramework.Data.Repositories;

namespace GraphQLEntityFrameWork.GraphQL.GTypes
{
    public class BlogGType : ObjectGraphType<Blog>
    {

        public BlogGType(ReviewsRepository repo, IDataLoaderContextAccessor dataLoaderContextAccessor)
        {
            Field(t => t.BlogId);
            Field(t => t.Description);
            Field(t => t.Content);
            Field(t => t.Title);
            Field<BlogTypeEnum>("type");
            Field<ListGraphType<ReviewsType>>("reviews",
                resolve: ctx =>
                {
                    var dataLoader = dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<int, Review>("GetReviewsByBlogId", repo.GetAllBlogIds);

                    return dataLoader.LoadAsync(ctx.Source.BlogId);
                });
        }
    }
}
