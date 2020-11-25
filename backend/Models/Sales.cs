using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Models {
  public class Sales {

    [Required]
    public string RegionType { get; set; }
    
    [Required]
    public string RegionName { get; set; }

    
    
    [Range(1900,3000)]
    public int Year { get; set; }
    public int? Month { get; set; }
    
    public int Count { get; set; }
  }
}

