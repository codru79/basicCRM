using basicCRM.Data;
using basicCRM.Models;
using basicCRM.Models.DBObjects;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace basicCRM.Repository
{
    public class OpportunityRepository
    {
        private readonly ApplicationDbContext _DBContext;


        public OpportunityRepository()
        {
            _DBContext = new ApplicationDbContext();

        }

        public OpportunityRepository(ApplicationDbContext dbContext)
        { 
        _DBContext= dbContext;
        }

        private OpportunityModel MapDBObjectToModel(Opportunity dbobject)
        { 
        var model = new OpportunityModel();
            if (dbobject != null)
            { 
                model.Idopportunity = dbobject.Idopportunity;
                model.Name=dbobject.Name;
                model.Idcustomer=dbobject.Idcustomer;
                model.CommodityType = dbobject.CommodityType;
                model.Idemployee = dbobject.Idemployee;
                model.ValidFrom = dbobject.ValidFrom;
                model.ValidTo = dbobject.ValidTo;
                model.Status = dbobject.Status;
            }
            return model;
        }

        private Opportunity MapModelToDBObject(OpportunityModel model)
        {
            var dbobject = new Opportunity();
            if (model != null)
            {
                dbobject.Idopportunity = model.Idopportunity;
                dbobject.Name = model.Name;
                dbobject.Idcustomer = model.Idcustomer;
                dbobject.CommodityType = model.CommodityType;
                dbobject.Idemployee = model.Idemployee;
                dbobject.ValidFrom = model.ValidFrom;
                dbobject.ValidTo = model.ValidTo;
                dbobject.Status = model.Status;
            }
            return dbobject;
        }

        public List<OpportunityModel> GetAllOpportunities()
        { 
        var list = new List<OpportunityModel>();
            foreach (var dbobject in _DBContext.Opportunities)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }


        public List<OpportunityModel> GetAllOpportunitiesSortedBy(string searchString)
        {
            var list = new List<OpportunityModel>();
            foreach (var dbobject in _DBContext.Opportunities.Where(x => x.Name.Contains(searchString)))
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }

        public OpportunityModel GetOpportunityByID(Guid id)
        {
            return MapDBObjectToModel(_DBContext.Opportunities.FirstOrDefault(x => x.Idopportunity == id));
        }

        public void InsertOpportunity(OpportunityModel model)
        { 
            model.Idopportunity= Guid.NewGuid();
            _DBContext.Opportunities.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();

        }

        public void UpdateOpportunity(OpportunityModel model)
        {
            var dbobject = _DBContext.Opportunities.FirstOrDefault(x => x.Idopportunity == model.Idopportunity);
            if (dbobject != null)
            {
                dbobject.Idopportunity = model.Idopportunity;
                dbobject.Name = model.Name;
                dbobject.Idcustomer = model.Idcustomer;
                dbobject.CommodityType = model.CommodityType;
                dbobject.Idemployee = model.Idemployee;
                dbobject.ValidFrom = model.ValidFrom;
                dbobject.ValidTo = model.ValidTo;
                dbobject.Status = model.Status;
                _DBContext.SaveChanges();

            }
        }

        public void DeleteOpportunity(Guid id)
        {
            var dbobject = _DBContext.Opportunities.FirstOrDefault(x => x.Idopportunity == id);
            if (dbobject != null)
            {
                _DBContext.Opportunities.Remove(dbobject);
                _DBContext.SaveChanges();
            }
        }
    }
}
