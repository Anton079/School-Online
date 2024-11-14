using online_school.Models;
using School_Online.Books.Models;
using School_Online.Books.Service;
using School_Online.Courses.Models;
using School_Online.Courses.Service;
using School_Online.Enrolments.Models;
using School_Online.Enrolments.Repository;
using School_Online.Enrolments.Service;
using School_Online.Students.Repository;
using School_Online.Students.Service;

namespace online_school
{
    public class ViewStudent
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

        public ViewStudent(
            Student student,
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
            _student = student;
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

        public void Meniu()
        {
            Console.WriteLine("╔═════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                        M E N U                              ║");
            Console.WriteLine("╠═════════════════════════════════════════════════════════════║");
            Console.WriteLine("║                       Enrolment                             ║");
            Console.WriteLine("║-------------------------------------------------------------║");
            Console.WriteLine("║ 1. Apăsați tasta 1 pentru a vă înregistra la un curs        ║");
            Console.WriteLine("║ 2. Apăsați tasta 2 pentru a închiria o carte                ║");
            Console.WriteLine("║-------------------------------------------------------------║");
            Console.WriteLine("║                          Read                               ║");
            Console.WriteLine("║-------------------------------------------------------------║");
            Console.WriteLine("║ 3. Apăsați tasta 3 pentru a vedea toate cursurile           ║");
            Console.WriteLine("║ 4. Apăsați tasta 4 pentru a afișa lista completă a cărților ║");
            Console.WriteLine("║ 5. Apăsați tasta 5 pentru a iesi de la un curs anume!       ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════╝");
        }


        public void play()
        {
            bool running = true;
            while (running)
            {
                Meniu();
                string alegere = Console.ReadLine();

                switch (alegere)
                {
                    case "1":
                        AddEnrolmentInSchool();
                        break;

                    case "2":
                        AddBook();
                        break;

                    case "3":
                        ShowAllCourses();
                        break;

                    case "4":
                        ShowAllBooks();
                        break;

                    case "5":
                        LeaveACourse();
                        break;
                }
            }
        }

        public void ShowAllBooks()
        {
            foreach(Book x in _bookQueryService.GetAllBooks())
            {
                Console.WriteLine($"{x.Id}, {x.BookName}, {x.StudentId}");
            }
        }

        public void ShowAllCourses()
        {
            foreach(Course x in _courseQueryService.GetAllCourses())
            {
                Console.WriteLine($"{x.Id}, {x.Name}, {x.Department}");
            }
        }

        public void AddEnrolmentInSchool()
        {
            Console.WriteLine("Id ul a fost luat automat");
            int idStudent = _student.Id;

            Console.WriteLine("Ce id are cursul la care vrei sa te inscrii?");
            int idCourse = Int32.Parse(Console.ReadLine());

            Console.WriteLine("In ce data te inregistrezi?");
            int idCreateAt = Int32.Parse(Console.ReadLine());

            Enrolment enrolment = new Enrolment(idStudent, idCourse, idCreateAt);

            _enrolmentComandService.AddEnrolment(enrolment);


            Console.WriteLine("Inregistrarea a fost reusita!");
        }

        public void AddBook()
        {
            int idGenerat = _bookQueryService.GenerateId();

            Console.WriteLine("Id ul tau a fost preluat automat");
            int idStudent = _student.Id;

            Console.WriteLine("Ce nume are cartea?");
            string bookNewName = Console.ReadLine();

            Console.WriteLine("Cand a fost inchiriata cartea");
            int bookNewTime = Int32.Parse(Console.ReadLine());

            Book book = new Book(idGenerat, idStudent, bookNewName, bookNewTime);

            _bookComandService.AddBook(book);

            Console.WriteLine("Cartea a fost adauga !");
        }

        public void LeaveACourse()
        {
            int idUser = _student.Id;

            Console.WriteLine("Ce id are cursul de la care vrei sa iesi?");
            int idCourse = Int32.Parse(Console.ReadLine());

            if (_courseQueryService.FindCourseById(idCourse) != null && idUser != -1)
            {
                _enrolmentComandService.RemoveEnrolment(idUser, idCourse);
                Console.WriteLine("Ati fost scos de la curs");
            }
            else
            {
                Console.WriteLine("Nu a fost gasit curusl dorit");
            }
        }


    }
}
