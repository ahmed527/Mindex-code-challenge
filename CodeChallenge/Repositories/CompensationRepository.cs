using CodeChallenge.Data;
using CodeChallenge.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Repositories
{
    public class CompensationRepository : ICompensationRepository
    {
        private readonly ILogger<IEmployeeRepository> _logger;
        private readonly EmployeeContext _employeeContext;

        public CompensationRepository(ILogger<IEmployeeRepository> logger, EmployeeContext employeeContext)
        {
            this._logger = logger;
            this._employeeContext = employeeContext;
        }

        public Compensation Create(Compensation compensation)
        {
            _employeeContext.Compensations.Add(compensation);
            return compensation;
        }

        public Compensation GetById(string employeeId)
        {
            return _employeeContext.Compensations.Include(c => c.Employee).FirstOrDefault(c => c.Employee.EmployeeId == employeeId);
        }

        public Task SaveAsync()
        {
            return _employeeContext.SaveChangesAsync();
        }

    }
}
