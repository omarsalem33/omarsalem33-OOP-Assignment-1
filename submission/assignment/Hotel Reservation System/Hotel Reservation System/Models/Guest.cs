using Hotel_Reservation_System.Enums;

namespace Hotel_Reservation_System.Models;

public class Guest
{
    
    public Guid GuestId { get; init; } = Guid.NewGuid();
    public string FullName { get; init; }
    public string PhoneNumber { get; init; }

    private readonly List<Reservation> _reservations = new();
    public Guest(string fullName, string phoneNumber)
    {
        if (string.IsNullOrEmpty(fullName))
            throw new ArgumentException("Full name cannot be null or empty", nameof(fullName));
        if (string.IsNullOrEmpty(phoneNumber))
            throw new ArgumentException("Phone number cannot be null or empty", nameof(phoneNumber));
        FullName = fullName;
        PhoneNumber = phoneNumber;
    }

    public Reservation MakeReservation(Room room, DateTime checkInDate, DateTime checkOutDate)
    {
        bool isOverLapping = _reservations.Any(r =>
            r.Room.RoomNumber == room.RoomNumber &&
            r.Status != ReservationStatus.Cancelled &&
            r.Status != ReservationStatus.CheckedOut &&
            r.CheckInDate > checkOutDate);

        if (isOverLapping)
        {
            throw new ArgumentException("Reservation is already overlapping.", nameof(checkInDate));
        }
        var reservation = new Reservation(room, checkInDate, checkOutDate);
        _reservations.Add(reservation);
        return reservation;
    }

}