using Akka.Actor;
using Lab2.Galkin.Actors;

const int numberOfCars = 25;
using var system = ActorSystem.Create("CarParking");
            
var parking = system.ActorOf<ParkingActor>("parking");
var carIndexes = new List<int>();
for (var i = 0; i < numberOfCars; i++)
{
    carIndexes.Add(i);
}

Parallel.ForEach(carIndexes, index =>
{
    var delay = (index + 1) * 1000;
    system.ActorOf(Props.Create(() =>
        new CarActor(parking, $"car{index}", delay)));

});

Console.ReadLine();