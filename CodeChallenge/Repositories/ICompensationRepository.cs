using CodeChallenge.Models;

using System.Threading.Tasks;

namespace CodeChallenge.Repositories
{
    public interface ICompensationRepository
    {
        Compensation GetById(string employeeId);

        Compensation Create(Compensation compensation);
        Task SaveAsync();
    }
}
