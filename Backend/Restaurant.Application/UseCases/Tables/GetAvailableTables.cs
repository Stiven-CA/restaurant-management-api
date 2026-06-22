using Restaurant.Domain.Repositories;
using Restaurant.Domain.Entities;
using Restaurant.Application.DTOs.Table;

namespace Restaurant.Application.UseCases.Tables;

public class GetAvailableTables{
    private readonly ITableRepository _tableRepository;

    public GetAvailableTables(ITableRepository tableRepository){
        _tableRepository = tableRepository;
    }


    public async Task<List<TableResponseDto>> ExecuteAsync(int capacity)
    {
        var  tables = await _tableRepository.GetAvailable(capacity);
        if(!tables.Any())
            throw new ArgumentException("No hay mesas disponibles");

        return tables.Select(t => new TableResponseDto
        {
            Number = t.Number,
            Capacity = t.Capacity,
            Status = t.Status.ToString()
        }).ToList();
    }
}   