using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Demo.MovieRatingRipperThing
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var writer = new StreamWriter(File.Open(String.Format("{0}/script.sql", Environment.CurrentDirectory), FileMode.OpenOrCreate, FileAccess.ReadWrite)))
            {
                using (var reader = new StreamReader(File.OpenRead(String.Format("{0}/data/movies.dat", Environment.CurrentDirectory))))
                {
                    writer.WriteLine("delete from Movies");
                    writer.WriteLine("go");

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(new string[] { "::" }, StringSplitOptions.None);
                        writer.WriteLine(String.Format(@"context.Movies.AddOrUpdate(new Movie() {2} Id = {0}, Title = ""{1}"" {3});", parts[0], parts[1], '{', '}'));
                    }

                    reader.Close();
                }

                writer.Flush();
                writer.Close();
            }
        }
    }
}
