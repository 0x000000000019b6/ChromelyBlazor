namespace ChromelyBlazor.Shared;

public static class ServerAppUtil
{
    private const int DefaultPort = 5001;
    private const int StartScan = 5050;
    private const int EndScan = 6000;
    private const string ArgumentType = "--type";

    public static Task? BlazorTask;
    public static CancellationTokenSource? BlazorTaskTokenSource;

    public static bool IsMainProcess(IEnumerable<string> args)
    {
        if (args == null || !args.Any())
        {
            return true;
        }

        if (!HasArgument(args, ArgumentType))
        {
            return true;
        }

        return false;
    }

    public static void ProcessExit(object sender, EventArgs e)
    {
        // Clean up kestrel process if not taken down by OS. This can
        // occur when the app is closed from WindowController (frameless).
        Task.Run(() =>
        {
            if (BlazorTaskTokenSource != null)
            {
                WaitHandle.WaitAny(new[] { BlazorTaskTokenSource.Token.WaitHandle });
            }

            BlazorTask?.Dispose();
        });
        BlazorTaskTokenSource?.Cancel();
    }

    private static bool HasArgument(IEnumerable<string> args, string arg)
    {
        return args.Any(a => a.StartsWith(arg));
    }
}
