using Dlp.WhereIsMyChange.Core.Enums;
using Dlp.WhereIsMyChange.Core.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Core.Log {
    public class FileLog : AbstractLog {

        private static FileLog _FileLog;

        private FileLog(IConfigurationUtility configurationUtility) {
            this.ConfigurationUtility = configurationUtility;
        }

        public static FileLog GetInstance(IConfigurationUtility configurationUtility) {
            if (_FileLog == null) {
                _FileLog = new FileLog(configurationUtility);
            }
            return _FileLog;
        }

        private IConfigurationUtility ConfigurationUtility;

        public override void Log(object logData, LogTypeEnum logType) {

            string path = Path.GetFullPath(this.ConfigurationUtility.LogPath);
            string fullPath = Path.GetFullPath(path + "WhereIsMyChangeLog.txt");

            if (Directory.Exists(path) == false) {

                Directory.CreateDirectory(path);
            }

            if (File.Exists(fullPath) == false) {

                File.Create(fullPath).Dispose();
            }

            string serializedObject = Dlp.Framework.Serializer.JsonSerialize(logData);

            string content = string.Format("{0} - {1} - {2}{3}", DateTime.UtcNow, logType.ToString(), serializedObject, Environment.NewLine);

            File.AppendAllText(fullPath, content);
        }
    }
}
