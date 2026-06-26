using Restaurant.Domain.Entities;
using Restaurant.Domain.Enums;
using Restaurant.Domain.Repositories;
using Restaurant.Application.DTOs.SalesReport;

namespace Restaurant.Application.UseCases.SalesReports;

public class SalesReport{

    private readonly IOrderRepository _orderRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly IDishRepository _dishRepository;
    private readonly IUserRepository _userRepository;
    private readonly IOrderDetailRepository _orderDetailRepository;



    public SalesReport(IOrderRepository orderRepository,
                        IReservationRepository reservationRepository,
                        IDishRepository dishRepository,
                        IUserRepository userRepository,
                        IOrderDetailRepository orderDetailRepository){

        _orderRepository = orderRepository;
        _reservationRepository = reservationRepository;
        _dishRepository = dishRepository;
        _userRepository = userRepository;
        _orderDetailRepository = orderDetailRepository;
    }

    public async Task<SalesReportDto> ExecuteAsync(DateTime ReporDate, Guid AdminId)
    {
        var admin = await _userRepository.GetById(AdminId);
        if(admin == null)
            throw new ArgumentException("El usuario no existe");
        if(admin.Role != UserRole.Admin)
            throw new ArgumentException("El usuario no es administrador");
        if(ReporDate > DateTime.Today)
            throw new ArgumentException("La fecha no puede ser futura");

        var orders = await _orderRepository.GetByDate(ReporDate);
        var orderDetails = await _orderDetailRepository.GetByDate(ReporDate);
        decimal total = orderDetails.Sum(od => od.Quantity * od.UnitPrice);
        var reservations = await _reservationRepository.GetReservations(ReporDate);
        int confirmed = reservations.Count(r => r.Status == ReservationStatus.Confirmed);
        int cancelled = reservations.Count(r => r.Status == ReservationStatus.Cancelled);
        int completed = reservations.Count(r => r.Status == ReservationStatus.Completed);


        var dishIds = orderDetails
            .Select(od => od.DishId)
            .Distinct()
            .ToList();

        var dishes = await _dishRepository.GetByIds(dishIds);

        var dishNames = dishes.ToDictionary(d => d.Id, d => d.Name);

        var topDishes = orderDetails
            .GroupBy(od => od.DishId)
            .Select(g => new TopDishDto
            {
                Name = dishNames[g.Key],
                TotalOrdered = g.Sum(od => od.Quantity)
            })
            .OrderByDescending(d => d.TotalOrdered)
            .Take(5)
            .ToList();

        return new SalesReportDto
        {
            TotalSales = total,
            TopDishes = topDishes,
            ConfirmedReservations = confirmed,
            CancelledReservations = cancelled,
            CompletedReservations = completed
        };

    }
}