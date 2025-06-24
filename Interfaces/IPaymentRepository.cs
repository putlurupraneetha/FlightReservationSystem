using FlightReservationSystem.Data;
using FlightReservationSystem.Models;
using FlightReservationSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FlightReservationSystem.Interfaces
{

public interface IPaymentRepository
{
    Task<Payment> GetPaymentByIdAsync(int id);
    Task<IEnumerable<Payment>> GetAllPaymentsAsync();
    Task AddPaymentAsync(Payment payment);
    Task UpdatePaymentAsync(Payment payment);
    Task DeletePaymentAsync(int id);
}
}
