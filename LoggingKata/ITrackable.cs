namespace LoggingKata
{
    public interface ITrackable //This interface will help us make Taco Bells.
    {
        string Name { get; set; }
        Point Location { get; set; }
    }
}