using AlunosApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunosApi.Controllers
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Aluno> Alunos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluno>().HasData(
                new Aluno
                {
                    IdAluno = 1,
                    Nome = "Maria da Penha",
                    Email = "mariapenha@yahoo.com",
                    Idade = 23
                },
                new Aluno
                {
                    IdAluno = 2,
                    Nome = "Manuel Bueno",
                    Email = "manuelbueno@yahoo.com",
                    Idade = 22
                },
                new Aluno
                {
                    IdAluno = 3,
                    Nome = "Jorge Ávila",
                    Email = "jorgeavila@yahoo.com",
                    Idade = 37
                }
            );
        }

    }
}
