namespace Hotel_Reservation_System.Models;

public class Guest
{
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
        var reservation = new Reservation(room, checkInDate, checkOutDate);
        _reservations.Add(reservation);
        return reservation;
    }

    public Guid GuestId { get; init; } = Guid.NewGuid();
    public string FullName { get; init; }
    public string PhoneNumber { get; init; }

    private readonly List<Reservation> _reservations = new();
}