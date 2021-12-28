namespace Lab2.Galkin.Messages;

public class ParkingRejected
{
    public string LicensePlate { get; }

    public ParkingRejected(string licensePlate)
    {
        LicensePlate = licensePlate;
    }
}