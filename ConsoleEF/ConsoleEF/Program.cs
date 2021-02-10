using System;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ConsoleEF
{
    #region ORM
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class Discipline
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    class Journal
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int DisciplineId { get; set; }
        public int Rating { get; set; }
        public DateTime Moment { get; set; }
    }
    #endregion ORM
    #region Context
    class Academy : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Journal> Journal { get; set; }

        public Academy(DbContextOptions<Academy> options) : base(options)
            => Database.EnsureCreated();
    }
    #endregion Context
    class Program
    {
        static void Main()
        {
            Academy db = new(new DbContextOptions<Academy>());

            db.Students.Add(new Student() { Name = "1" });

            Console.ReadKey();
        }
    }
}
