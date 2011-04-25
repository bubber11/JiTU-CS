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

        public static List<CourseData> getCourses(UserData user)
        {
            return courseEntity.getCourses(user);

        }

        public static CourseData getCourse(string courseName)
        {
            return courseEntity.getCourse(courseName);
        }
    }
}
