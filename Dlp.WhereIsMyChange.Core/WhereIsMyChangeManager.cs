using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dlp.WhereIsMyChange.Core.DataContract;
using Dlp.WhereIsMyChange.Core.Processors;
using Dlp.WhereIsMyChange.Core.Log;
using Dlp.WhereIsMyChange.Core.Utility;

namespace Dlp.WhereIsMyChange.Core {
    public class WhereIsMyChangeManager : IWhereIsMyChangeManager {

        IConfigurationUtility ConfigurationUtility;

        AbstractLog Log;

        public WhereIsMyChangeManager() {
            this.ConfigurationUtility = new ConfigurationUtility();
            this.Log = FileLog.GetInstance(ConfigurationUtility);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="changeRequest"></param>
        /// <returns></returns>
        public ChangeResponse CalculateChange(ChangeRequest changeRequest) {
            this.Log.Log(changeRequest, "Request");

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
                this.Log.Log(exception, "Exception");

                OperationReport operationReport = new OperationReport();
                operationReport.Field = "System Error";
                operationReport.Message = exception.Message;
                changeResponse.OperationReportList.Add(operationReport);
            }
            // TODO: Log
            this.Log.Log(changeResponse, "Response");
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
