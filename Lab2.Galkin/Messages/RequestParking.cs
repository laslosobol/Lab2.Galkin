namespace Lab2.Galkin.Messages;

public class RequestParking
{
    public string LicensePlate { get; }

    public RequestParking(string licensePlate)
    {
        LicensePlate = licensePlate;
    }
}