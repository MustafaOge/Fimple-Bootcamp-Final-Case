using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Core.Entities
{
    public class Transfer
    {
        public Guid SenderAccount {  get; set; }
        public Guid ReceiverAccount { get; set; }
        public Decimal Amount { get; set; }


    }
}
