using System;

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
            //logger.LogInfo("Begin parsing");



            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3 || cells == null)
            {
                logger.LogError("Parse Method failed");
                return null;
            }

            // grab the latitude from your array at index 0
            //logger.LogInfo("Latitude at [0]");
            //Console.WriteLine(double.Parse(cells[0]));
            var bellLat = double.Parse(cells[0]);
            // grab the longitude from your array at index 1
            //Console.WriteLine(double.Parse(cells[1]));
            var bellLong = double.Parse(cells[1]);
            // grab the name from your array at index 2
            //Console.WriteLine(cells[2]);
            var bellName = cells[2];
            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`

            // You'll need to create a TacoBell class
            // that conforms to ITrackable
            var tacos = new TacoBell();
            tacos.Name = bellName;
            tacos.Location = new Point(bellLong,bellLat);



          



            //done
            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly

            return tacos;
            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            // Do not fail if one record parsing fails, return null
            // TODO Implement
        }
       
}
}