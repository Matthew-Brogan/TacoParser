using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Security.Cryptography;
using System.Threading;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
            // HINT:  You'll need two nested forloops


            // DON'T FORGET TO LOG YOUR STEPS

            logger.LogInfo("Searching for the two taco bells that are furtherest from eachother!");
            Thread.Sleep(3000);
            // Now, here's the new code
           ITrackable locA = null;
           ITrackable locB = null;
            ITrackable p1 = null;
            ITrackable p2 = null;
            // Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the furthest from each other.
            // Create a `double` variable to store the distance
            double dist = 0;
            double maxDist = 0;
            double inMiles;
            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            // Create a new corA Coordinate with your locA's lat and long
            //Coordinate is a class(needs instantiated)

            logger.LogInfo("Comparing all the Taco Bell resturants.... ");

            Thread.Sleep(500);
            for(int i = 0; i < locations.Length; i++)
            {
                locA = locations[i];
                GeoCoordinate cordA = new GeoCoordinate();

                cordA.Latitude = locA.Location.Latitude;
                cordA.Longitude = locA.Location.Longitude;


                for(int j = 0; j< locations.Length; j++)
                {
                    locB = locations[j];
                    GeoCoordinate cordb = new GeoCoordinate();
                    cordb.Latitude = locB.Location.Latitude;
                    cordb.Longitude = locB.Location.Longitude;

                    dist = cordA.GetDistanceTo(cordb);


                    
                    if(maxDist < dist) 
                    {
                        maxDist = dist;
                        
                        p1 = locA;
                        p2 = locB;
                        
                    }
                    
                    
                   
                }

            }
            logger.LogInfo("Determining greatest distance!");
            Thread.Sleep(500);
            inMiles = maxDist * 0.000621371;
            logger.LogInfo("Converting answer to miles...");
            Thread.Sleep(100);

            Console.WriteLine(p1.Name +" is "+Math.Floor(inMiles)+" miles from "+ p2.Name );
            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)
            // Create a new Coordinate with your locB's lat and long
            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above
            //blue ridge and foley!!!
            // Once you've looped through everything, you've found the two Taco Bells furthest away from each other.
        }
    }
}