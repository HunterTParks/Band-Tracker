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
      DBConfiguration.ConnectionString = "Data Source=GAMING-PC;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void CheckIfDataBaseIsEmpty_Empty_Band()
    {
      List<Band> testList = Band.GetAll();
      List<Band> controlList = new List<Band>{};

      Assert.Equal(controlList, testList);
    }

    [Fact]
    public void SaveToDataBase_Band_Band()
    {
      Band controlBand = new Band("Nirvana");
      controlBand.Save();

      Band newBand = Band.GetAll()[0];
      Assert.Equal(controlBand.GetName(), newBand.GetName());
    }

    [Fact]
    public void CheckForDuplicate_Band_True()
    {
      Band controlBand = new Band("Nirvana");
      Band testBand = new Band("Nirvana");

      Assert.Equal(controlBand.GetName(), testBand.GetName());
    }

    [Fact]
    public void FindBandInDataBase_id_Band()
    {
      Band controlBand = new Band("Nirvana");
      controlBand.Save();

      Band newBand = Band.Find(controlBand.GetId());

      Assert.Equal(controlBand.GetName(), newBand.GetName());
    }

    [Fact]
    public void AddVenueToBand_Venue_Venue()
    {
      Venue newVenue = new Venue("Warped Tour");
      newVenue.Save();

      Venue newVenue2 = New Venue("Rose Quarter");
      newVenue2.Save();

      Band newBand1 = new Band("Issues");
      newBand1.Save();

      newBand1.AddVenue(newVenue());

      List<Venue> testList = newBand1.GetVenues();
      List<Venue> controlList = new List<Band>{newVenue, newVenue2};

      Assert.Equal(controlList[0].GetName(), testList[0].GetName())

    }

    public void Dispose()
    {
      Band.DeleteAll();
      Venue.DeleteAll();
    }
  }
}
