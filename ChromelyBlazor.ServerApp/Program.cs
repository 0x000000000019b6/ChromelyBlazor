#pragma warning disable CS8622 

var appName = Assembly.GetEntryAssembly()?.GetName().Name ?? "Chromely Blazor Server";
var firstProcess = ServerAppUtil.IsMainProcess(args);
var port = 23423;

if (firstProcess)
{
    if (port != -1)
    {
        // start the kestrel server in a background thread
        AppDomain.CurrentDomain.ProcessExit += ServerAppUtil.ProcessExit;
        ServerAppUtil.BlazorTaskTokenSource = new CancellationTokenSource();
        ServerAppUtil.BlazorTask = new Task(() =>
        {
            BlazorAppBuilder.Create(args, port)
                .Build()
                .Run();

        }, ServerAppUtil.BlazorTaskTokenSource.Token, TaskCreationOptions.LongRunning);
        ServerAppUtil.BlazorTask.Start();

        // wait till its up

    }


}

if (port != -1)
{
    // start up chromely
    var core = typeof(IChromelyConfiguration).Assembly;
    var config = DefaultConfiguration.CreateForRuntimePlatform();
    config.WindowOptions.Title = "blazor server app demo";
    config.StartUrl = $"http://127.0.0.1:{port}";
    config.DebuggingMode = true;
    config.WindowOptions.RelativePathToIconFile = "chromely.ico";
    
    config.CommandLineArgs.Add("no-sandbox","1");
    config.CommandLineArgs.Add("disable-software-rasterizer","1");
    config.CommandLineArgs.Add("disable-features", "DefaultPassthroughCommandDecoder");
    
    try
    {
        var builder = AppBuilder.Create(args);
        builder = builder.UseConfig<DefaultConfiguration>(config);
        builder = builder.UseApp<DemoChromelyApp>();
        builder = builder.Build();
        builder.Run();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        throw;
    }
}


public class DemoChromelyApp : ChromelyBasicApp
{
    public override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);
        RegisterChromelyControllerAssembly(services, typeof(MovieController).Assembly);
    }
}
