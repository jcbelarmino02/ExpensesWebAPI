using ExpensesWebAPI.Data;
using ExpensesWebAPI.Model;
using ExpensesWebAPI.Model.DTOs;
using ExpensesWebAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ExpensesWebAPI.Repository
{
    public class ExpenseRepository : IExpensesRepository
    {
        private readonly ApplicationDbContext _db;
        public ExpenseRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Expense>> GetAllExpenseAsync()
        {
            return await _db.Expenses.ToListAsync();
        }

        public async Task<Expense?> GetExpenseByIdAsync(int id)
        {
            IQueryable<Expense> query = _db.Expenses;
            if (id != null)
            {
                query = query.Where(y => y.Id == id);
            }
            
            return await query.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Expense expense)
        {
            expense.Date = DateTime.Now;
            await _db.Expenses.AddAsync(expense);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(int id, CreateExpensesDto expense)
        {
            var getExpense = await GetExpenseByIdAsync(id);
            if (getExpense != null)
            {
                getExpense.Title = expense.Title;
                getExpense.Amount = expense.Amount;
                getExpense.Type = expense.Type;

                await _db.SaveChangesAsync();

                return true;
            }

            return false;
            
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var getExpense = await GetExpenseByIdAsync(id);
            if (getExpense != null)
            {
                _db.Expenses.Remove(getExpense);
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
