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
        bool nameEquality = this.GetName() == newVenue.GetName();
        bool idEquality = this.GetId() == newVenue.GetId();
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

      return venues;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO venues (name) OUTPUT INSERTED.id VALUES (@VenueName)", conn);

      SqlParameter nameParameter = new SqlParameter("@VenueName", this.GetName());
      cmd.Parameters.Add(nameParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
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

    public static Venue Find(int IdToFind)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM venues WHERE id = @VenueId", conn);
      SqlParameter idParam = new SqlParameter("@VenueId", IdToFind);
      cmd.Parameters.Add(idParam);

      SqlDataReader rdr = cmd.ExecuteReader();

      int id = 0;
      string name = null;

      while(rdr.Read())
      {
        id = rdr.GetInt32(0);
        name = rdr.GetString(1);
      }

      Venue newVenue = new Venue(name, id);

      if(rdr != null)
      {
        rdr.Close();
      }

      if(conn != null)
      {
        conn.Close();
      }

      return newVenue;
    }

    public void AddBand(Band BandToAdd)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO bands_venues (band_id, venue_id) VALUES (@band_Id, @venue_id);", conn);

      SqlParameter BandIdParam = new SqlParameter("@band_Id", BandToAdd.GetId());
      cmd.Parameters.Add(BandIdParam);

      SqlParameter VenueIdParam = new SqlParameter("@venue_id", this.GetId());
      cmd.Parameters.Add(VenueIdParam);

      cmd.ExecuteNonQuery();

      if(conn != null)
      {
        conn.Close();
      }
    }

    public List<Band> GetBands()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT bands.* FROM venues JOIN bands_venues ON (venues.id = bands_venues.venue_id) JOIN bands ON (bands.id = bands_venues.band_id) WHERE venue_id = @Venue_Id;", conn);

      SqlParameter VenueIdParam = new SqlParameter("@Venue_id", this.GetId());
      cmd.Parameters.Add(VenueIdParam);

      List<Band> bands = new List<Band>{};

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        Band newBand = new Band(name, id);
        bands.Add(newBand);
      }

      if(rdr != null)
      {
        rdr.Close();
      }

      if(conn != null)
      {
        conn.Close();
      }

      return bands;
    }

    public void Update(string newName)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE venues SET name = @NewName OUTPUT INSERTED.name WHERE id = @venueId;", conn);

      SqlParameter newNameParameter = new SqlParameter();
      newNameParameter.ParameterName = "@NewName";
      newNameParameter.Value = newName;
      cmd.Parameters.Add(newNameParameter);


      SqlParameter categoryIdParameter = new SqlParameter();
      categoryIdParameter.ParameterName = "@venueId";
      categoryIdParameter.Value = this.GetId();
      cmd.Parameters.Add(categoryIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._name = rdr.GetString(0);
      }

      if (rdr != null)
      {
        rdr.Close();
      }

      if (conn != null)
      {
        conn.Close();
      }
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM venues; DELETE FROM bands_venues;", conn);
      cmd.ExecuteNonQuery();

      if(conn != null)
      {
        conn.Close();
      }
    }
  }
}
