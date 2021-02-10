using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace ConsoleEFnetf
{
    #region ORM
    public class Student
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Discipline
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    public class Journal
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int DisciplineId { get; set; }
        public int Rating { get; set; }
        public DateTime Moment { get; set; }
    }
    #endregion ORM
    #region Context
    public class Academy : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Journal> Journal { get; set; }

        public Academy(string connectionString) : base(connectionString) { }
    }
    #endregion Context
    class Program
    {
        static Random rand = new Random();
        static void Main()
        {
            Academy db = new Academy("DefaultConnection");

            //-----------------------------------------------------------------
            Insert.AddStudents(db, 50);
            Insert.AddDisciplines(db);
            db.SaveChanges();
            //-----------------------------------------------------------------

            //var sList = db.Students.ToList();
            //var dList = db.Disciplines.ToList();

            //for (int i = 0; i < 10; i++)
            //{
            //    db.Journal.Add(new Journal()
            //    {
            //        StudentId = sList[rand.Next(sList.Count)].Id,
            //        DisciplineId = dList[rand.Next(dList.Count)].Id,
            //        Rating = rand.Next(5, 12),
            //        Moment = DateTime.Now.AddDays(rand.Next(7))
            //    });
            //}
            //db.SaveChanges();

            Console.WriteLine($"Students: {db.Students.Count()}");
            Console.WriteLine($"Disciplines: {db.Disciplines.Count()}");
            Console.WriteLine($"Journal: {db.Journal.Count()}");

            Console.ReadKey();
        }
    }
}
