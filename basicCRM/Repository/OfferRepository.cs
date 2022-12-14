using basicCRM.Data;
using basicCRM.Models;
using basicCRM.Models.DBObjects;

namespace basicCRM.Repository
{
    public class OfferRepository
    {
        private readonly ApplicationDbContext _DBContext;

        public OfferRepository()
        { 
        _DBContext = new ApplicationDbContext();
        }

        public OfferRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }

        public OfferModel MapDBObjectToModel(Offer dbobject)
        { 
            var model = new OfferModel();
            if (dbobject != null)
            {
                model.Idoffer = dbobject.Idoffer;
                model.Idopportunity = dbobject.Idopportunity;
                model.Idowner = dbobject.Idowner;
                model.OfferType = dbobject.OfferType;
                model.CreatedDate = dbobject.CreatedDate;
                model.ExpireDate = dbobject.ExpireDate;
                model.ValueMwh = dbobject.ValueMwh;
            }
            return model;
        }

        public Offer MapModelToDBObject(OfferModel model)
        { 
            var dbobject = new Offer();
            if (model != null)
            {
                dbobject.Idoffer = model.Idoffer;
                dbobject.Idopportunity = model.Idopportunity;
                dbobject.Idowner = model.Idowner;
                dbobject.OfferType = model.OfferType;
                dbobject.CreatedDate = model.CreatedDate;
                dbobject.ExpireDate = model.ExpireDate;
                dbobject.ValueMwh = model.ValueMwh;
            }
            return dbobject;
        }

        public List<OfferModel> GetAllOffers()
        {
            var list = new List<OfferModel>();
            foreach (var dbobject in _DBContext.Offers)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }

        public List<OfferModel> GetAllOffersFilteredBy(string searchString)
        {
            var list = new List<OfferModel>();
            foreach (var dbobject in _DBContext.Offers.Where(x => x.OfferType.Contains(searchString)))
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }

        public OfferModel GetOfferById(Guid id)
        {
            return MapDBObjectToModel(_DBContext.Offers.FirstOrDefault(x => x.Idoffer == id));
        }

        public void InsertOffer(OfferModel model)
        { 
            model.Idoffer= Guid.NewGuid();
            model.CreatedDate=DateTime.Now;
            _DBContext.Offers.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateOffer(OfferModel model)
        {
            var dbobject = _DBContext.Offers.FirstOrDefault(x => x.Idoffer == model.Idoffer);
            if (dbobject != null)
            {
                dbobject.Idoffer = model.Idoffer;
                dbobject.Idopportunity = model.Idopportunity;
                dbobject.Idowner = model.Idowner;
                dbobject.OfferType = model.OfferType;
                dbobject.CreatedDate = model.CreatedDate;
                dbobject.ExpireDate = model.ExpireDate;
                dbobject.ValueMwh = model.ValueMwh;
                _DBContext.SaveChanges();
            }
        }
        public void DeleteOffer(Guid id)
        {
            var dbobject = _DBContext.Offers.FirstOrDefault(x => x.Idoffer == id);
            _DBContext.Offers.Remove(dbobject);
            _DBContext.SaveChanges();
        }
    }
}
