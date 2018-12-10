using System;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options) { }

        public DbSet<Member> Member {get; set;}
        public DbSet<Client> Client {get; set;}
        public DbSet<Project> Project {get; set;}
        public DbSet<ProjectList> ProjectList {get; set;}


        //Joining tables 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Project>().ToTable("Project");

            modelBuilder.Entity<ProjectList>()
            .HasKey(m => new { m.PersonID, m.ProjectID });

            modelBuilder.Entity<ProjectList>()
            .HasOne(p => p.Project)
            .WithMany(pr => pr.projectLists)
            .HasForeignKey(id => id.ProjectID);

            modelBuilder.Entity<ProjectList>()
            .HasOne(pr => pr.Person)
            .WithMany(p => p.Projects)
            .HasForeignKey(id => id.PersonID);


        }
    }


    
}