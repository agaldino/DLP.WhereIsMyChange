using Dlp.Framework.Container;
using Dlp.WhereIsMyChange.Core;
using Dlp.WhereIsMyChange.Core.Enums;
using Dlp.WhereIsMyChange.Core.Log;
using Dlp.WhereIsMyChange.Core.Processors;
using Dlp.WhereIsMyChange.Core.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Test.UnitTest {
    [TestClass]
    public class WhereIsMyChangePrivateTest {
        
        [TestInitialize]
        public void Initialize() {
            IocFactory.Register(Component.For<ILog>().ImplementedBy<WindowsEventLog>(LoggerEnum.WindowsEventLog.ToString()), Component.For<ILog>().ImplementedBy<FileLog>(LoggerEnum.FileLog.ToString()), Component.For<IConfigurationUtility>().ImplementedBy<ConfigurationUtility>(LoggerEnum.WindowsEventLog.ToString()));
        }

        [TestMethod]
        public void TestCalculateChangeList() {

            WhereIsMyChangeManager whereIsMyChangeManager = new WhereIsMyChangeManager();
            PrivateObject privateObject = new PrivateObject(whereIsMyChangeManager);
            object response = privateObject.Invoke("CalculateChangeList", 987654321555666);
             
            List<KeyValuePair<int, long>> calculateChangeList = (List<KeyValuePair<int, long>>)response;

            Assert.IsNotNull(calculateChangeList);
        }
    }
}
