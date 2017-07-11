using Datamodel;

namespace DataAccessLayer
{
    /// <summary>
    /// ICrosswayDataAccess
    /// </summary>
    public interface ICrosswayDataAccess : IDataAccess<Crossway> { }

    class CrosswayDataAccess : AbstractDataAccess<Crossway>, ICrosswayDataAccess
    {
    }
}
