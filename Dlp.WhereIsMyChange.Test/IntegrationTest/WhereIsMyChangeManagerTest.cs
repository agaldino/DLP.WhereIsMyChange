using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dlp.WhereIsMyChange.Core;
using Dlp.WhereIsMyChange.Core.DataContract;

namespace Dlp.WhereIsMyChange.Test.IntegrationTest {
    [TestClass]
    public class WhereIsMyChangeManagerTest {
        [TestMethod]
        public void CalculateChange_Success() {
            WhereIsMyChangeManager whereIsMyChangeManager = new WhereIsMyChangeManager(new Mock.ConfigurationUtility());
            ChangeRequest changeRequest = new ChangeRequest();
            changeRequest.PaidAmount = 200;
            changeRequest.ProductAmount = 150;
            ChangeResponse response = whereIsMyChangeManager.CalculateChange(changeRequest);
            Assert.IsNotNull(response);
            Assert.AreEqual(50, response.ChangeAmount);
            Assert.IsNull(response.OperationReportList);
            Assert.IsNotNull(response.ChangeList);
            Assert.IsTrue(response.ChangeList.Any());
            Assert.IsNotNull(response.ChangeList.First(x => x.Key == 50 && x.Value == 1));
        }

        [TestMethod]
        public void CalculateChange_NegativeValuesError() {
            WhereIsMyChangeManager whereIsMyChangeManager = new WhereIsMyChangeManager(new Mock.ConfigurationUtility());
            ChangeRequest changeRequest = new ChangeRequest();
            changeRequest.PaidAmount = -200;
            changeRequest.ProductAmount = -150;
            ChangeResponse response = whereIsMyChangeManager.CalculateChange(changeRequest);
            Assert.IsNotNull(response);
            Assert.IsNull(response.ChangeAmount);
            Assert.IsTrue(response.OperationReportList.Any());
            Assert.IsNull(response.ChangeList);
            Assert.IsTrue(response.OperationReportList.Count(x => x.Field.Equals("ChangeRequest.PaidAmount")) == 2);
            Assert.IsNotNull(response.OperationReportList.First(x => x.Field.Equals("ChangeRequest.ProductAmount")));
        }
    }
}
