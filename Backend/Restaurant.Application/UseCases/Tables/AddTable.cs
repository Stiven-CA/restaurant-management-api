using Restaurant.Domain.Repositories;
using Restaurant.Domain.Entities;
using Restaurant.Application.DTOs.Table;

namespace Restaurant.Application.UseCases.Tables;

public class AddTable{

    private  readonly ITableRepository _tableRepository;

    public  AddTable(ITableRepository tableRepository){
        _tableRepository = tableRepository;
    }

    public async Task<TableResponseDto> ExecuteAsync(CreateTableRequestDto request)
    {
        var table = new Table(
            Guid.NewGuid(),
            request.Number,
            request.Capacity,
            request.Status
        );

        await _tableRepository.Add(table);

        return new TableResponseDto
        {
            Number = table.Number,
            Capacity = table.Capacity,
            Status = table.Status.ToString()
        };
    }
}