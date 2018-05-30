It is simplified version of [Jeremy Bytes] sample application, made as a part of [Task, Await, and Asynchronous Methods] presentation.

# Notes
---

MSDN Link: https://msdn.microsoft.com/en-us/magazine/jj991977.aspx

**Main rules**
- Async all the way - from up *async void Event()* next asynchronous functions should be *async Task<> method()*<br>
**MSDN**:<br>
"The best solution to this problem is to allow async code to grow naturally through the codebase. If you follow this solution, you’ll see async code expand to its entry point, usually an event handler or controller action."
- Do not use *async void* in ordinary methods, they have different error-handling semantics
**MSDN**: 
```
private async void ThrowExceptionAsync()
{
  throw new InvalidOperationException();
}
public void AsyncVoidExceptions_CannotBeCaughtByCatch()
{
  try
  {
    ThrowExceptionAsync();
  }
  catch (Exception)
  {
    // The exception is never caught here!
    throw;
  }
}
```

**Summary of Asynchronous Programming Guidelines**

Name	            | Description                                       |	Exceptions
--- | --- | ---
Avoid async void	| Prefer async Task methods over async void methods | Event handlers
Async all the way	| Don’t mix blocking and async code                 | Console main method
Configure context	| Use ConfigureAwait(false) when you can            | Methods that require context

**The “Async Way” of Doing Things**

To Do This …                                    |	Instead of This …       |	Use This
--- | --- | ---
Retrieve the result of a background task	    | Task.Wait or Task.Result  |	await
Wait for any task to complete                   | Task.WaitAny              |	await Task.WhenAny
Retrieve the results of multiple tasks	        | Task.WaitAll              |	await Task.WhenAll
Wait a period of time                           | Thread.Sleep              |	await Task.Delay



**Solutions to Common Async Problems**

Problem	| Solution
--- | --- 
Create a task to execute code	                    | Task.Run or TaskFactory.StartNew (not the Task constructor or Task.Start)
Create a task wrapper for an operation or event	    | TaskFactory.FromAsync or TaskCompletionSource<T>
Support cancellation	                            | CancellationTokenSource and CancellationToken
Report progress	                                    | IProgress<T> and Progress<T>
Handle streams of data                              | TPL Dataflow or Reactive Extensions
Synchronize access to a shared resource         	| SemaphoreSlim
Asynchronously initialize a resource                | AsyncLazy<T>
Async-ready producer/consumer structures	        | TPL Dataflow or AsyncCollection<T>

[Jeremy Bytes]: http://www.jeremybytes.com/
[Task, Await, and Asynchronous Methods]: http://www.jeremybytes.com/Demos.aspx#TaskAndAwait