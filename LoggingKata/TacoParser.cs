using System;
using static System.Console;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Takes a CSV line and uses line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If the array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // We'll log that and return null
                logger.LogError("Line does not contain a Taco Bell", new ArgumentOutOfRangeException());
                return null;
            }

            // We'll grab the latitude from our array at index 0...
            var latString = cells[0];

            // ...the longitude from our array at index 1...
            var longString = cells[1];

            // ...and the name from our array at index 2.
            var name = cells[2];

            // Now we're going to need to parse our strings as a `double`.

            var latitude = Double.Parse(latString);
            var longitude = Double.Parse(longString);

            // Now let's store the parsed info in a new TacoBell.
            var location = new Point() { Latitude = latitude, Longitude = longitude };

            var tacoBell = new TacoBell(name, location);

            logger.LogInfo($"{tacoBell.Name}" +
                           $" is at Lat: {tacoBell.Location.Latitude}" +
                           $" & Long: {tacoBell.Location.Longitude}.");

            // And we'll retunr the new TacoBell.

            return tacoBell;
        }
    }
}