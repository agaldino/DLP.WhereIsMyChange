using Dlp.WhereIsMyChange.Core.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Core {
    public interface IWhereIsMyChangeManager {
        ChangeResponse CalculateChange(ChangeRequest changeRequest);
    }
}
