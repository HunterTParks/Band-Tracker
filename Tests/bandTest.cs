using Xunit;
using System;
using System.Collections.Generic;

namespace BandTracker
{
  [Collection("Band")]
  public class bandTests : IDisposable
  {
    public bandTests()
    {
      // DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker;Integrated Security=SSPI;";
      DBConfiguration.ConnectionString = "Data Source=GAMING-PC;Initial Catalog=band_tracker;Integrated Security=SSPI;";
    }
    
  }
}
