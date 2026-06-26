public class TopDishDto {
    public string Name { get; set; } = string.Empty;
    public List<TopDishDto> TopDishes { get; set; } = new();
}