using CodeChallenge.Models;

using System;
using System.Threading.Tasks;

namespace CodeChallenge.Services
{
    public interface ICompensationService
    {
        Compensation GetById(String id);
        Task<Compensation> Create(Compensation compensation);
      
    }
}
