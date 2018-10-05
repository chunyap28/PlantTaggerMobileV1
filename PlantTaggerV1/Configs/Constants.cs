using System;
namespace PlantTaggerV1.Configs
{
    public class Constants
    {
#if DEBUG        
        public static string PtBasedUrl = "http://192.168.1.163:8080/";
        public static string FBClientId = "223710198203829";
#else
        public static string PtBasedUrl = "http://localhost:8080/";
        public static string FBClientId = "223710198203829";
#endif
    }
}
