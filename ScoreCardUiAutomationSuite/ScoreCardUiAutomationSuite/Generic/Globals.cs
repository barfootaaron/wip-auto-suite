using System;

namespace ScoreCardUiAutomationSuite.Generic
{
    public class Globals
    {
        public class Pages
        {
            public const string Contact = "Saying Hello Is Just Plain Nice";
            
        }

        public static TimeSpan DefaultTimeout => TimeSpan.FromSeconds(10);
        public static TimeSpan NotExistTimeout => TimeSpan.FromSeconds(4);

        public static DriverType GetDriverType(string value) => (DriverType)Enum.Parse(typeof(DriverType), value);
        public enum DriverType
        {
            Chrome,
            Firefox,
            InternetExplorer,
            MicrosoftEdge,
            Safari
        }
    }
}