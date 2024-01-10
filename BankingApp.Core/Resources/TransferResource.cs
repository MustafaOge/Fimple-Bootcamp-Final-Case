using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Core.Resources
{
    public sealed record TransferResource(Guid SenderAccount, Guid ReceiverAccount, Decimal Amount);
}
