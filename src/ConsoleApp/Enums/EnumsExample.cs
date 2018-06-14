using System;
using ConsoleApp.Base;

namespace ConsoleApp.Enums
{
    public class EnumsExample : IDo
    {
        public void Do()
        {
            var platform = Platform.Windows;
            var value = (byte) Platform.Windows;

            var isDefined = Enum.IsDefined(typeof(Platform), (byte)4);
            var parsed = (Platform) 3;

            var allowedPlatforms = Platforms.Windows | Platforms.Mac;
            var isWindowsAllowed = (allowedPlatforms & Platforms.Windows) == Platforms.Windows;
            var isMacAllowed = allowedPlatforms.HasFlag(Platforms.Mac);
            var isAndroidAllowed = allowedPlatforms.HasFlag(Platforms.Android);
        }
    }

    public enum Platform : byte
    {
        Windows = 1,
        Mac = 2,
        Android = 3
    }

    [Flags]
    public enum Platforms : byte
    {
        Windows = 1, // 1 << 0
        Mac = 2,     // 1 << 1
        Android = 4  // 1 << 2
    }
}
