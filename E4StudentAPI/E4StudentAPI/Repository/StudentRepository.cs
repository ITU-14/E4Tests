using E4StudentAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace E4StudentAPI.Repository
{
    public static class StudentRepository
    {
        public static readonly string StudentDataPath = "~/App_Data/student-data.xml";

        public static StudentModel Save(string xmlPath, StudentModel model)
        {
            var document = XDocument.Load(xmlPath);

            if (!string.IsNullOrEmpty(model.ID))
            {
                var element = GetElementById(ref document, model.ID);

                element.Remove();
            }

            document.Element("students").Add(model.ToXElement());
            
            document.Save(xmlPath);

            return model;
        }

        public static IList<StudentModel> List(string xmlPath)
        {
            var document = XDocument.Load(xmlPath);

            var students = (from xmlNode in document.Descendants("student")
                         select xmlNode).Select(studentNode => new StudentModel(studentNode)).ToList();

            return students;
        }

        private static XElement GetElementById(ref XDocument document, string studentId)
        {
            var student = (from xmlNode in document.Descendants("student")
                        where xmlNode.Element("id").Value == studentId
                        select xmlNode).FirstOrDefault();

            return student;
        }

        public static StudentModel GetStudentById(string xmlPath, string studentId)
        {
            var document = XDocument.Load(xmlPath);

            var student = GetElementById(ref document, studentId);

            if (student == null) throw new System.Exception("Student not Found!");

            return new StudentModel(student);
        }

        public static void Delete(string xmlPath, string studentId)
        {
            var document = XDocument.Load(xmlPath);

            var student = GetElementById(ref document, studentId);

            if (student == null) throw new System.Exception("Student not Found!");

            student.Remove();

            document.Save(xmlPath);
        }
    }
}