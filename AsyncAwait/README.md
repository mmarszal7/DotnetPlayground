It is simplified version of [Jeremy Bytes] sample application, made as a part of [Task, Await, and Asynchronous Methods] presentation.

# Notes
## 1. Overview
**Asynchronous** code is based on **Callbacks**. Which means asynchronous IS NOT parallel execution.<br>
**Asynchronous** is about giving control over long running tasks to a different thread and then managing callback (data, exceptions, cancelations etc.)<br>
**Parallel execution** (see example in 3.) can be achieved e.g. by running multiple tasks at once and then managing their responses with **WhenAll()**<br>
**So async/await is mostly used for I/O operations** (database or web connection, reading files etc) that don't need CPU but takes long to wait for external response

### **Flow**:
- Code is running synchronously until it reaches Task which is Promise of future data with specific type.
- Started task is continued on different thread than invoker and invoker state is saved (not paused) for the execution time.
- When code reaches 'await' keyword it either gets data from completed task or (most often) waits for task to complete.
- When it reaches another long running operation it starts a new thread and return control to invoker
- When task is completed invoker is resumed and the rest of an invoker code is running synchronously
<br><br>

### **Await vs Result vs Wait() vs ContinueWith()**:

**Result** returns data, **Wait()** not. Wait() and Result both blocks invoker until task is completed<br>
**ContinueWith()** and **await** do the same thing but await is more syntax friendly and ContinueWith allow to configure more things:
- continuation based on Task.State - ContinueWith can be executed e.g. only if task was cancelled or failed 
- cancelation token
- context - you can specify in which Thread task should be continued after competition (useful e.g. in UI apps where you need to continue tasks in UI Thread)
- exception handling - you always get all exceptions from all levels aggregated in AggregateException

```C#
// ContinueWith
var task = new Task(() => {Task.Delay(3000); return 5;});
task.Start()
task.ContinueWith(task => Console.WriteLine("Finished" + task.Result), token, continuationConditions, context);
task.Wait();

// await
var result = await Delay();
Console.WriteLine("Finished" + result);
```

---
## 2. Best practices

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

## 3. Parallel execution - example
``` C#
// Overall processing time = 2sec
public async Task GoodExample()
{
    var tasks = new List<Task>();
    for (var i = 0; i < 5; i++)
    {
        tasks.Add(LongRunningOperation());
    }
    await Task.WhenAll(tasks);
}

// Overall processing time = 10sec
public async Task BadExample()
{
    for (var i = 0; i < 5; i++)
    {
        await LongRunningOperation();
    }
}

private async Task LongRunningOperation()
{
    Console.WriteLine("Start processing...");
    await Task.Delay(2000);
    Console.WriteLine("End");
}
```
