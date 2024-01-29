namespace ExpensesWebAPI.Model.DTOs
{
    public class ExpensesDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Amount { get; set; } 
        public DateTime Date { get; set; }
        public string Type { get; set; }
    }
}
