﻿using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Enums;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;


namespace BuberDinner.Domain.Dinner.Entities
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
