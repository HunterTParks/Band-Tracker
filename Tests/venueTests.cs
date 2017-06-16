using Xunit;
using System;
using System.Collections.Generic;

namespace BandTracker
{
  [Collection("Band")]
  public class venueTests : IDisposable
  {
    public venueTests()
    {
      // DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=university_test;Integrated Security=SSPI;";
      DBConfiguration.ConnectionString = "Data Source=GAMING-PC;Initial Catalog=university_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void CheckIfDataBaseIsEmpty_Empty_Venue()
    {
      List<Venue> testList = Venue.GetAll();
      List<Venue> controlList = new List<Venue>{};

      Assert.Equal(controlList, testList);
    }
  }
}
