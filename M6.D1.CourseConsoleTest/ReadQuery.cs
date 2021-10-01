using SearchLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseConsoleTest
{
    internal static class QueryReader
    {
        internal static CourseQuery ReadQuery()
        {
            
            //Create a query object
            CourseQuery query = new CourseQuery();

            Console.WriteLine("Please Enter The Query");
            query.Query = Console.ReadLine();
            //Read the query

            //return the query object
            return query;
        }
    }
}
