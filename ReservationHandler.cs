using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ceng._382._23._24.s._202011055
{
    public class ReservationHandler
    {
         public Reservation[,] Reservations { get; set; }

    public ReservationHandler()
    {
        Reservations = new Reservation[7, 24];
    }

    public void AddReservation(Reservation reservation)
    {
        int day = (int)reservation.Date.DayOfWeek;
        int hour = reservation.Time.Hour;
        Reservations[day, hour] = reservation;
    }

    public void DeleteReservation(Reservation reservation)
    {
        int day = (int)reservation.Date.DayOfWeek;
        int hour = reservation.Time.Hour;
        Reservations[day, hour] = null;
    }

    public void DisplayWeeklySchedule()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 24; j++)
            {
                if (Reservations[i, j] != null)
                {
                    Console.WriteLine($"Day: {i}, Hour: {j}, Reservation: {Reservations[i, j].ReserverName}");
                }
            }
        }
    }
    }
}