using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything
            //Arrange
            TacoParser sut = new TacoParser();

            //Act
            var actual = sut.Parse("38.42,84.56,Tacooooos");

            //Assert
            Assert.NotNull(actual);


        }

        [Theory]
        [InlineData("38.4,56.8,DaBell", 38.4 , 56.8 , "DaBell")]
        public void ShouldParse(string str, double longi, double lat, string name )
        {
            // TODO: Complete Should Parse
            //Arrange
            TacoParser sut = new TacoParser();

            //Act
            var actual = sut.Parse(str);

            //Assert
            Assert.Equal(longi, actual.Location.Latitude);
            Assert.Equal(lat, actual.Location.Longitude);
            Assert.Equal(name, actual.Name);



        }

        [Theory]
        [InlineData("")]
        public void ShouldFailParse(string str)
        {
            // TODO: Complete Should Fail Parse

            //Arrange
            TacoParser sut = new TacoParser();


            //Act
            var actual = sut.Parse(str);

            //Assert
            Assert.Equal(null, actual);
        }
    }
}
