using basicCRM.Data;
using basicCRM.Models;
using basicCRM.Models.DBObjects;

namespace basicCRM.Repository
{
    public class CustomerRepository
    {
        private readonly ApplicationDbContext _DBContext;

        public CustomerRepository()
        { 
        _DBContext=new ApplicationDbContext();
        }

        public CustomerRepository(ApplicationDbContext _dbContext)
        { 
        _DBContext=_dbContext;
        }

        public Customer MapModelToDBObject(CustomerModel model)
        {
            var dbobject = new Customer();
            if (model != null)
            {
                dbobject.Idcustomer = model.Idcustomer;
                dbobject.Name = model.Name;
                dbobject.Adress = model.Adress;
                dbobject.AddedDate = model.AddedDate;
                dbobject.CreatedBy=model.CreatedBy;
            }
            return dbobject;
        }

        public CustomerModel MapDBObjectToModel(Customer dbobject)
        {
            var model = new CustomerModel();
            if (dbobject != null)
            {
                model.Idcustomer = dbobject.Idcustomer;
                model.Name = dbobject.Name;
                model.Adress = dbobject.Adress;
                model.AddedDate = dbobject.AddedDate;
                model.CreatedBy = dbobject.CreatedBy;   
            }
            return model;
        }

        public List<CustomerModel> GetAllCustomers()
        {
            var list = new List<CustomerModel>();
            foreach (var dbobject in _DBContext.Customers)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }

        public List<CustomerModel> GetAllCustomersFilteredBy(string searchString)
        {
            var list = new List<CustomerModel>();
            foreach (var dbobject in _DBContext.Customers.Where(x => x.Name.Contains(searchString) || x.Adress.Contains(searchString)))
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }

        public CustomerModel GetCustomerById(Guid id)
        {
            return MapDBObjectToModel(_DBContext.Customers.FirstOrDefault(x => x.Idcustomer == id));
        }

        public void InsertCustomer(CustomerModel model)
        { 
            model.Idcustomer=Guid.NewGuid();
            model.AddedDate= DateTime.Now;  
            _DBContext.Customers.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateCustomer(CustomerModel model)
        { 
            var dbobject=_DBContext.Customers.FirstOrDefault(x => x.Idcustomer == model.Idcustomer);
            if (dbobject != null)
            {
                dbobject.Idcustomer = model.Idcustomer;
                dbobject.Name = model.Name;
                dbobject.Adress = model.Adress;
                dbobject.AddedDate = model.AddedDate;
                dbobject.CreatedBy = model.CreatedBy;
                _DBContext.SaveChanges();
            }
        }

        public void DeleteCustomer(Guid id)
        {
            var dbobject = _DBContext.Customers.FirstOrDefault(x => x.Idcustomer == id);
            _DBContext.Customers.Remove(dbobject);
            _DBContext.SaveChanges();
        }

    }
}
