using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEFnetf
{
    public static class Insert
    {
        static Random rand = new Random();

        /// <summary>
        /// Add random names in table Students
        /// </summary>
        /// <param name="db">DbContext</param>
        /// <param name="count">Count</param>
        public static void AddStudents(Academy db, int count)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=RandomDB;Integrated Security=True;");
            connection.Open();
            SqlCommand cmd = new SqlCommand("select Name from Names order by newid()", connection);

            for (int i = 0; i < count; i++)
            {
                db.Students.Add(new Student()
                {
                    Name = (string)cmd.ExecuteScalar()
                });
            }

            connection.Close();
        }
        
        /// <summary>
        /// Add disciplines in table Disciplines (Not random!)
        /// </summary>
        /// <param name="db">DbContext</param>
        public static void AddDisciplines(Academy db)
        {
            var dList = new string[]
            {
                "Украинский язык",
                "Украинская литература",
                "Английский язык",
                "Зарубежная литература",
                "История",
                "Математика",
                "Алгебра",
                "Геометрия",
                "Биология",
                "Экология",
                "География",
                "Физика и астрономия",
                "Химия",
                "Физическая культура",
                "Защита отечества",
                "Искусство",
                "Технологии",
                "Информатика"
            };
            for (int i = 0; i < dList.Length; i++)
            {
                db.Disciplines.Add(new Discipline()
                {
                    Title = dList[i]
                });
            }
        }

        /// <summary>
        /// Add random value in table Journal
        /// </summary>
        /// <param name="db">DbContext</param>
        /// <param name="count">Count</param>
        public static void AddJournal(Academy db, int count, int minRating, int maxRating)
        {
            var sList = db.Students.ToList();
            var dList = db.Disciplines.ToList();

            for (int i = 0; i < count; i++)
            {
                db.Journal.Add(new Journal()
                {
                    StudentId = sList[rand.Next(sList.Count)].Id,
                    DisciplineId = dList[rand.Next(dList.Count)].Id,
                    Rating = rand.Next(minRating, maxRating),
                    Moment = new DateTime(2020, 01, rand.Next(1, 32), rand.Next(8, 16), rand.Next(60), rand.Next(60))
                });
            }
        }
    }
}
