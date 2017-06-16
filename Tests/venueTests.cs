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
      // DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker;Integrated Security=SSPI;";
      DBConfiguration.ConnectionString = "Data Source=GAMING-PC;Initial Catalog=band_tracker;Integrated Security=SSPI;";
    }

    [Fact]
    public void CheckIfDataBaseIsEmpty_Empty_Venue()
    {
      List<Venue> testList = Venue.GetAll();
      List<Venue> controlList = new List<Venue>{};

      Assert.Equal(controlList, testList);
    }

    [Fact]
    public void SaveToDataBase_Venue_Venue()
    {
      Venue controlVenue = new Venue("SuperBowl");
      controlVenue.Save();

      Venue newVenue = Venue.GetAll()[0];
      Assert.Equal(controlVenue.GetName(), newVenue.GetName());
    }

    [Fact]
    public void CheckForDuplicate_Venue_True()
    {
      Venue controlVenue = new Venue("SuperBowl");
      Venue newVenue = new Venue("SuperBowl");
      Assert.Equal(controlVenue.GetName(), newVenue.GetName());
    }

    [Fact]
    public void FindVenueInDatabase_id_Venue()
    {
      Venue controlVenue = new Venue("SuperBowl");
      controlVenue.Save();

      Venue newVenue = Venue.Find(controlVenue.GetId());

      Assert.Equal(controlVenue.GetName(), newVenue.GetName());
    }

    public void Dispose()
    {
      Venue.DeleteAll();
    }
  }
}
