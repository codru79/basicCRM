using basicCRM.Data;
using basicCRM.Models;
using basicCRM.Models.DBObjects;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace basicCRM.Repository
{
    public class ContactPersonRepository
    {
        private readonly ApplicationDbContext _DBContext;

        public ContactPersonRepository()
        { 
        _DBContext = new ApplicationDbContext();
        }

        public ContactPersonRepository(ApplicationDbContext _dbContext)
        { 
        _DBContext= _dbContext;
        }

        public ContactPerson MapModelToDBObject(ContactPersonModel model)
        { 
            var dbobject = new ContactPerson();
            if (model != null)
            {
                dbobject.IdcontactPerson = model.IdcontactPerson;
                dbobject.Name = model.Name;
                dbobject.Email = model.Email;
                dbobject.Phone = model.Phone;
                dbobject.Idcustomer = model.Idcustomer;
            }
            return dbobject;
        }


        public ContactPersonModel MapDBObjectToModel(ContactPerson dbobject)
        {
            var model = new ContactPersonModel();
            if (dbobject != null)
            {
                model.IdcontactPerson = dbobject.IdcontactPerson;
                model.Name = dbobject.Name;
                model.Email = dbobject.Email;
                model.Phone = dbobject.Phone;
                model.Idcustomer = dbobject.Idcustomer;
            }
            return model;
        }

        public List<ContactPersonModel> GetAllContactPersons()
        {
            var list = new List<ContactPersonModel>();
            foreach (var dbobject in _DBContext.ContactPersons)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }

        public ContactPersonModel GetContactPersonById(Guid id)
        {
            return MapDBObjectToModel(_DBContext.ContactPersons.FirstOrDefault(x => x.IdcontactPerson == id));
        }

        public void InsertContactPerson(ContactPersonModel model)
        { 
            model.IdcontactPerson=Guid.NewGuid();
            _DBContext.ContactPersons.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateContactPerson(ContactPersonModel model)
        {
            var dbobject = _DBContext.ContactPersons.FirstOrDefault(x => x.IdcontactPerson == model.IdcontactPerson);
            if (dbobject != null)
            {
                dbobject.IdcontactPerson = model.IdcontactPerson;
                dbobject.Name = model.Name;
                dbobject.Email = model.Email;
                dbobject.Phone = model.Phone;
                dbobject.Idcustomer = model.Idcustomer;
            }
        }

        public void DeleteContactPerson(Guid id)
        {
            var dbobject = _DBContext.ContactPersons.FirstOrDefault(x => x.IdcontactPerson == id);
            _DBContext.ContactPersons.Remove(dbobject);
            _DBContext.SaveChanges();
        }

    }
}
