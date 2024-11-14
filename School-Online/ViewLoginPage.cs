using online_school.Models;
using School_Online.Books.Service;
using School_Online.Courses.Service;
using School_Online.Enrolments.Repository;
using School_Online.Enrolments.Service;
using School_Online.Students.Service;

namespace online_school
{
    public class ViewLoginPage
    {
        private Student _student;
        private IStudentQueryService _studentQueryService;
        private IStudentComandService _studentComandService;

        private ICourseQueryService _courseQueryService;
        private ICourseComandService _courseComandService;

        private IBookQueryService _bookQueryService;
        private IBookComandService _bookComandService;

        private IEnrolmentQueryService _enrolmentQueryService;
        private IEnrolmentComandService _enrolmentComandService;
        private IEnrolmentRepository _enrolmentRepository;

        public ViewLoginPage(
            IStudentQueryService studentQueryService,
            IStudentComandService studentComandService,
            ICourseQueryService courseQueryService,
            ICourseComandService courseComandService,
            IBookQueryService bookQueryService,
            IBookComandService bookComandService,
            IEnrolmentQueryService enrolmentQueryService,
            IEnrolmentComandService enrolmentComandService,
            IEnrolmentRepository enrolmentRepository)
        {
            _studentQueryService = studentQueryService;
            _studentComandService = studentComandService;

            _courseQueryService = courseQueryService;
            _courseComandService = courseComandService;

            _bookQueryService = bookQueryService;
            _bookComandService = bookComandService;

            _enrolmentQueryService = enrolmentQueryService;
            _enrolmentComandService = enrolmentComandService;
            _enrolmentRepository = enrolmentRepository;
        }

        public void LoginMenu()
        {
            Console.WriteLine("Apăsați tasta 1 pentru logare");
            Console.WriteLine("Apăsați tasta 2 pentru a vă înregistra");
            Console.WriteLine("Apăsați tasta 3 pentru a reseta parola");
        }

        public void Play()
        {
            bool running = true;
            while (running)
            {
                LoginMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Login();
                        break;
                    case "2":
                        RegisterNewStudent();
                        break;
                    case "3":
                        ResetPassword();
                        break;
                    default:
                        running = false;
                        break;
                }
            }
        }

        public void Login()
        {
            Console.WriteLine("Introduceti id-ul tau:");
            int idLogin = int.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti parola ta:");
            string parolaLogin = Console.ReadLine();

            Student student = _studentQueryService.FindStudentById(idLogin);
            if (student != null && student.Password == parolaLogin)
            {
                Console.WriteLine("V-ati logat cu succes, " + student.FirstName + "!");
                _student = student;
                ViewStudent viewStudent = new ViewStudent(student, _studentQueryService, _studentComandService, _courseQueryService, 
                    _courseComandService, _bookQueryService, _bookComandService, _enrolmentQueryService, 
                    _enrolmentComandService, _enrolmentRepository);

                viewStudent.play();

            }
            else
            {
                Console.WriteLine("Datele sunt gresite sau nu sunteti inregistrat.");
            }
        }

        public Student GetAuthenticatedStudent()
        {
            return _student;
        }

        public void RegisterNewStudent()
        {
            Console.WriteLine("Introduceți prenumele:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Introduceți numele de familie:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Introduceți email-ul:");
            string email = Console.ReadLine();

            Console.WriteLine("Introduceți parola:");
            string password = Console.ReadLine();

            Console.WriteLine("Introduceți vârsta:");
            int age = int.Parse(Console.ReadLine());

            int newId = _studentQueryService.GetAllStudents().Count + 1;
            Student newStudent = new Student(newId, firstName, lastName, email, age, password);

            Student addedStudent = _studentComandService.AddStudent(newStudent);

            if (addedStudent != null)
            {
                Console.WriteLine("Contul a fost creat cu succes!");
            }
            else
            {
                Console.WriteLine("A apărut o eroare. Vă rugăm încercați din nou.");
            }
        }

        public void ResetPassword()
        {
            Console.WriteLine("Introduceți ID-ul:");
            int idWanted = int.Parse(Console.ReadLine());

            Console.WriteLine("Introduceți noua parolă:");
            string newPassword = Console.ReadLine();

            Student studentToUpdate = _studentQueryService.FindStudentById(idWanted);
            if (studentToUpdate != null)
            {
                studentToUpdate.Password = newPassword;
                _studentComandService.UpdateStudent(idWanted, studentToUpdate);
                Console.WriteLine("Parola a fost resetată cu succes.");
            }
            else
            {
                Console.WriteLine("Utilizatorul nu a fost găsit.");
            }
        }
    }
}
