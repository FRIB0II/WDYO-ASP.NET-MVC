using Microsoft.EntityFrameworkCore;

namespace WhatDoYouOwn_ASPNET
{
    public class MyDbContext : DbContext
    {
        MyDbContext(DbContextOptions<MyDbContext> options) : base (options) 
        {
        }

        //public DbSet<classeModelo> nome { get; set; }
    }
}
