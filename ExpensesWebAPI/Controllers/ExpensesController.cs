using AutoMapper;
using ExpensesWebAPI.Data;
using ExpensesWebAPI.Model;
using ExpensesWebAPI.Model.DTOs;
using ExpensesWebAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection.Metadata;

namespace ExpensesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        protected Response _response;
        private readonly IExpensesRepository _expensesRepo;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public ExpensesController(IExpensesRepository expenses, IMapper mapper, ApplicationDbContext db)
        {
            _expensesRepo = expenses;
            _mapper = mapper;
            _dbContext = db;
            this._response = new();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expense>>> GetAllExpenses()
        {
            IEnumerable<Expense> expenseList = await _expensesRepo.GetAllExpenseAsync();
            var expensesDtoList = _mapper.Map<List<ExpensesDto>>(expenseList);

            return Ok(expensesDtoList);
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<Expense>>> GetExpensesById(int id)
        {
            if (id != 0)
            {
                var getExpenses = await _expensesRepo.GetExpenseByIdAsync(id);
                if (getExpenses != null)
                {
                    var expensesDto = _mapper.Map<ExpensesDto>(getExpenses);

                    return Ok(expensesDto);
                }
                return NotFound();
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<Response>> CreateNewExpense([FromBody] CreateExpensesDto createExpense)
        {
            
            var expense = _mapper.Map<Expense>(createExpense);

            _response.Result = _mapper.Map<CreateExpensesDto>(createExpense);
            _response.StatusCode = HttpStatusCode.Created;

            await _expensesRepo.CreateAsync(expense);

            return Ok(_response);
        }

        [HttpPut("id")]
        public async Task<ActionResult<IEnumerable<Expense>>> UpdateExpenses(int id, [FromBody]CreateExpensesDto expenseDto)
        {
            if (expenseDto != null || id != 0)
            {
                var isUpdated = await _expensesRepo.UpdateAsync(id, expenseDto);
                if (isUpdated)
                {
                    return NoContent();
                }

                return NotFound();
            }
            return BadRequest();
        }

        [HttpDelete("id")]
        public async Task<ActionResult<IEnumerable<Expense>>> DeleteExpenses(int id)
        {
            if (id != 0)
            {
                var isDeleted = await _expensesRepo.DeleteAsync(id);
                if (isDeleted)
                {
                    return NoContent();
                }
            }
            return BadRequest();
        }

    }
}
