using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.Enums;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;


namespace BuberDinner.Domain.DinnerAggregate.Entities
{
    public sealed class Reservation :Entity<ReservationId>
    {

        public int GuestCount { get; }
        public ReservationStatus ReservationStatus { get; private set; }
        public GuestId GuestId { get; }
        public BillId BillId { get; }
        public DateTime? ArrivalDateTime { get; private set; }
        public DateTime? CreatedDateTime { get; }
        public DateTime? UpdatedDateTime { get; private set; }

        public Reservation(
            ReservationId reservationId,
            int guestCount,
            ReservationStatus reservationStatus,
            GuestId guestId,
            BillId billId,
            DateTime? createdDateTime,
            DateTime? updatedDateTime) 
            : base(reservationId)
        {
            GuestCount = guestCount;
            ReservationStatus = reservationStatus;
            GuestId = guestId;
            BillId = billId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Reservation Create(int guestCount, GuestId guestId, BillId billId)
        {
            return new(
                ReservationId.CreateUnique(),
                guestCount,
                ReservationStatus.Reserved,
                guestId,
                billId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

        public void Cancel()
        {
            ReservationStatus = ReservationStatus.Cancelled;
            UpdatedDateTime = DateTime.UtcNow;
        }

        public void ConfirmArrival()
        {
            ArrivalDateTime = DateTime.UtcNow;
            UpdatedDateTime = DateTime.UtcNow;
        }
    }
}
