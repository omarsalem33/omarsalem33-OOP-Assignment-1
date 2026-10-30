using Hotel_Reservation_System.Enums;
using Hotel_Reservation_System.Models;

namespace Hotel_Reservation_System;

class Program
{
    static void Main(string[] args)
    {
        var room = new Room("Suite-101", RoomType.Suite, 250.00m);

        var guest = new Guest( "Omar Salem",  "01211590390");
        var reservation = guest.MakeReservation(room, DateTime.Now.Date, DateTime.Now.AddDays(3).Date);

        Console.WriteLine($"Total Nights: {reservation.TotalNights}");
        Console.WriteLine($"Total Cost: {reservation.TotalCost:C}");

        reservation.Confirm();
        reservation.CheckIn();
        reservation.CheckOut();
    }
}