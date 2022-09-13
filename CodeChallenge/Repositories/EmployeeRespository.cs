using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CodeChallenge.Data;
using CodeChallenge.ViewModels;

namespace CodeChallenge.Repositories
{
    public class EmployeeRespository : IEmployeeRepository
    {
        private readonly EmployeeContext _employeeContext;
        private readonly ILogger<IEmployeeRepository> _logger;

        public EmployeeRespository(ILogger<IEmployeeRepository> logger, EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
            _logger = logger;
        }

        public Employee Add(Employee employee)
        {
            employee.EmployeeId = Guid.NewGuid().ToString();
            _employeeContext.Employees.Add(employee);
            return employee;
        }

        public Employee GetById(string id)
        {
            return _employeeContext.Employees.SingleOrDefault(e => e.EmployeeId == id);
        }

        public Task SaveAsync()
        {
            return _employeeContext.SaveChangesAsync();
        }

        public Employee Remove(Employee employee)
        {
            return _employeeContext.Remove(employee).Entity;
        }

        public ReportingStructure GetReportingStructureByEmployeeId(string id)
        {
          var employee=  _employeeContext.Employees.Include(e=>e.DirectReports).SingleOrDefault(e => e.EmployeeId == id);
            var reportsCount = GetEmployeeReportsCount(employee);
            employee.DirectReports = null;
            return new ReportingStructure() { employee=employee,numberOfReports=reportsCount};
        }

        private int GetEmployeeReportsCount(Employee employee)
        {
            var reports = employee.DirectReports;

            if (reports is null || ! reports.Any())
            {
                return 0;
            }

            var reportsCount = reports.Count();

            foreach(var report in reports)
            {
                var emp = _employeeContext.Employees.Include(e => e.DirectReports).SingleOrDefault(e => e.EmployeeId == report.EmployeeId);
                reportsCount += GetEmployeeReportsCount(emp);
            }

            return reportsCount; 
        }
    }
}
