using NUnit.Framework;
using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System;

namespace TestProject2
{
    public class Queries
    {
        public string CoursesAll = @"SELECT * FROM [pluto].[dbo].[Courses]";
    }
    public class Courses
    {
        public int CourseID { get; set; }
        public int AuthorID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string LevelString { get; set; }
        public int Level { get; set; }

    }
    public class Tests
    {
        public Dictionary<string, string> Configuration()
        {
            var json = File.ReadAllText(Environment.CurrentDirectory + @"\jsconfig1.json");
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        [Test]
        public void ValidateAuthorIDForFirstResult()
        {
            var query = new Queries();

            var connectionString = Configuration()["Database"];

            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var courses = connection.Query<Courses>(query.CoursesAll).AsList();

            Assert.AreEqual(courses[0].AuthorID, 1);
        }

    }
}