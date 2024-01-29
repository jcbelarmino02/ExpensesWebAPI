using ExpensesWebAPI.Model;
using ExpensesWebAPI.Model.DTOs;
using System.Reflection.Metadata;

namespace ExpensesWebAPI.Repository.IRepository
{
    public interface IExpensesRepository
    {
        Task<List<Expense>> GetAllExpenseAsync();
        Task<Expense> GetExpenseByIdAsync(int id);
        Task CreateAsync(Expense expense);
        Task<bool> UpdateAsync(int id, CreateExpensesDto expense);
        Task<bool> DeleteAsync(int id);
    }
}
