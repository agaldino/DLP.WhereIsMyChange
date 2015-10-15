using Dlp.WhereIsMyChange.Core.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Core.Processors {

    public abstract class AbstractProcessor {

        public AbstractProcessor() { }

        internal List<KeyValuePair<int, long>> GenerateChangeList(long changeAmount) {

            List<KeyValuePair<int, long>> changeList = new List<KeyValuePair<int, long>>();

            long availableAmount = changeAmount;

            foreach (int changeValue in this.GetAvailableChange().OrderByDescending(x => x)) {
                if (availableAmount < changeValue) {
                    continue;
                }

                long amountCount = availableAmount / changeValue;
                availableAmount = availableAmount - (amountCount * changeValue);

                changeList.Add(new KeyValuePair<int, long>(changeValue, amountCount));
            }

            return changeList;
        }

        internal abstract List<int> GetAvailableChange();
    }
}
