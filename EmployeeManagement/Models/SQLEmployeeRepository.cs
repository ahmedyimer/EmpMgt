﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {

        //private readonly AppDbContext context;

        //public SQLEmployeeRepository(AppDbContext context)
        //{
        //    this.context = context;
        //}


        //public Employee Add(Employee employee)
        //{
        //    context.Employees.Add(employee);
        //    context.SaveChanges();
        //    return employee;

        //}

        //public Employee Delete(int Id)
        //{
        //    Employee employee = context.Employees.Find(Id);
        //    if (employee != null)
        //    {
        //        context.Employees.Remove(employee);
        //        context.SaveChanges();
        //    }
        //    return employee;

        //}

        //public IEnumerable<Employee> GetAllEmployees()
        //{
        //    return context.Employees;
        //}

        //public Employee GetEmployee(int id)
        //{
        //    return context.Employees.Find(id);
        //}

        //public Employee Update(Employee employeeChanges)
        //{
        //    var employee = context.Employees.Attach(employeeChanges);
        //    employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //    context.SaveChanges();
        //    return employeeChanges;
        //}
        public Employee Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee employeeChanges)
        {
            throw new NotImplementedException();
        }
    }
}