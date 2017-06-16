using System;
using System.Collections.Generic;
using Nancy;

namespace BandTracker
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };

      Get["/venues"] = _ => {
        List<Venue> allVenues = Venue.GetAll();
        return View["venues.cshtml", allVenues];
      };

      Get["/bands"] = _ => {
        List<Band> allBands = Band.GetAll();
        return View["bands.cshtml", allBands];
      };

      Get["/bands/add"] = _ => {
        return View["addBands.cshtml"];
      };

      Get["/venues/add"] = _ => {
        return View["addVenues.cshtml"];
      };

      Post["/bands/add/success"] = _ => {
        Band newBand = new Band(Request.Form["new-band"]);
        newBand.Save();
        return View["success.cshtml"];
      };

      Post["/venues/add/success"] = _ => {
        Venue newVenue = new Venue(Request.Form["new-venue"]);
        newVenue.Save();
        return View["success.cshtml"];
      };

      Get["/bands/{id}"] = parameters => {
        Band findBand = Band.Find(parameters.id);
        return View["band.cshtml", findBand];
      };

      
    }
  }
}
