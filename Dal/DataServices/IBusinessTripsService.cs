using System.Collections.Generic;
using Dal.DataModel;

namespace Dal.DataServices
{
    public interface IBusinessTripsService
    {
        void AddBusinessTrip(BusinessTrip trip, IEnumerable<int> participants);
    }
}
