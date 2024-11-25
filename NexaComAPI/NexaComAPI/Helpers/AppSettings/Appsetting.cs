namespace NexaComAPI.Helpers.AppSettings
{
    public class AppSetting
    {
        public JWTSetting JWTSettings { get; set; }
    }
    public class JWTSetting
    {
        public string Secret { get; set; }
        public int Expires { get; set; }
    }
}
