function hello() {
  console.log("hi");

  var data = [
    {
      RegionName: "Illinois",
      RegionType: "City",
      Year: 2010,
      Month: 1,
      Count: 500,
    },
    {
      RegionName: "Illinois",
      RegionType: "City",
      Year: 2010,
      Month: 2,
      Count: 649,
    },
    {
      RegionName: "Illinois",
      RegionType: "City",
      Year: 2010,
      Month: 3,
      Count: 633,
    },
    {
      RegionName: "Illinois",
      RegionType: "City",
      Year: 2010,
      Month: 4,
      Count: 448,
    },
    {
      RegionName: "Georgia",
      RegionType: "City",
      Year: 2010,
      Month: 1,
      Count: 675,
    },
    {
      RegionName: "Georgia",
      RegionType: "City",
      Year: 2010,
      Month: 2,
      Count: 712,
    },
    {
      RegionName: "Georgia",
      RegionType: "City",
      Year: 2010,
      Month: 3,
      Count: 678,
    },
    {
      RegionName: "New York",
      RegionType: "City",
      Year: 2010,
      Month: 1,
      Count: 836,
    },
    {
      RegionName: "New York",
      RegionType: "City",
      Year: 2010,
      Month: 2,
      Count: 255,
    },
    {
      RegionName: "New York",
      RegionType: "City",
      Year: 2010,
      Month: 3,
      Count: 245,
    },
  ];



  console.log(data[0]);

  var container = $("#body").empty();

  RenderTable(data, container)
  
}

function RenderTable(data, container) {
  var uniqueRegions = []
  for (const item of data) {
    if (!uniqueRegions.includes(item.RegionName)) {
      uniqueRegions.push(item.RegionName);
    }
  }
  
  var uniqueMonths = []
  for (const item of data) {
    if (!uniqueMonths.includes(item.Month)) {
      uniqueMonths.push(item.Month);
    }
  }
  
  var table = $(`<table></table>`).appendTo(container);
  var headerRow = $(`<tr></tr>`).appendTo(table);
  headerRow.append(`<th></th>`);
  for (let index = 0; index < uniqueRegions.length; index++) {
    const region = uniqueRegions[index];
    console.log(region);
    headerRow.append(`<th>${region}</th>`);
  }

  for (let index = 0; index < uniqueMonths.length; index++) {
    const month = uniqueMonths[index];
    var monthRow = $(`<tr></tr>`).appendTo(table);
    monthRow.append(`<td>${month}</td>`);
    for (let index = 0; index < uniqueRegions.length; index++) {
      const region = uniqueRegions[index];
      
      var count = "-";
      for (const item of data) {
        if (item.Month == month && item.RegionName == region) {
          count = item.Count;
        }
      }
      monthRow.append(`<td>${count}</td>`);
    }
  }

  var averageRow = $(`<tr></tr>`).appendTo(table);
  averageRow.append(`<td>Average</td>`);
  for (let index = 0; index < uniqueRegions.length; index++) {
    const region = uniqueRegions[index];
    var regionSales = [];
    for (const item of data) {
      if (item.RegionName == region) {
        regionSales.push(item.Count);
      }
    }
    var total = 0;
    for(var i = 0; i < regionSales.length; i++) {
        total += regionSales[i];
    }
    var average = total / regionSales.length;

    averageRow.append(`<td>${average.toFixed(1)}</td>`);
  }

  var medianRow = $(`<tr></tr>`).appendTo(table);
  medianRow.append(`<td>Median</td>`);
  for (let index = 0; index < uniqueRegions.length; index++) {
    const region = uniqueRegions[index];
    var regionSales = [];
    for (const item of data) {
      if (item.RegionName == region) {
        regionSales.push(item.Count);
      }
    }
    
    regionSales.sort();
    mid = Math.floor(regionSales.length / 2)
    console.log(mid)
    if (regionSales.length % 2)
      median = regionSales[mid]
    else
      median = (regionSales[mid-1] + regionSales[mid]) / 2.0

    medianRow.append(`<td>${median}</td>`);
  }

  var totalRow = $(`<tr></tr>`).appendTo(table);
  totalRow.append(`<td>Total</td>`);
  for (let index = 0; index < uniqueRegions.length; index++) {
    const region = uniqueRegions[index];
    var regionSales = [];
    for (const item of data) {
      if (item.RegionName == region) {
        regionSales.push(item.Count);
      }
    }
    var total = 0;
    for(var i = 0; i < regionSales.length; i++) {
        total += regionSales[i];
    }
    var average = total / regionSales.length;

    totalRow.append(`<td>${total}</td>`);
  }
}

function GetData(params, success, failure, returnContext) {

  params = {
    url: "http://localhost:5000/sales",
    method: "GET"
  }

  $.ajax(params).then(
    function(data, textStatus, xhr) {
      console.log(data);
      success(data, returnContext);
    },
    function (xhr, status, error) {
      failure(xhr.status, compiledError, returnContext);
    }
  )
}

