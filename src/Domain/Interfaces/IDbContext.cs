// Copyright 2025 Xtracked
// SPDX-License-Identifier: GPL-2.0-only OR Commercial

using System.Data;

namespace FunQL.Playground.Domain.Interfaces;

/// <summary>
/// Interface of a DbContext for interacting with a database, which is usually implemented using
/// <a href="https://github.com/dotnet/efcore">EFCore</a>.
/// </summary>
/// <remarks>Based on how DbContext works in <a href="https://github.com/dotnet/efcore">EFCore</a>.</remarks>
public interface IDbContext
{
    /// <summary>
    /// Executes the <paramref name="operation"/> in a transaction using given <paramref name="isolationLevel"/>.
    ///
    /// This should be used in combination with Connection Resiliency and transactions, as specified
    /// <a href="https://docs.microsoft.com/nl-nl/ef/core/miscellaneous/connection-resiliency">here</a>.
    ///
    /// To not mark any changes as accepted when the transaction has not fully completed, make sure to call
    /// <see cref="SaveChangesAsync(bool,System.Threading.CancellationToken)"/> and pass <c>false</c> to not
    /// automatically accept changes. The changes can then be accepted with <see cref="AcceptAllChanges"/>.
    /// </summary>
    /// <remarks>
    /// The <paramref name="isolationLevel"/> is used for relational databases.
    /// </remarks>
    /// <param name="state">The state that will be passed to the operation.</param>
    /// <param name="operation">A delegate representing an executable operation.</param>
    /// <param name="verifySucceeded">
    /// A delegate that tests whether the operation succeeded even though an exception was thrown when the transaction
    /// was being committed.
    /// </param>
    /// <param name="isolationLevel">The isolation level to use for the transaction.</param>
    /// <param name="cancellationToken">
    /// A cancellation token used to cancel the retry operation, but not operations that are already in flight or that
    /// already completed successfully.
    /// </param>
    /// <typeparam name="TState">Type of the <paramref name="state"/>.</typeparam>
    /// <typeparam name="TResult">Type of the result.</typeparam>
    /// <returns>
    /// A task that will run to completion if the original task completes successfully (either the first time or after
    /// retrying transient failures). If the task fails with a non-transient error or the retry limit is reached, the
    /// returned task will become faulted and the exception must be observed.
    /// </returns>
    public Task<TResult> ExecuteInTransactionAsync<TState, TResult>(
        TState state,
        Func<TState, CancellationToken, Task<TResult>> operation,
        Func<TState, CancellationToken, Task<bool>> verifySucceeded,
        IsolationLevel isolationLevel,
        CancellationToken cancellationToken = default
    );
    
    /// <summary>Saves all changes and accept any changes on success.</summary>
    /// <param name="cancellationToken">Token to cancel async requests.</param>
    /// <returns>Task with result that represents number of state entries written to database.</returns>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    
    /// <summary>
    /// Saves all changes and accept any changes on success if <paramref name="acceptAllChangesOnSuccess"/> is
    /// <c>true</c>.
    /// </summary>
    /// <param name="acceptAllChangesOnSuccess">Whether to accept changes on success.</param>
    /// <param name="cancellationToken">Token to cancel async requests.</param>
    /// <returns>Task with result that represents number of state entries written to database.</returns>
    public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken);
    
    /// <summary>Accepts all changes.</summary>
    public void AcceptAllChanges();
}