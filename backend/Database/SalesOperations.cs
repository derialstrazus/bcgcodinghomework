using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using backend.Models;

namespace backend.Database
{
  public class SalesOperations
  {
    readonly SqlConnectionStringBuilder builder;

    public SalesOperations()
    {
      builder = new SqlConnectionStringBuilder
      {
        DataSource = "adjutantserver.database.windows.net",
        UserID = "BCGInterviewer",
        Password = "hell0Derek",
        InitialCatalog = "CodingSamples"
      };
    }

    public bool CreateSales(List<Sales> salesData)
    {
      try
      {
        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
        {
          connection.Open();

          StringBuilder sb = new StringBuilder();
          sb.Append("INSERT INTO BcgEvSales ");
          sb.Append("(RegionType, RegionName, Year, Month, Count) ");
          sb.Append("VALUES ");
          List<string> values = new List<string>();
          foreach (Sales sales in salesData)
          {
            string month = sales.Month != null ? sales.Month.ToString() : "0";
            values.Add($"('{sales.RegionType}', '{sales.RegionName}', {sales.Year}, {month}, {sales.Count})");
          }
          sb.Append(string.Join(',', values));

          String sql = sb.ToString();
          Console.WriteLine(sql);

          using (SqlCommand command = new SqlCommand(sql, connection))
          {
            command.ExecuteNonQuery();
            return true;
          }
        }
      }
      catch (Exception ex)
      {

        throw;
      }
    }

    public List<Sales> GetSales()
    {
      List<Sales> results = new List<Sales>();

      SqlConnectionStringBuilder altBuilder = new SqlConnectionStringBuilder
      {
        DataSource = "adjutantserver.database.windows.net",
        UserID = "BCGInterviewer",
        Password = "hell0Derek",
        InitialCatalog = "CodingSamples"
      };


      try
      {
        using (SqlConnection connection = new SqlConnection(altBuilder.ConnectionString))
        {
          connection.Open();
          StringBuilder sb = new StringBuilder();
          sb.Append("SELECT * FROM BcgEvSales");
          Console.WriteLine(sb);
          string sql = sb.ToString();

          using (SqlCommand command = new SqlCommand(sql, connection))
          {
            using (SqlDataReader reader = command.ExecuteReader())
            {
              while (reader.Read())
              {

                results.Add(new Sales()
                {
                  Year = reader.GetInt32(0),
                  Month = reader.GetInt32(1),
                  RegionName = reader.GetString(2),
                  RegionType = reader.GetString(3),
                  Count = reader.GetInt32(4)
                });
              }
            }

            return results;
          }


        }
      }
      catch (Exception ex)
      {

        throw;
      }
    }

    public bool ResetData()
    {
      try
      {
        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
        {
          connection.Open();

          StringBuilder sbDelete = new StringBuilder();
          sbDelete.Append("DELETE FROM BcgEvSales");
          String sqlDelete = sbDelete.ToString();
          Console.WriteLine(sqlDelete);

          using (SqlCommand command = new SqlCommand(sqlDelete, connection))
          {
            command.ExecuteNonQuery();
          }



          StringBuilder sb = new StringBuilder();

          List<Sales> salesData = new List<Sales>(){
                        new Sales() { RegionName = "Chicago", RegionType = "City", Year = 2020, Month = 01, Count = 500 },
                        new Sales() { RegionName = "Chicago", RegionType = "City", Year = 2020, Month = 02, Count = 650 }
                    };

          sb.Append("INSERT INTO BcgEvSales ");
          sb.Append("(RegionType, RegionName, Year, Month, Count) ");
          sb.Append("VALUES ");
          List<string> values = new List<string>();
          foreach (Sales sales in salesData)
          {
            string month = sales.Month != null ? sales.Month.ToString() : "0";
            values.Add($"('{sales.RegionType}', '{sales.RegionName}', {sales.Year}, {month}, {sales.Count})");
          }
          sb.Append(string.Join(',', values));

          String sql = sb.ToString();
          Console.WriteLine(sql);

          using (SqlCommand command = new SqlCommand(sql, connection))
          {
            command.ExecuteNonQuery();
            return true;
          }
        }
      }
      catch (Exception ex)
      {

        throw;
      }
    }

  }
}