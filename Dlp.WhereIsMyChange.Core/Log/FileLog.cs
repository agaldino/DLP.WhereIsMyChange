using Dlp.Framework.Container;
using Dlp.WhereIsMyChange.Core.Enums;
using Dlp.WhereIsMyChange.Core.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Core.Log {

    public class FileLog : AbstractLog, ILog {

        private static FileLog _FileLog;

        private IConfigurationUtility ConfigurationUtility { get; set; }

        private FileLog() {
            this.ConfigurationUtility = IocFactory.Resolve<IConfigurationUtility>();
        }

        public static FileLog GetInstance() {
            if (_FileLog == null) {
                _FileLog = new FileLog();
            }
            return _FileLog;
        }

        protected override void Log(object logData, LogTypeEnum logType) {

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

        public void Save(object logData, LogTypeEnum logType) {
            this.Log(logData, logType);
        }
    }
}
