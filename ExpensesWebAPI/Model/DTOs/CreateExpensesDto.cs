namespace ExpensesWebAPI.Model.DTOs
{
    public class CreateExpensesDto
    {
        public string Title { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}
