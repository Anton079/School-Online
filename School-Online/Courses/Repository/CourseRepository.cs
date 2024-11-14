using System;
using System.Collections.Generic;
using System.IO;
using School_Online.Courses.Models;

namespace School_Online.Courses.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private List<Course> courseList;

        public CourseRepository()
        {
            courseList = new List<Course>();
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
                        Course course = new Course(line);
                        courseList.Add(course);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string GetFilePath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string folder = Path.Combine(currentDirectory, "data");
            string file = Path.Combine(folder, "Courses");
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
                Console.WriteLine(ex.Message);
            }
        }

        public string ToSaveAll()
        {
            string save = "";
            for (int i = 0; i < courseList.Count; i++)
            {
                save += courseList[i].ToString();
                if (i < courseList.Count - 1)
                {
                    save += "\n";
                }
            }
            return save;
        }

        // CRUD 

        public List<Course> GetAll()
        {
            return courseList;
        }

        public Course AddCourse(Course course)
        {
            courseList.Add(course);
            SaveData();
            return course;
        }

        public Course Remove(int id)
        {
            Course course = FindById(id);

            courseList.Remove(course);
            SaveData();
            return course;
        }

        public Course FindById(int id)
        {
            foreach (Course course in courseList)
            {
                if (course.Id == id)
                {
                    return course;
                }
            }
            return null;
        }

        public Course UpdateCourse(int id, Course course)
        {
            Course courseUpdate = FindById(id);

            if (courseUpdate != null)
            {
                courseUpdate.Name = course.Name;
                courseUpdate.Department = course.Department;

                SaveData();
            }
            return courseUpdate;
        }
    }
}
