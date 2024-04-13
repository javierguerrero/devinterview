using Android.App;
using Android.Runtime;

namespace DevInterview.MobileApp
{
    //TODO: https://github.com/dotnet/maui/issues/8379, https://www.youtube.com/watch?v=kvNhLKuAySA
    #if DEBUG
    [Application(UsesCleartextTraffic = true)]
    #else
    [Application]
    #endif
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }


}
