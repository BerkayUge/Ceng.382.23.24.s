using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        string roomsFilePath = "Data.json";
        string logFilePath = "LogData.json";
        RoomHandler roomHandler = new RoomHandler(roomsFilePath);
        List<Room> rooms = roomHandler.GetRooms();

        ILogger logger = new FileLogger(logFilePath);
        LogHandler logHandler = new LogHandler(logger);
        IReservationRepository reservationRepository = new ReservationRepository();
        ReservationHandler reservationHandler = new ReservationHandler(reservationRepository, logHandler);

        bool running = true;
        while (running)
        {
            Console.WriteLine("1. Add Reservation");
            Console.WriteLine("2. Delete Reservation");
            Console.WriteLine("3. Display Weekly Schedule");
            Console.WriteLine("4. Exit");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddReservation(reservationHandler, rooms);
                    break;
                case "2":
                    DeleteReservation(reservationHandler);
                    break;
                case "3":
                    reservationHandler.DisplayWeeklySchedule();
                    break;
                case "4":
                    running = false;
                    break;
            }
        }
    }

    static void AddReservation(ReservationHandler handler, List<Room> rooms)
    {
        Console.Write("Enter reserver name: ");
        string name = Console.ReadLine();

        Console.Write("Enter room ID: ");
        string roomId = Console.ReadLine();
        var room = rooms.Find(r => r.RoomId == roomId);
        if (room == null)
        {
            Console.WriteLine("Room not found");
            return;
        }

        Console.Write("Enter date (yyyy-MM-dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            Console.WriteLine("Invalid date format");
            return;
        }

        Console.Write("Enter time (HH:mm): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime time))
        {
            Console.WriteLine("Invalid time format");
            return;
        }

        var reservation = new Reservation(time, date, name, room);
        handler.AddReservation(reservation);
        Console.WriteLine("Reservation added");
    }

    static void DeleteReservation(ReservationHandler handler)
    {
        Console.Write("Enter date (yyyy-MM-dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            Console.WriteLine("Invalid date format");
            return;
        }

        Console.Write("Enter time (HH:mm): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime time))
        {
            Console.WriteLine("Invalid time format");
            return;
        }

        var reservation = new Reservation(time, date, null, null);
        handler.DeleteReservation(reservation);
        Console.WriteLine("Reservation deleted");
    }
}
