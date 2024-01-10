using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Core.UnitOfWorks
{
    /// <summary>
    /// Interface for the unit of work pattern, providing methods for committing changes and handling transactions.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Asynchronously commits changes to the underlying data store.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task CommitChangesAsync();

        /// <summary>
        /// Commits changes to the underlying data store.
        /// </summary>
        void CommitChanges();

        /// <summary>
        /// Asynchronously begins a new transaction.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task BeginTransactionAsync();

        /// <summary>
        /// Asynchronously commits the current transaction.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task TransactionCommitAsync();
    }

}
