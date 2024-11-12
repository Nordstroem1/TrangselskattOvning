using TrängselskattGBG;

TrangselSkattLogik trangselSkattLogik = new TrangselSkattLogik();

var cost = trangselSkattLogik.CalculateCostBasedOnTime("2023-10-15T17:30:00");
Console.WriteLine($"The cost is: {cost} kr");