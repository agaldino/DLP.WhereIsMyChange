using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dlp.WhereIsMyChange.Core.DataContract;

namespace Dlp.WhereIsMyChange.Core
{
    public class WhereIsMyChangeManager : IWhereIsMyChangeManager
    {
        private List<int> ChangeAvailable;

        public WhereIsMyChangeManager() {

            ChangeAvailable = new List<int> { 100, 50, 25, 10, 5 , 1 };           
        }

        
        public ChangeResponse CalculateChange(ChangeRequest changeRequest) {
            // TODO: Log
            ChangeResponse changeResponse = new ChangeResponse();
            try {
                
                if (changeRequest.IsValid == false) {
                    changeResponse.OperationReportList = changeRequest.OperationReportList;
                    return changeResponse;
                }
                changeResponse.ChangeAmount = this.CalculateChangeAmount(changeRequest.PaidAmount, changeRequest.ProductAmount);

                changeResponse.ChangeList = this.GenerateChangeList(changeResponse.ChangeAmount.Value);

            } catch (Exception exception) {
                // TODO: Log

                OperationReport operationReport = new OperationReport();
                operationReport.Field = "System Error";
                operationReport.Message = exception.Message;
                changeResponse.OperationReportList.Add(operationReport);
            }
            // TODO: Log

            return changeResponse;
        }

        private List<KeyValuePair<int, long>> GenerateChangeList(long changeAmount) {

            List<KeyValuePair<int, long>> changeList = new List<KeyValuePair<int, long>>();

            long availableAmount = changeAmount;

            foreach (int changeValue in this.ChangeAvailable) {
                if (availableAmount < changeValue) {
                    continue;
                }

                long amountCount = availableAmount / changeValue;
                availableAmount = availableAmount - (amountCount * changeValue);
                
                changeList.Add(new KeyValuePair<int, long>(changeValue, amountCount));
            }

            return changeList;
        }

        private long CalculateChangeAmount(long paidAmount, long productAmount) {

            return paidAmount - productAmount;
        }
    }
}
