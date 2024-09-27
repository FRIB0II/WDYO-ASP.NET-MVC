using Microsoft.EntityFrameworkCore;
using WhatDoYouOwn_ASPNET.Models;

namespace WhatDoYouOwn_ASPNET
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base (options)
        {
        }

        public DbSet<UserModel> Usuario { get; set; }
    }
}
