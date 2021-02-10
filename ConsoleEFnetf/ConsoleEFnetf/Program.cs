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
            //-----------------------------------------------------------------
            Academy db = new Academy("DefaultConnection");
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            //Insert.AddStudents(db, 50);
            //Insert.AddDisciplines(db);
            //Insert.AddJournal(db, 10000, 5, 12);
            //db.SaveChanges();
            //-----------------------------------------------------------------

            foreach (var s in db.Students)
            {
                Console.WriteLine($"{s.Id}".PadLeft(3, '0') + " - " + s.Name);
            }

            //-----------------------------------------------------------------
            Console.WriteLine("----------------");
            Console.WriteLine($"Students: {db.Students.Count()}");
            Console.WriteLine($"Disciplines: {db.Disciplines.Count()}");
            Console.WriteLine($"Journal: {db.Journal.Count()}");
            //-----------------------------------------------------------------

            db.Dispose();
            Console.ReadKey();
        }
    }
}
