using System;

namespace WebExplorer
{
    public class PlatformDetectionService
    {
        public bool OperatingSystemIsWindows()
        {
            return OperatingSystem.IsWindows();
        }


        public bool TargetFrameworkIsWindows()
        {
#if WINDOWS
        return true;
#else
            return false;
#endif
        }
    }
}
