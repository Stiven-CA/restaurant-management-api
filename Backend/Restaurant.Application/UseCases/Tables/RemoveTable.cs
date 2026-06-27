using Restaurant.Domain.Repositories;
using Restaurant.Domain.Entities;
using Restaurant.Application.DTOs.Table;

namespace Restaurant.Application.UseCases.Tables;

public class RemoveTable{

    private  readonly ITableRepository _tableRepository;

    public  RemoveTable(ITableRepository tableRepository){
        _tableRepository = tableRepository;
    }

    public async Task<TableResponseDto> ExecuteAsync(Guid id)
    {
        var table = await _tableRepository.GetById(id);
        if(table == null)
            throw new ArgumentException("La Mesa no existe");


        await _tableRepository.Delete(id);

        return new TableResponseDto
        {
            Number = table.Number,
            Capacity = table.Capacity,
            Status = table.Status.ToString()
        };
    }
}