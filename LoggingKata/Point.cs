namespace LoggingKata
{
    public struct Point
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Point(double longi,double lat)
        {
            Longitude = longi;
            Latitude = lat;
        }
    }
}