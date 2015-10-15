using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dlp.WhereIsMyChange.Core.DataContract;
using Dlp.WhereIsMyChange.Core.Processors;

namespace Dlp.WhereIsMyChange.Core
{
    public class WhereIsMyChangeManager : IWhereIsMyChangeManager
    {
        public ChangeResponse CalculateChange(ChangeRequest changeRequest) {

            AbstractProcessor coinProcessor = new CoinProcessor();

            return coinProcessor.CalculateChange(changeRequest);
        }
    }
}
