using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dlp.WhereIsMyChange.Core.Processors {

    public static class FactoryProcessor {

        public static AbstractProcessor Create(long changeAmount) {
            AbstractProcessor abstractProcessor = null;

            // Lista de processadores possiveis.
            List<AbstractProcessor> processorList = new List<AbstractProcessor> {
                new CandyProcessor(),
                new BillProcessor(),
                new CoinProcessor(),
                new SilverProcessor()
            };

            // Ordena lista.
            processorList = processorList.OrderByDescending(x => x.GetAvailableChange().Min()).ToList();

            foreach (AbstractProcessor processor in processorList) {

                if (processor.GetAvailableChange().Min() <= changeAmount) {
                    abstractProcessor = processor;
                    break;
                }
            }            

            return abstractProcessor;
        }
    }
}
