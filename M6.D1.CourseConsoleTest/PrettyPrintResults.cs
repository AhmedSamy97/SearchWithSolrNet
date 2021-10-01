using SearchLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseConsoleTest
{
    internal static class PrettyPrintResults
    {
        internal static void PrintOut(QueryResponse queryResponse)
        {  
            //Print out the results
            if (queryResponse.Results.Count== 0)
            {
                Console.WriteLine();
                Console.WriteLine(" *** No Result Fuund ***");
                if (queryResponse.DidYouMean.Count  > 0 )
                {
                    Console.WriteLine("Did you mean \t"+string.Join(" / ",queryResponse.DidYouMean) + Environment.NewLine);
                }
                return;
            }
            int i = 0;
            Console.WriteLine();
            Console.WriteLine("**** Results ***");

            foreach (var course in queryResponse.Results)
            {
                Console.WriteLine(i++ +" : " + course.CourseTitle);
                Console.WriteLine(course.Description.Substring(0,Math.Min(course.Description.Length,200)));
                Console.WriteLine(" -by : " +string.Join( "," ,course.Author) + "  ");
                Console.WriteLine(course.ReleaseDate.ToShortDateString() + " ");
                Console.WriteLine(TimeSpan.FromSeconds(course.DurationInSeconds) + "  ");
                Console.WriteLine("[ " + string.Join(" ",course.Tags)+" ]");
                Console.WriteLine();

            }

            Console.WriteLine("-------- Results Found : "+queryResponse.TotalHits);
        }
    }
}
