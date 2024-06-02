using System.Collections.Generic;
using System.Linq;

public class ReservationHandler
{
    public class ReservationHandler
{
    private readonly IReservationRepository _reservationRepository;
    private readonly LogHandler _logHandler;

    public ReservationHandler(IReservationRepository reservationRepository, LogHandler logHandler)
    {
        _reservationRepository = reservationRepository;
        _logHandler = logHandler;
    }

    public void AddReservation(Reservation reservation)
    {
        _reservationRepository.AddReservation(reservation);
        _logHandler.AddLog(new LogRecord(DateTime.Now, reservation.ReserverName, reservation.Room.RoomName));
    }

    public void DeleteReservation(Reservation reservation)
    {
        _reservationRepository.DeleteReservation(reservation);
        _logHandler.AddLog(new LogRecord(DateTime.Now, reservation.ReserverName, reservation.Room.RoomName));
    }

    public void DisplayWeeklySchedule()
    {
        var reservations = _reservationRepository.GetAllReservations();
        foreach (var reservation in reservations)
        {
            Console.WriteLine($"Date: {reservation.Date.ToShortDateString()}, Time: {reservation.Time.ToShortTimeString()}, Reserver: {reservation.ReserverName}, Room: {reservation.Room.RoomName}");
        }
    }
}
}
