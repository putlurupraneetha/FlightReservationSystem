using Microsoft.AspNetCore.Mvc;
using FlightReservationSystem.DTOs;
using FlightReservationSystem.Interfaces;
using FlightReservationSystem.Models;
using FlightReservationSystem.Services; 
using FlightReservationSystem.Repositories;


namespace FlightReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            var payments = await _paymentRepository.GetAllPaymentsAsync();
            return Ok(payments);
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            var payment = await _paymentRepository.GetPaymentByIdAsync(id);
            if (payment == null)
                return NotFound(new { message = "Payment not found" });

            return Ok(payment);
        }

        
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentDTO paymentDTO)
        {
            var payment = new Payment
            {
                BookingId = paymentDTO.BookingId,
                Amount = paymentDTO.Amount,
                PaymentMethod = paymentDTO.PaymentMethod,
                PaymentDate = paymentDTO.PaymentDate,
                IsSuccessful = paymentDTO.IsSuccessful
            };

            await _paymentRepository.AddPaymentAsync(payment);
            return CreatedAtAction(nameof(GetPaymentById), new { id = payment.Id }, payment);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id, [FromBody] PaymentDTO paymentDTO)
        {
            var payment = await _paymentRepository.GetPaymentByIdAsync(id);
            if (payment == null)
                return NotFound(new { message = "Payment not found" });

            payment.BookingId = paymentDTO.BookingId;
            payment.Amount = paymentDTO.Amount;
            payment.PaymentMethod = paymentDTO.PaymentMethod;
            payment.PaymentDate = paymentDTO.PaymentDate;
            payment.IsSuccessful = paymentDTO.IsSuccessful;

            await _paymentRepository.UpdatePaymentAsync(payment);
            return Ok(new { message = "Payment updated successfully" });
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var payment = await _paymentRepository.GetPaymentByIdAsync(id);
            if (payment == null)
                return NotFound(new { message = "Payment not found" });

            await _paymentRepository.DeletePaymentAsync(id);
            return Ok(new { message = "Payment deleted successfully" });
        }
    }
}
