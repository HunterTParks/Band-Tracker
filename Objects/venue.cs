using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BandTracker
{
  public class Venue
  {
    private int _id;
    private string _name;

    public Venue(int id, string name)
    {
      _id = id;
      _name = name;
    }
  }
}
