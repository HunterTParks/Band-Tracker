using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BandTracker
{
  public class Venue
  {
    private int _id;
    private string _name;

    public Venue(string name, int id = 0)
    {
      _id = id;
      _name = name;
    }

    public int GetId()
    {
      return _id;
    }

    public string GetName()
    {
      return _name;
    }

    public override bool Equals(System.Object otherVenue)
    {
      if(!(otherVenue is Venue))
      {
        return false;
      }
      else
      {
        Venue newVenue = (Venue) otherVenue;
        bool nameEquality = this.GetName() == otherVenue.GetName();
        bool idEquality = this.GetId() == otherVenue.GetId();
        return (nameEquality && idEquality);
      }
    }

    public static List<Venue> GetAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM venues", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      List<Venue> venues = new List<Venue>{};

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        Venue newVenue = new Venue(name, id);
        venues.Add(newVenue);
      }

      if(rdr != null)
      {
        rdr.Close();
      }

      if(conn != null)
      {
        conn.Close();
      }
    }
  }
}
