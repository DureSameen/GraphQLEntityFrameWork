using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GraphQLEntityFramework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace GraphQLEntityFramework.Data.Repositories
{

    public class BlogRepository
    {
        private readonly BlogDBContext _dbContext;
        
        private MapperConfiguration _config;
        public BlogRepository(BlogDBContext  dbContext, MapperConfiguration config)
        {
            _dbContext =  dbContext;
             _config = config;
        }

        public async Task<List<T>> GetAll<T>()
        {
            return await GetQuery().ProjectTo<T>(_config).ToListAsync();
        }

        public async Task<IEnumerable<Blog>> GetAll()
        {
            return await _dbContext
                .Blogs
                .Include(x => x.Reviews)
                .ToListAsync();
 
        }

        public Blog Get(int id)
        {
            return GetQuery().Single(x => x.BlogId  == id);
        }

        public IIncludableQueryable<Blog, List<Review>> GetQuery()
        {
            return _dbContext
                 .Blogs
                 .Include(x => x.Reviews);
                
        }
    }
}
