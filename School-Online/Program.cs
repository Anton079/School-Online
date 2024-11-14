using online_school.Models;
using school_online.students.repository;
using School_Online.Books.Models;
using School_Online.Books.Repository;
using School_Online.Books.Service;
using School_Online.Courses.Models;
using School_Online.Courses.Repository;
using School_Online.Courses.Service;
using School_Online.Enrolments.Models;
using School_Online.Enrolments.Repository;
using School_Online.Enrolments.Service;
using School_Online.Students.Repository;
using School_Online.Students.Service;

namespace online_school
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Inițializarea repository-urilor
            StudentRepository studentRepository = new StudentRepository();
            CourseRepository courseRepository = new CourseRepository();
            BookRepository bookRepository = new BookRepository();
            EnrolmentRepository enrolmentRepository = new EnrolmentRepository();

            // Inițializarea serviciilor de interogare și comandă pentru fiecare entitate
            StudentQueryService studentQueryService = new StudentQueryService(studentRepository);
            StudentComandService studentComandService = new StudentComandService(studentRepository);

            CourseQueryService courseQueryService = new CourseQueryService(courseRepository);
            CourseComandService courseComandService = new CourseComandService(courseRepository);

            BookQueryService bookQueryService = new BookQueryService(bookRepository);
            BookComandService bookComandService = new BookComandService(bookRepository);

            EnrolmentQueryService enrolmentQueryService = new EnrolmentQueryService(enrolmentRepository);
            EnrolmentComandService enrolmentComandService = new EnrolmentComandService(enrolmentRepository);




            ViewLoginPage viewLog = new ViewLoginPage(studentQueryService, studentComandService, courseQueryService, courseComandService, 
                bookQueryService, bookComandService, enrolmentQueryService, enrolmentComandService, enrolmentRepository);

            viewLog.Play();




            // COURSE

            //Adauga Curs
            //Course course = new Course(6, "Logica", "Facultatea de Logica");
            //courseComandService.AddCourse(course);

            //Afișarea tuturor cursurilor
            //Console.WriteLine("\nLista cursurilor:");
            //List<Course> courses = courseQueryService.GetAllCourses();
            //foreach (Course c in courses)
            //{
            //    Console.WriteLine(c);
            //}

            // Remove COURSE
            //courseComandService.RemoveCourse(6);
            //Console.WriteLine("\nCurs eliminat:");
            //foreach (Course c in courseQueryService.GetAllCourses())
            //{
            //    Console.WriteLine(c);
            //}




            ////// BOOK
            //Book book = new Book(6, 14, "Algoritmi Fundamentali", 20230101);

            ////Adauga carte
            //bookComandService.AddBook(book);

            //// Update BOOK
            //Book updatedBook = new Book(1, 14, "Programare C#", 20230102);
            //bookComandService.UpdateBook(book.Id, updatedBook);
            //Console.WriteLine("\nCarte actualizată:");
            //Console.WriteLine(bookQueryService.FindBookById(book.Id));


            //// Afișarea tuturor cărților
            //Console.WriteLine("\nLista cărților:");
            //List<Book> books = bookQueryService.GetAllBooks();
            //foreach (Book b in books)
            //{
            //    Console.WriteLine(b);
            //}



            // ENROLMENT
            //Enrolment enrolment = new Enrolment(5, 5, 20230115);
            //enrolmentComandService.AddEnrolment(enrolment);

            //// Afișarea tuturor ENROLMENT
            //Console.WriteLine("\nLista înscrierilor:");
            //List<Enrolment> enrolments = enrolmentQueryService.GetAllEnrolments();
            //foreach (Enrolment e in enrolments)
            //{
            //    Console.WriteLine(e);
            //}

            //// Remove ENROLMENT
            //enrolmentComandService.RemoveEnrolment(student.Id, course.Id);
            //Console.WriteLine("\nÎnscriere eliminată:");
            //foreach (Enrolment x in enrolmentQueryService.GetAllEnrolments())
            //{
            //    Console.WriteLine(x);
            //}




            // STUDENT
            //Student student = new Student(1, "Anton", "Florin", "Anton@gmail.com", 18, "Florin");
            //studentComandService.AddStudent(student);

            //Update STUDENT
            //Student updatedStudent = new Student(1, "Laurentiu", "Ionescu", "ionescu@example.com", 21);
            //studentComandService.UpdateStudent(student.Id, updatedStudent);

            //Console.WriteLine(studentQueryService.FindStudentById(student.Id));


        }
    }
}
