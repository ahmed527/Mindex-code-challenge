using CodeChallenge.Models;
using CodeChallenge.Repositories;

using Microsoft.Extensions.Logging;

using System;
using System.Threading.Tasks;

namespace CodeChallenge.Services
{
    public class CompensationService : ICompensationService
    {
        private readonly ILogger<CompensationService> _logger;
        private readonly ICompensationRepository _compensationRepository;

        public CompensationService(ILogger<CompensationService> logger, ICompensationRepository compensationRepository)
        {
            this._logger = logger;
            this._compensationRepository = compensationRepository;
        }

        public Compensation GetById(string employeeId)
        {
            if (!String.IsNullOrEmpty(employeeId))
            {
                return _compensationRepository.GetById(employeeId);
            }
            return null;
        }

        public async Task<Compensation> Create(Compensation compensation)
        {
            if (compensation != null)
            {
                _compensationRepository.Create(compensation);
                await _compensationRepository.SaveAsync();
            }

            return compensation;
        }


    }
}
