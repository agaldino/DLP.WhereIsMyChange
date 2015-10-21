using Dlp.WhereIsMyChange.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Test.Mock {
    public class ConfigurationUtility : IConfigurationUtility {

        public string LogPath {
            get {
                return @"C:\LogDeTeste\";
            }
        }
    }
}
