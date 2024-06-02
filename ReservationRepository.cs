using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ceng._382._23._24.s._202011055
{
    public class ReservationRepository : IReservationRepository
{
    private readonly List<Reservation> _reservations = new();

    public void AddReservation(Reservation reservation)
    {
        _reservations.Add(reservation);
    }

    public void DeleteReservation(Reservation reservation)
    {
        var item = _reservations.FirstOrDefault(r =>
            r.Date == reservation.Date &&
            r.Time == reservation.Time &&
            r.Room.RoomId == reservation.Room.RoomId);
        if (item != null)
        {
            _reservations.Remove(item);
        }
    }

    public List<Reservation> GetAllReservations()
    {
        return _reservations;
    }
}
}