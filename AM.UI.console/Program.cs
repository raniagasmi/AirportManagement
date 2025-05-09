// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Service;
using AM.Infrastructure;

Console.WriteLine("Hello, World!");
//Plane P1 = new Plane();
//P1.Capacite = 10;
//P1.ManufactureDate = DateTime.Now;
//P1.PlaneId = 2;
//P1.PlaneType = PlaneType.Boing;
//Plane P2 = new Plane(20,new DateTime(2024,5,6),5);


// initiliseur object
Plane P1 = new Plane
{
    Capacity = 10,
    ManufactureDate = DateTime.Now,
    PlaneId = 1,
    PlaneType  = PlaneType.Airbus,
};

Console.WriteLine(P1);


Passenger Pass = new Passenger
{
    fullName = new FullName
    {
        FirstName = "Khouloud",
        LastName = "Ammar"
    },
    EmailAddress="khouloud.ammar@esprit.tn"
};
Console.WriteLine("***************** Test checkprofile**************************");
Console.WriteLine(Pass.CheckProfile("Ammar", "Khouloud"));
Console.WriteLine(Pass.CheckProfile("Ammar", "Khouloud","@@@"));
Console.WriteLine("***************** Test PassengerType**************************");
Traveller T1 = new Traveller();
Staff s1 = new Staff();

Pass.PassengerType();
T1.PassengerType();
s1.PassengerType();
Plane PlaneBoeing2= new Plane { PlaneType = PlaneType.Boing, Capacity = 150, ManufactureDate = new DateTime(2015, 02, 03) };

Console.WriteLine("***************** Test Getflightdates**************************");
//FlightService sf = new FlightService();

//// Adding sample flights 
//sf.Flights.Add(new Flight { FlightId = 1, Destination = "Paris", FlightDate = new DateTime(2024, 12, 1), Departure = DateTime.Now});
//sf.Flights.Add(new Flight { FlightId = 2, Destination = "New York", FlightDate = new DateTime(2024, 11, 1), Departure = DateTime.Now });
//sf.Flights.Add(new Flight { FlightId = 3, Destination = "Paris", FlightDate = new DateTime(2024, 12, 2), Departure = DateTime.Now });

//sf.Flights = TestData.listFlights;

//foreach (var item in sf.GetFlightdates("Paris"))
//{
//    Console.WriteLine(item);
//}
//Console.WriteLine("***************** Test Showflight details**************************");
//sf.ShowFlightDetails(PlaneBoeing2);
//Console.WriteLine("***************** ProgrammedFlightNumber**************************");
//Console.WriteLine(sf.ProgrammedFlightNumber(new DateTime (2024, 11, 1)));
//Console.WriteLine("***************** Duration Average****");
//    Console.WriteLine(sf.DurationAverage("Paris"));


//sf.DestinationGroupedFlights();
//sf.DestinationGroupedF();

AMContext aMContext = new AMContext();

//aMContext.Planes.Add(TestData.BoingPlane);
//aMContext.SaveChanges();


//aMContext.Flights.Add(TestData.flight1);
//aMContext.SaveChanges();

foreach(var item in aMContext.Flights)
{
    Console.WriteLine(item.Destination);
    Console.WriteLine(item.Plane.Capacity);
}