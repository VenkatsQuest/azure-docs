using Newtonsoft.Json;
using System;
using System.IO;
using AutomationUsingWinSCP.Helpers;
using WinSCP;

namespace AutomationUsingWinSCP
{
    class Example
    {
        public static void Main()
        {
            int iCheckPoint = 0;
            try
            {
                var data = File.ReadAllText(Constants.JsonPath);
                ++iCheckPoint;
                var settings = JsonConvert.DeserializeObject<WebAdminSettings>(data);
                ++iCheckPoint;
                // Setup session options
                SessionOptions sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Sftp,
                    HostName = settings.HostName,
                    PortNumber = settings.PortNumber,
                    UserName = settings.UserName,
                    Password = settings.Password,
                    SshHostKeyFingerprint = settings.SshHostKeyFingerprint,
                };
                using (Session session = new Session())
                {
                    //Connect
                    session.Open(sessionOptions);
                    ++iCheckPoint;

                    #region FileTransfer
                    // Upload files
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;

                    TransferOperationResult transferResult;
                    //Copying files from local machine to remote
                    Console.WriteLine(Constants.FileCopyInProgress);
                    transferResult = session.PutFiles(settings.SourceFolder, Constants.RemotePath, false, transferOptions);

                    // Throw on any error
                    transferResult.Check();
                    ++iCheckPoint;

                    // Print results
                    foreach (TransferEventArgs transfer in transferResult.Transfers)
                    {
                        Console.WriteLine(Constants.UploadSuccessMsg, transfer.FileName);
                    }
                    #endregion

                    string scommand = string.Format("{0}{1}{2}{3}{4}", 
                                                    Constants.AdminCommand, 
                                                    Constants.QuoteBegin ,
                                                    Constants.DeploymentScriptName,
                                                    settings.SourceFileName,
                                                    Constants.QuoteEnd);

                    CommandExecutionResult pathResult = session.ExecuteCommand(scommand);
                    pathResult.Check();
                    ++iCheckPoint;
                    Console.WriteLine(pathResult.Output);
                    Console.WriteLine("Press Any Key to Exit");
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                ShowMeaningfulMessage(iCheckPoint);
                Console.WriteLine("Exception Details: {0} InnerException:{1}", e.Message, e.InnerException);
            }
        }

        private static void ShowMeaningfulMessage(int iCheckPoint)
        {
            switch (iCheckPoint)
            {
                case 0:
                    Console.WriteLine("");
                    break;
                case 1:
                    Console.WriteLine("");
                    break;
                case 2:
                    Console.WriteLine("");
                    break;
                case 3:
                    Console.WriteLine("");
                    break;
                case 4:
                    Console.WriteLine("");
                    break;
                default:
                    break;
            }
        }
    }
}