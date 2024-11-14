using online_school.Models;
using School_Online.Students.Repository;

namespace school_online.students.repository
{
    public class StudentRepository : IStudentRepository
    {
        private List<Student> studentlist;

        public StudentRepository()
        {
            studentlist = new List<Student>();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                using (StreamReader sr = new StreamReader(GetFilePath()))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Student student = new Student(line);
                        studentlist.Add(student);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eroare la încărcarea datelor în StudentRepository: " + ex.Message);
            }
        }

        public string GetFilePath()
        {
            string currentdirectory = Directory.GetCurrentDirectory();
            string folder = Path.Combine(currentdirectory, "data");
            string file = Path.Combine(folder, "Students");
            return file;
        }

        private void SaveData()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(GetFilePath()))
                {
                    sw.WriteLine(ToSaveAll());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public string ToSaveAll()
        {
            string save = "";
            for (int i = 0; i < studentlist.Count; i++)
            {
                save += studentlist[i].ToString();
                if (i < studentlist.Count - 1)
                {
                    save += "\n";
                }
            }
            return save;
        }

        // crud operations

        public List<Student> GetAll()
        {
            return studentlist;
        }

        public Student AddStudent(Student student)
        {
            studentlist.Add(student);
            SaveData();
            return student;
        }

        public Student Remove(int id)
        {
            Student student = FindById(id);
            if (student != null)
            {
                studentlist.Remove(student);
                SaveData();
            }
            return student;
        }

        public Student FindById(int id)
        {
            foreach (Student student in studentlist)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }
            return null;
        }

        public Student UpdateStudent(int id, Student student)
        {
            Student studenttoupdate = FindById(id);
            if (studenttoupdate != null)
            {
                studenttoupdate.FirstName = student.FirstName;
                studenttoupdate.LastName = student.LastName;
                studenttoupdate.Email = student.Email;
                studenttoupdate.Age = student.Age;
                SaveData();
            }
            return studenttoupdate;
        }
    }
}
