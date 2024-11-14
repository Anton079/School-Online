using School_Online.Enrolments.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace School_Online.Enrolments.Repository
{
    public class EnrolmentRepository : IEnrolmentRepository
    {
        private List<Enrolment> enrolmentList;

        public EnrolmentRepository()
        {
            enrolmentList = new List<Enrolment>();
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
                        Enrolment enrolment = new Enrolment(line);
                        enrolmentList.Add(enrolment);
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
            string file = Path.Combine(folder, "Enrolments");
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
            for (int i = 0; i < enrolmentList.Count; i++)
            {
                save += enrolmentList[i].ToString();
                if (i < enrolmentList.Count - 1)
                {
                    save += "\n";
                }
            }
            return save;
        }

        // CRUD Operations

        public List<Enrolment> GetAll()
        {
            return enrolmentList;
        }

        public Enrolment AddEnrolment(Enrolment enrolment)
        {
            enrolmentList.Add(enrolment);
            SaveData();
            return enrolment;
        }

        public Enrolment Remove(int studentId, int courseId)
        {
            Enrolment enrolment = FindByStudentAndCourseId(studentId, courseId);

            if (enrolment != null)
            {
                enrolmentList.Remove(enrolment);
                SaveData();
            }
            return enrolment;
        }

        public Enrolment FindByStudentAndCourseId(int studentId, int courseId)
        {
            foreach (Enrolment enrolment in enrolmentList)
            {
                if (enrolment.StudentId == studentId && enrolment.CourseId == courseId)
                {
                    return enrolment;
                }
            }
            return null;
        }

        public Enrolment UpdateEnrolment(int studentId, int courseId, Enrolment enrolment)
        {
            Enrolment enrolmentToUpdate = FindByStudentAndCourseId(studentId, courseId);

            if (enrolmentToUpdate != null)
            {
                enrolmentToUpdate.CreatedAt = enrolment.CreatedAt;
                SaveData();
            }
            return enrolmentToUpdate;
        }
    }
}
