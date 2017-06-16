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

    
  }
}
