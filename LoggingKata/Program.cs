using System;
using System.Linq;
using System.IO;
using static System.Console;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // The goal is to find the two Taco Bells that are the furthest from one another.

            logger.LogInfo("Log initialized");

            // We'll use File.ReadAllLines(path) to grab all the lines from the csv file
            // We want to log an error if we get 0 lines and a warning if we get 1 line
            var lines = File.ReadAllLines(csvPath);
            if (lines == null || lines.Count() == 0)
            {
                logger.LogError("The given CSV file has no Taco Bells!",
                                new ArgumentOutOfRangeException());
            }

            else if (lines.Count() == 1)
            {
                logger.LogInfo($"Lines: {lines[0]}");
                logger.LogWarning("Expected more than 1 Taco Bell!");
            }

           
            var parser = new TacoParser(); // A new instance of the TacoParser class

            // We'll Grab an IEnumerable of locations.
            var locations = lines.Select(parser.Parse).ToArray();

            // Now to find the most distant Taco Bells.

            ITrackable bellA = null; //Will store one of the resulting Bells
            ITrackable bellB = null; //And the other resulting Bells

            double distance = 0; //This will hold the longest distance at any
                                 // given point in the calculations

            // Now we'll compare the distance between all locations using
            // nested loops.
            foreach(TacoBell locA in locations)
            {
                var corA = new GeoCoordinate(locA.Location.Latitude,
                                             locA.Location.Longitude);

                foreach (TacoBell locB in locations)
                {
                    var corB = new GeoCoordinate(locB.Location.Latitude,
                                                 locB.Location.Longitude);

                    var currDistance = corA.GetDistanceTo(corB);
                    if  (currDistance > distance)
                    {
                        bellA = locA;
                        bellB = locB;
                        distance = currDistance;
                    }
                }
            }

            // Once we've looped through everything, we've found the
            // two Taco Bells farthest away from each other!

            logger.LogInfo("We've Found the most distant Taco Bells!");
            logger.LogInfo($"{bellA.Name} is {Math.Round(distance * 0.00062, 2)} miles from {bellB.Name}");


            
        }
    }
}
