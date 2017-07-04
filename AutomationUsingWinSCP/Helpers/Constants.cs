namespace AutomationUsingWinSCP.Helpers
{
    public class Constants
    {
        public const string JsonError = "We have probelm in reading the Json values";
        public const string JsonPath = @".\WebAdminSettings.json";
        public const string RemotePath = "/home/gumstix/osf/deployments/*";
        public const string FileCopyInProgress = "Copying files from local machine to remote";
        public const string AdminCommand = "sudo su -c ";
        public const string QuoteBegin = "\"";
        public const string QuoteEnd = "\"";
        public const string DeploymentScriptName = "cd /home/gumstix/osf/deployments\n./deploy_file.sh ";
        public const string UploadSuccessMsg = "Upload of {0} succeeded";
    }
}
