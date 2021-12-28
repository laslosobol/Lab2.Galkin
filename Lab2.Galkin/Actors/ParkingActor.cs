using Akka.Actor;
using Lab2.Galkin.Messages;
using Lab2.Galkin.Models;

namespace Lab2.Galkin.Actors;

public class ParkingActor : ReceiveActor
{
    private readonly List<ParkingModel> _parkings = new List<ParkingModel>()
    {
        new ParkingModel("1"),
        new ParkingModel("2"),
        new ParkingModel("3")
    };

    public ParkingActor()
    {
        Receive<RequestParking>(message =>
        {
            var parking = _parkings.FirstOrDefault(x => !x.IsBusy);
            if (parking != null)
            {
                parking.CarLicensePlate = message.LicensePlate;
                Sender.Tell(new ReceivedParking(parking.Id, parking.CarLicensePlate));
            }
            else
            {
                Sender.Tell(new ParkingRejected(message.LicensePlate));
            }
        });
        Receive<LeaveParking>(message =>
        {
            var parking = _parkings.FirstOrDefault(x => x.CarLicensePlate == message.LicensePlate);
            if (parking != null) parking.CarLicensePlate = null;
        });
    }
}