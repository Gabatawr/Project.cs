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
        static int EnterInt(string h)
        {
            Console.WriteLine(new string('-', 64));
            Console.Write(h + ": ");

            return Convert.ToInt32(Console.ReadLine());
        }

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

            //-------------------------------------------
            int top = EnterInt("Top");
            //-------------------------------------------
            var q = from j in db.Journal
                    join s in db.Students on j.StudentId equals s.Id
                    join d in db.Disciplines on j.DisciplineId equals d.Id
                    select new { j,s,d };
            PrintTake();
            //-------------------------------------------
            int jId = EnterInt("JId");

            Journal jItem = db.Journal.Find(jId);
            if (jItem == null)
                Console.WriteLine("Not found");
            else
            {
                db.Journal.Remove(jItem);
                db.SaveChanges();

                PrintTake();
            }
            //-------------------------------------------
            int sId = EnterInt("SId");

            Student sItem = db.Students.Find(sId);
            if (sItem == null) Console.WriteLine("Not found");
            else
            {
                Console.Write("New name: ");
                sItem.Name = Console.ReadLine();
                db.SaveChanges();

                PrintWhere();
            }
            //-------------------------------------------

            //-----------------------------------------------------------------
            Console.WriteLine(new string('-', 64));
            Console.WriteLine($"Students: {db.Students.Count()}");
            Console.WriteLine($"Disciplines: {db.Disciplines.Count()}");
            Console.WriteLine($"Journal: {db.Journal.Count()}");
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------
            db.Dispose();
            Console.ReadKey();
            //-----------------------------------------------------------------

            //-------------------------------------------
            void Print(dynamic a)
            {
                Console.WriteLine("JId [" + $"{a.j.Id}".PadLeft(5, '0') + "]".PadRight(8)
                                    + "SId [" + $"{a.s.Id}".PadLeft(3, '0') + "]".PadRight(8)
                                    + $"{a.s.Name}".PadRight(12)
                                    + $"{a.d.Title}".PadRight(24)
                                    + $"{a.j.Rating}".PadLeft(2, '0'));
            }
            //-------------------------------------------
            void PrintTake()
            {
                Console.WriteLine();
                foreach (var a in q.Take(top))
                    Print(a);
            }
            //-------------------------------------------
            void PrintWhere()
            {
                Console.WriteLine();
                foreach (var a in q.Where(a => a.s.Id == sId))
                    Print(a);
            }
            //-------------------------------------------
        }
    }
}
