using E4StudentAPI.Models;
using E4StudentAPI.Repository;
using System;
using System.Web.Http;

namespace E4StudentAPI.Controllers
{
    public class StudentController : ApiController
    {
        // GET api/student
        public ApiResponse Get()
        {
            try
            {
                var xmlPath = System.Web.Hosting.HostingEnvironment.MapPath(StudentRepository.StudentDataPath);

                return new ApiResponse()
                {
                    Data = StudentRepository.List(xmlPath),
                    Success = true
                };
            }
            catch (Exception e)
            {
                return new ApiResponse()
                {
                    Success = false,
                    Data = new
                    {
                        e.Message
                    }
                };
            }
        }

        // GET api/student/5
        public ApiResponse Get(string id)
        {
            try
            {
                var xmlPath = System.Web.Hosting.HostingEnvironment.MapPath(StudentRepository.StudentDataPath);

                return new ApiResponse()
                {
                    Data = StudentRepository.GetStudentById(xmlPath, id),
                    Success = true
                };
            }
            catch (Exception e)
            {
                return new ApiResponse()
                {
                    Success = false,
                    Data = new
                    {
                        e.Message
                    }
                };
            }
        }

        // POST api/student
        public ApiResponse Post(StudentModel student)
        {
            try
            {
                var xmlPath = System.Web.Hosting.HostingEnvironment.MapPath(StudentRepository.StudentDataPath);

                return new ApiResponse()
                {
                    Data = StudentRepository.Save(xmlPath, student),
                    Success = true
                };
            }
            catch (Exception e)
            {
                return new ApiResponse()
                {
                    Success = false,
                    Data = new
                    {
                        e.Message
                    }
                };
            }
            
        }

        // DELETE api/student/5
        public ApiResponse Delete(string id)
        {
            try
            {
                var xmlPath = System.Web.Hosting.HostingEnvironment.MapPath(StudentRepository.StudentDataPath);

                StudentRepository.Delete(xmlPath, id);

                return new ApiResponse()
                {
                    Success = true
                };
            } catch(Exception e)
            {
                return new ApiResponse()
                {
                    Success = false,
                    Data = new
                    {
                        e.Message
                    }
                };
            }
            
        }
    }
}
