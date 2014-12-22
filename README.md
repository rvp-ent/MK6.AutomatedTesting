# MK6.AutomatedTesting

MK6.AutomatedTesting is a framework for building and running a variety of types of autoamted testing scripts for web applications. Currently, the tools supports load testing using scripts implemented as C# classes. Other capabilities are currently being developed and/or planned, including support for other types of tests (such as automated UI) and other methods of defining test scripts (such as Markdown).

## Writing Scripts

Scripts are comprised of a sequence of steps. A step can be any type of action, such as a single HTTP request, several HTTP requests in parallel, a pause, or a interaction with a browser. 

Currently, scripts are implemented as a C# class that inherits from the `MK6.AutomatedTesting.Script` class. There are two properties, `Steps` and `FinallySteps` which must be overridden. The `Steps` property provides the sequence of actions that the runner should take; the `FinallySteps` property provides the sequence of actions that the runner should take at the end of the script whether previous steps have succeeded or failed (think of like a `try` and `finally` block).



A step is, also, currently defined with a class implementation that inherits from the `MK6.AutomatedTesting.Step` class. There is a single method that must be implemented to provide the runner with a delegate that knows how to execute a step of this type. For example, a step that is to make an HTTP call would know how to get an HTTPClient, create a request, and process the result. An example is available in `MK6.AutomatedTesting.Load.HttpRequestsStep`. The implementation of this class points the runner to a method that runs multiple HTTP requests in parallel and captures the results for reporting later.

```C#
namespace MK6.AutomatedTesting.Load
{
    public class HttpRequestsStep : Step
    {
        public readonly IEnumerable<Request> Requests;

        public HttpRequestsStep(params Request[] requests)
        {
            this.Requests = requests ?? Enumerable.Empty<Request>();
        }

        public override RunStepDelegate Runner
        {
            get
            {
                return HttpRequestsStepRunner.Run;
            }
        }
    }
}
```

## Running test scripts

Currently, test scripts are run from the command line via `MK6.AutomatedTesting.Runner.exe`. A single parameter, a configuration file for the run, must be provided as the first and only argument. The configuration file uses simple YAML-type formatting to denote key-value pairs. Depending on the how script will be run, there are five or six required properties:
* `ScriptType`: Currently, the only supported value here is `Assembly`. Any other value will cause an exception to be thrown.
* `ScriptSource`: This is the full name of the script type. For example, if the script was defined in a class name `ApplicationLoadScript` within namespace `MyApplication.LoadTests.Scripts` and assembly `MyApplication.LoadTests`, the appropriate value here would be `MyApplication.LoadTests.Scripts.ApplicationLoadScript, MyApplication.LoadTests`.
* `Workers`: This is the number of concurrent virtual users that will run the script. Scaling this number replicates more or less simultaneous users of the service or application.
* `RunType`: This can be either the value `FixedIterations` or `FixedTime`. 
* `IterationsPerWorker`: If `RunType` is `FixedIterations`, this is the number of times that each worker will run the script.
* `RunTime`: If `RunType` is `FixedTime`, this is how long the script will run for before shutting down. If a worker is in the middle of a script when `RunTime` elapses, the current step will be cancelled and the finally steps, if any, will be executed.
* `ReportWriter`: Full name of the type used to produce a report of the script run. The type name should be specified in the same way as the `ScriptSource` parameter.

Blank lines are ignored as are lines preceded with a hash/comment character (#).

Any additional key-value pairs populated in the configuration file will be available to the executing script in the `IterationContext`'s environment. For example,

```YAML
ScriptType: Assembly
ScriptSource: MyApplication.LoadTests.Scripts.ApplicationLoadScript, MyApplication.LoadTests

Workers: 10

RunType: FixedIterations
IterationsPerWorker: 10

# These key-value pairs are available to the script steps through the context environment
BaseUrl: http://myapp.domain.com
AdditionalData: Value
```
