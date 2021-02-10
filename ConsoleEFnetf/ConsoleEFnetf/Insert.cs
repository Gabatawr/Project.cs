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
                "Биологія",
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
    }
}
