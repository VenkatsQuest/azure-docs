namespace AutomationUsingWinSCP.Helpers
{
    public class WebAdminSettings
    {
        public string HostName { get; set; }
        public int PortNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SshHostKeyFingerprint { get; set; }
        public string SourceFolder { get; set; }
        public string SourceFileName { get; set; }
    }
}
