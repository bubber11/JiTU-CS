using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JiTU_CS.Data;
using JiTU_CS.Entity;

namespace JiTU_CS.Controller
{
    static class CourseController
    {
        static CourseEntity courseEntity = new CourseEntity();

        public static List<CourseData> GetCourses(UserData user)
        {
            return courseEntity.ReadCourses(user);

        }

        public static CourseData GetCourse(string courseName)
        {
            return courseEntity.ReadCourse(courseName);
        }
    }
}
