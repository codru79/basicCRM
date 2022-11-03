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
            dbobject.Idcustomer = model.Idcustomer;
            dbobject.Name=model.Name;
            dbobject.Adress=model.Adress;
            dbobject.AddedDate=model.AddedDate;
            return dbobject;
        }

        public CustomerModel MapDBObjectToModel(Customer dbobject)
        {
            var model = new CustomerModel();
            model.Idcustomer = dbobject.Idcustomer;
            model.Name = dbobject.Name;
            model.Adress = dbobject.Adress;
            model.AddedDate = dbobject.AddedDate;
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
            }
        }

        public void DeleteCustomer(CustomerModel model)
        {
            var dbobject = _DBContext.Customers.FirstOrDefault(x => x.Idcustomer == model.Idcustomer);
            _DBContext.Customers.Remove(dbobject);
            _DBContext.SaveChanges();
        }

    }
}
