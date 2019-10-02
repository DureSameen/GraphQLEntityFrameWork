using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GraphQLEntityFramework.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLEntityFramework.Data.Repositories
{

    public class ReviewsRepository
    {
        private readonly BlogDBContext _dbContext;
        
        private MapperConfiguration _config;
        public ReviewsRepository(BlogDBContext  dbContext, MapperConfiguration config)
        {
            _dbContext =  dbContext;
             _config = config;
        }

        public async Task<ILookup<int, Review>> GetAllBlogIds(IEnumerable <int> ids)
        {
            var reviews= await _dbContext
                .Reviews
                .Where (r=> ids.Contains(r.BlogId))
                .ToListAsync();
            return reviews.ToLookup(r => r.BlogId);

        }


        public async Task<IEnumerable<Review>> GetAllByBlogId(int blogId)
        {
            return await _dbContext
                .Reviews
                .Where (r=> r.BlogId== blogId)
               .ToListAsync();
 
        }

        public Review Get(int id)
        {
            return GetQuery().Single(x => x.ReviewId == id);
        }

        public IEnumerable<Review> GetQuery()
        {
            return _dbContext
                 .Reviews;
                
        }
    }
}
