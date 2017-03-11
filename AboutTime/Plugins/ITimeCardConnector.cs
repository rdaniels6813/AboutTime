using AboutTime.Interfaces;
using System.Collections.Generic;

namespace AboutTime.Plugins
{
    public interface ITimeCardConnector
    {
        IEnumerable<ITimeCard> GetTimeCards();
        void SaveTimeCard(ITimeCard card);
    }
}