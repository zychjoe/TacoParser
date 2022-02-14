using System;
namespace LoggingKata
{
    public class TacoBell : ITrackable // Where we store info for each Taco Bell
    {
        public string Name { get; set; } //In the form of "Taco Bell [city]..."
        public Point Location { get; set; } //Has double properties Latitude and Longitude.

        public string Slogan = "Live Mas"; //I don't plan on using this property
                                           // but it's good advice, so I'm adding it.

    public TacoBell(string name, Point location)
        {
            Name = name;
            Location = location;
        }
    }
}
