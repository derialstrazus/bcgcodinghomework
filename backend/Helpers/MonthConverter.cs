using System;
using System.Collections.Generic;

namespace backend
{
  public class MonthConverter
  {
    public static string IntToString(int month)
    {

      Dictionary<int, string> map = new Dictionary<int, string>() 
      { 
        { 1, "January" }, 
        { 2, "Febuary" }, 
        { 3, "March" }, 
        { 4, "April" }, 
        { 5, "May" }, 
        { 6, "June" }, 
        { 7, "July" }, 
        { 8, "August" }, 
        { 9, "September" }, 
        { 10, "October" }, 
        { 11, "November" }, 
        { 12, "December" }
      };

      return map[month];
    }
  }

}