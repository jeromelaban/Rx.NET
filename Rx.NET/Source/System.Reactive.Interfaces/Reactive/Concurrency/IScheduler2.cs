namespace System.Reactive.Concurrency
{
	/// <summary>
	/// Represents an object that schedules units of work, with stateless methods.
	/// </summary>
	/// <remarks>
	/// This allows for a more efficient scheduling on platforms that require Full 
	/// AOT (UWP and iOS), by avoiding the use of Generic Virtual Methods.
	/// </remarks>
	public interface IScheduler2 : IScheduler
	{
		/// <summary>
		/// Schedules an action to be executed.
		/// </summary>
		/// <param name="action">Action to be executed.</param>
		/// <returns>The disposable object used to cancel the scheduled action (best effort).</returns>
		IDisposable Schedule(Func<IScheduler, IDisposable> action);

		/// <summary>
		/// Schedules an action to be executed after dueTime.
		/// </summary>
		/// <param name="action">Action to be executed.</param>
		/// <param name="dueTime">Relative time after which to execute the action.</param>
		/// <returns>The disposable object used to cancel the scheduled action (best effort).</returns>
		IDisposable Schedule(TimeSpan dueTime, Func<IScheduler, IDisposable> action);

		/// <summary>
		/// Schedules an action to be executed at dueTime.
		/// </summary>
		/// <param name="action">Action to be executed.</param>
		/// <param name="dueTime">Absolute time at which to execute the action.</param>
		/// <returns>The disposable object used to cancel the scheduled action (best effort).</returns>
		IDisposable Schedule(DateTimeOffset dueTime, Func<IScheduler, IDisposable> action);
	}
}