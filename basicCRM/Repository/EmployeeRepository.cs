﻿using basicCRM.Data;
using basicCRM.Models;
using basicCRM.Models.DBObjects;

namespace basicCRM.Repository
{
    public class EmployeeRepository
    {
        private readonly ApplicationDbContext _DBContext;

        public EmployeeRepository()
        { 
        _DBContext=new ApplicationDbContext();
        }

        public EmployeeRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }

        public EmployeeModel MapDBObjectToModel(Employee dbobject)
        { 
        var model = new EmployeeModel();
            model.Idemployee = dbobject.Idemployee;
            model.Name = dbobject.Name;
            model.Email = dbobject.Email;
            model.Department = dbobject.Department;
            model.IduserLogin = dbobject.IduserLogin;
            model.Idrole = dbobject.Idrole;
            return model;
        }
        public Employee MapModelToDBObject(EmployeeModel model)
        { 
        var dbobject = new Employee();
            dbobject.Idemployee=model.Idemployee;
            dbobject.Name=model.Name;
            dbobject.Email = model.Email;
            dbobject.Department = model.Department;
            dbobject.IduserLogin = model.IduserLogin;
            dbobject.Idrole = model.Idrole;
            return dbobject;
        }

        public List<EmployeeModel> GetAllEmployees()
        { 
        var list = new List<EmployeeModel>();
            foreach (var dbobject in _DBContext.Employees)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }

        public EmployeeModel GetEmployeeById(Guid id)
        {
            return MapDBObjectToModel(_DBContext.Employees.FirstOrDefault(x => x.Idemployee == id));
        }

        public void InsertEmployee(EmployeeModel model)
        {
            model.Idemployee=Guid.NewGuid();
            _DBContext.Employees.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateEmployee(EmployeeModel model)
        {
            var dbobject = _DBContext.Employees.FirstOrDefault(x => x.Idemployee == model.Idemployee);
            if (dbobject != null)
            {
                dbobject.Idemployee = model.Idemployee;
                dbobject.Name = model.Name;
                dbobject.Email = model.Email;
                dbobject.Department = model.Department;
                dbobject.IduserLogin = model.IduserLogin;
                dbobject.Idrole = model.Idrole;
            }
        }

        public void DeleteEmployee(EmployeeModel model)
        {
            var dbobject = _DBContext.Employees.FirstOrDefault(x => x.Idemployee == model.Idemployee);
            _DBContext.Employees.Remove(dbobject);
            _DBContext.SaveChanges();
        }
    }
}

