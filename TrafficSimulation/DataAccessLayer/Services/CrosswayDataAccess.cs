using Datamodel;

namespace DataAccessLayer
{
    public interface ICrosswayDataAccess : IDataAccess<Crossway> { }

    class CrosswayDataAccess : AbstractDataAccess<Crossway>, ICrosswayDataAccess
    {
    }
}
