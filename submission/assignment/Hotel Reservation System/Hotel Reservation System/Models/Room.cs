using Hotel_Reservation_System.Enums;

namespace Hotel_Reservation_System.Models;

public class Room
{
    public string RoomNumber { get;  }
    public RoomType  RoomType { get;  }
    public decimal NightlyRate { get; private set; }
    public bool IsUnderMaintenance { get; private set; }
    
    public Room(string roomNumber, RoomType roomType, decimal nightlyRate)
    {
       if(string.IsNullOrEmpty(roomNumber)) 
           throw new ArgumentException("Room number cannot be null or empty", nameof(roomNumber));
       if(nightlyRate <= 0)
            throw new ArgumentException("Nightly rate cannot be negative", nameof(nightlyRate));
        
       RoomNumber = roomNumber;
       RoomType = roomType;
       NightlyRate = nightlyRate;
    }

    public void StartMaintenance()
    {
        IsUnderMaintenance = true;
    }
    public void EndMaintenance()
    {
        IsUnderMaintenance = false;
    }

    public void UpdateNightlyRate(decimal nightlyRate)
    {
        if(nightlyRate <= 0)
            throw new ArgumentException("Nightly rate cannot be negative", nameof(nightlyRate));
        NightlyRate = nightlyRate;
    }
    
}