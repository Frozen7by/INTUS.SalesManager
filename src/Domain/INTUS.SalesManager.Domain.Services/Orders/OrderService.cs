﻿using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Models.Orders;
using INTUS.SalesManager.Domain.Services.Extenstions;
using INTUS.SalesManager.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace INTUS.SalesManager.Domain.Services.Orders;

public class OrderService : IOrderService
{
    private readonly IRepository<Order> _orderRepository;

    public OrderService(IRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task<List<OrderListDto>> GetOrders(CancellationToken cancellationToken)
    {
        return _orderRepository.GetQueryable()
            .Select(it => new OrderListDto
            {
                Id = it.Id,
                Name = it.Name,
                State = it.State.ToLookupDto(),
                Windows = it.Windows.Count
            }).ToListAsync(cancellationToken);
    }

    public Task<OrderDto> GetOrder(long id, CancellationToken cancellationToken)
    {
        return _orderRepository.GetQueryable()
            .Where(it => it.Id == id)
            .Select(it => new OrderDto
            {
                Id = it.Id,
                Name = it.Name,
                State = it.State.ToLookupDto(),
                Windows = it.Windows.Select(
                    w => new WindowDto
                    {
                        Id = w.Id,
                        Name = w.Name,
                        Quantity = w.Quantity,
                        SubElements = w.SubElements.Select(
                            se => new SubElementDto
                            {
                                Id = se.Id,
                                ElementType = se.ElementType.ToLookupDto(),
                                Index = se.Index,
                                Width = se.Width,
                                Height = se.Height,
                            }).ToList(),
                    }).ToList()
            })
            .SingleAsync(cancellationToken);
    }
}
