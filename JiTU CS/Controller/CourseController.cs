﻿using System;
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

        /// <summary>
        /// gets a list of courses associated with a specified user
        /// </summary>
        /// <param name="user">user to look up classes for</param>
        /// <returns></returns>
        public static List<CourseData> GetCourses(UserData user)
        {
            return courseEntity.ReadCourses(user);

        }

        /// <summary>
        /// Gets a course by name
        /// </summary>
        /// <param name="courseName">the name to look for</param>
        /// <returns></returns>
        public static CourseData GetCourse(string courseName)
        {
            return courseEntity.ReadCourse(courseName);
        }

        /// <summary>
        /// adds a quiz to a course
        /// </summary>
        /// <param name="course">course to add quiz to</param>
        /// <param name="quiz">quiz to add</param>
        public static void AddQuiz(CourseData course, QuizData quiz)
        {
            courseEntity.AddQuiz(course, quiz);
        }

        /// <summary>
        /// removes a specified user from a specified course
        /// </summary>
        /// <param name="course">course to remove user from</param>
        /// <param name="user">user to be removed</param>
        public static void RemoveUser(CourseData course, UserData user)
        {
            courseEntity.RemoveUser(course, user);
        }

        /// <summary>
        /// adds a user to a specified course
        /// </summary>
        /// <param name="course">the course to add the user to</param>
        /// <param name="user">the user to add to the course</param>
        public static void AddUser(CourseData course, UserData user)
        {
            courseEntity.AddUser(course, user);
        }

        /// <summary>
        /// saves a course
        /// </summary>
        /// <param name="course">course to save</param>
        public static void SaveCourse(CourseData course)
        {
            if (course.Id == 0)
                courseEntity.CreateCourse(course);
            else
                courseEntity.UpdateCourse(course);
        }

        /// <summary>
        /// Deletes a specified course from the database
        /// </summary>
        /// <param name="course">course to delete</param>
        public static void DeleteCourse(CourseData course)
        {
            courseEntity.DeleteCourse(course);
        }

    }
}
