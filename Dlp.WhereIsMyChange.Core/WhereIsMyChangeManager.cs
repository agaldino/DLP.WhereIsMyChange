using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dlp.WhereIsMyChange.Core.DataContract;
using Dlp.WhereIsMyChange.Core.Processors;
using Dlp.WhereIsMyChange.Core.Log;
using Dlp.WhereIsMyChange.Core.Utility;
using Dlp.WhereIsMyChange.Core.Enums;
using Dlp.Framework.Container;

namespace Dlp.WhereIsMyChange.Core {

    public class WhereIsMyChangeManager : IWhereIsMyChangeManager {

        private ILog Log { get; set; }

        public WhereIsMyChangeManager() {

            IocFactory.Register(
                Component.For<IConfigurationUtility>().ImplementedBy<ConfigurationUtility>(),
                Component.For<ILog>().ImplementedBy<FileLog>(LoggerEnum.FileLog.ToString()),
                Component.For<ILog>().ImplementedBy<WindowsEventLog>(LoggerEnum.WindowsEventLog.ToString())
                );

            this.Log = LogFactory.Create(LoggerEnum.WindowsEventLog);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="changeRequest"></param>
        /// <returns></returns>
        public ChangeResponse CalculateChange(ChangeRequest changeRequest) {
            this.Log.Save(changeRequest, LogTypeEnum.Information);

            ChangeResponse changeResponse = new ChangeResponse();

            try {

                if (changeRequest.IsValid == false) {
                    changeResponse.OperationReportList = changeRequest.OperationReportList;
                    return changeResponse;
                }
                changeResponse.ChangeAmount = changeRequest.PaidAmount - changeRequest.ProductAmount;

                changeResponse.ChangeList = this.CalculateChangeList(changeResponse.ChangeAmount.Value);

            } catch (Exception exception) {
                // TODO: Log
                ILog exLog = LogFactory.Create(LoggerEnum.WindowsEventLog);
                exLog.Save(exception.Message, LogTypeEnum.Exception);

                OperationReport operationReport = new OperationReport();
                operationReport.Field = "System Error";
                operationReport.Message = exception.Message;
                changeResponse.OperationReportList = new List<OperationReport>();
                changeResponse.OperationReportList.Add(operationReport);
            }
            // TODO: Log
            this.Log.Save(changeResponse, LogTypeEnum.Information);
            return changeResponse;
        }

        private List<KeyValuePair<int, long>> CalculateChangeList(long changeAmount) {

            long remainingChangeAmount = changeAmount;

            List<KeyValuePair<int, long>> changeList = new List<KeyValuePair<int, long>>();

            while (remainingChangeAmount > 0) {

                // Instancia processador necessário para calcular o troco.
                AbstractProcessor abstractProcessor = FactoryProcessor.Create(remainingChangeAmount);
                List<KeyValuePair<int, long>> tempChangeList = abstractProcessor.GenerateChangeList(remainingChangeAmount);

                foreach (KeyValuePair<int, long> change in tempChangeList) {

                    changeList.Add(change);

                    remainingChangeAmount -= (change.Value * change.Key);
                }
            }
            return changeList;
        }
    }
}
