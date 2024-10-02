using Microsoft.EntityFrameworkCore;
using MusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public Task<Customer?> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
