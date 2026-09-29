using Hotel_Reservation_System.Enums;

namespace Hotel_Reservation_System.Models;

public class Reservation
{
    public Reservation(Room room, DateTime checkIn, DateTime checkOut)
    {
        if (room == null)
        {
            throw new ArgumentNullException(nameof(Room));
        }

        if (room.IsUnderMaintenance)
        {
            throw new ArgumentException("Room is under maintenance", nameof(room));
        }

        if (checkIn > checkOut)
            throw new ArgumentException("Checking in incorrect date", nameof(checkIn));


        Room = room;
        CheckInDate = checkIn;
        CheckOutDate = checkOut;
    }

    public void CheckIn()
    {
        if (Room.IsUnderMaintenance)
        {
            throw new ArgumentException("Room is under maintenance", nameof(Room));
        }

        if (Status != ReservationStatus.Confirmed && Status != ReservationStatus.Pending)
        {
            throw new ArgumentException("Reservation is not confirmed", nameof(Status));
        }

        Status = ReservationStatus.CheckedIn;
    }


    public void CheckOut()
    {
        if (Status != ReservationStatus.CheckedIn)
        {
            throw new ArgumentException("Reservation is not checked in", nameof(Status));
        }

        Status = ReservationStatus.CheckedOut;
    }

    public void Confirm()
    {
        if (Status != ReservationStatus.Pending)
            throw new InvalidOperationException("Only pending reservations can be confirmed.");

        Status = ReservationStatus.Confirmed;
    }

    public void Cancel()
    {
        if (Status != ReservationStatus.CheckedOut)
        {
            throw new ArgumentException("Reservation is not checked in", nameof(Status));
        }

        Status = ReservationStatus.Cancelled;
    }


    public int RevervationId { get; init; }
    public DateTime CheckInDate { get; init; }
    public DateTime CheckOutDate { get; init; }
    public ReservationStatus Status { get; private set; } = ReservationStatus.Pending;
    public Room Room { get; init; }

    public int TotalNights => (CheckOutDate.Date - CheckInDate.Date).Days;
    public decimal TotalCost => TotalNights * Room.NightlyRate;
}