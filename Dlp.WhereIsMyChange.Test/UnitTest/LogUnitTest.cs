using Dlp.WhereIsMyChange.Core.Log;
using Dlp.WhereIsMyChange.Core.Utility;
using Dlp.Framework.Container;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dlp.WhereIsMyChange.Test.Mock;

namespace Dlp.WhereIsMyChange.Test.UnitTest {

    [TestClass]
    public class LogUnitTest {

        [TestInitialize]
        public void Initialize() {
            IocFactory.Register(Component.For<IConfigurationUtility>().ImplementedBy<ConfigurationUtilityMock>());
        }

        [TestMethod]
        public void TestFileLog() {

            ILog log = FileLog.GetInstance();

            log.Save(DateTime.UtcNow.ToString("ddMMyyyy"), Core.Enums.LogTypeEnum.Information);         
        }


        [TestMethod]
        public void TestStatic() {

            PrivateType privateType = new PrivateType(typeof(FileLog));

            object result = privateType.InvokeStatic("GetInstance");

            FileLog log = result as FileLog;

            Assert.IsTrue(log.GetType() == typeof(FileLog));            

        }

    }
}
