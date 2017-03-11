using AboutTime.Interfaces;
using System;
using System.Collections.Generic;

namespace AboutTime.Plugins
{
    public class JiraConnector : ITimeCardConnector
    {
        public IEnumerable<ITimeCard> GetTimeCards()
        {
            throw new NotImplementedException();
        }

        public void SaveTimeCard(ITimeCard card)
        {
            throw new NotImplementedException();
        }
    }
}
