﻿namespace Lab2.Galkin.Messages;

public class ReceivedParking
{
    public string ParkingId { get; }
    public string LicensePlate { get; }

    public ReceivedParking(string parkingId, string licensePlate)
    {
        ParkingId = parkingId;
        LicensePlate = licensePlate;
    }
}