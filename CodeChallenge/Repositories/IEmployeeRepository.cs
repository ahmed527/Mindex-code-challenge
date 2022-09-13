﻿using CodeChallenge.Models;
using CodeChallenge.ViewModels;

using System;
using System.Threading.Tasks;

namespace CodeChallenge.Repositories
{
    public interface IEmployeeRepository
    {
        Employee GetById(String id);
        Employee Add(Employee employee);
        Employee Remove(Employee employee);
        Task SaveAsync();
        ReportingStructure GetReportingStructureByEmployeeId(String id);
    }
}