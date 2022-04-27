using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Models;
using University.BL.Repositories;
using University.BL.Repositories.Implements;

namespace University.Test
{
    internal class Program
    {
        private static readonly UniversityModel university = new UniversityModel();
        private static readonly ICourseRepository courseRepository
            = new CourseRepository(new UniversityModel());
        static void Main(string[] args)
        {
            // var courses = university.Course.ToList();
            //var courses2 = courseRepository.GetAll().Result;
            //foreach (var item in courses2)
            // {
            //     Console.WriteLine($"{item.Title} {item.Credits}");
            // }

            var books = Book.Books();
            foreach (var item in books)
            {
                Console.WriteLine($"{item.Title} - {item.PublicationDate}");
            }
            Console.WriteLine("\n");
            var authors = Author.Authors();
            foreach (var item in authors)
            {
                Console.WriteLine($"{item.Name}");
            }

                Console.ReadKey();

            //Mostrar en consola los 3 libros con mas ventas
            var ex1 = books.OrderByDescending(x => x.Sales).Take(3).ToList();

            //Mostrar en consola los 3 libros con menos ventas
            var ex2 = books.OrderBy(x => x.Sales).Take(3).ToList();

            //Mostrar en consola el autor con mas libros publicados
            var ex3 = from b in books
                      join a in authors on b.AuthorId equals a.AuthorId
                      group a by (a.AuthorId, a.Name) into query
                      orderby query.Count() descending
                      select query;

            var resultEx3 = ex3.FirstOrDefault();
            Console.WriteLine($"{resultEx3.Key.AuthorId} - {resultEx3.Key.Name} - {resultEx3.Count()}");
                Console.WriteLine();
            foreach (var item in ex3)
            {
                Console.WriteLine($"{item.Key.Name} - {item.Count()}");

                Console.ReadKey();
            }
        }//
    }
}
