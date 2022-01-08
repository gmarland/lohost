﻿namespace lohost.Client.Models
{
    public class ApplicationData
    {
        private char[] _validChars = new char[] {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
                'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
                'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public ApplicationData()
        {
            ApplicationId = GenerateDefaultAddress();

            ApplicationKey = GenerateDefaultKey();

            IsListed = false;

            ApplicationFolder = "App";

            LogsFolder = "Logs";

            ExternalAPI = "https://lohost.io";
        }

        public string ApplicationId { get; set; }

        public string ApplicationKey { get; set; }

        public bool IsListed { get; set; }

        public string Name { get; set; }

        public string[] Tags { get; set; }

        public string ApplicationFolder { get; set; }

        public string LogsFolder { get; set; }

        public string ExternalAPI { get; set; }

        public string[] ApplicationPaths { get; set; }

        public void ValidateApplicationData()
        {
            if (string.IsNullOrEmpty(ApplicationId)) throw new Exception("You must provide a valid ApplicationId");

            if (ApplicationId.Contains('.')) throw new Exception("An ApplicationId cannot contain a .");

            if (ApplicationId.Contains('?')) throw new Exception("An ApplicationId cannot contain a ?");

            if (ApplicationId.Contains('/')) throw new Exception("An ApplicationId cannot contain a /");

            if (ApplicationId.Contains('\\')) throw new Exception("An ApplicationId cannot contain a \\");

            if (ApplicationId.Contains('&')) throw new Exception("An ApplicationId cannot contain a &");

            if (ApplicationId.Contains('#')) throw new Exception("An ApplicationId cannot contain a #");

            if (string.IsNullOrEmpty(ApplicationFolder)) throw new Exception("You must provide a valid ApplicationFolder");

            if (string.IsNullOrEmpty(LogsFolder)) throw new Exception("You must provide a valid LogsFolder");

            if (string.IsNullOrEmpty(ExternalAPI)) throw new Exception("You must provide a valid ExternalAPI");
        }

        public string GetRegisteredAddress()
        {
            if (ExternalAPI.StartsWith("https://")) return $"https://{ApplicationId}.{ExternalAPI.Substring("https://".Length)}";
            else return $"http://{ApplicationId}.{ExternalAPI.Substring("http://".Length)}";
        }

        public string GetApplicationFolder()
        {
            string applicationFolder;

            try
            {
                Path.GetFullPath(ApplicationFolder);

                applicationFolder = ApplicationFolder;
            }
            catch (Exception)
            {
                applicationFolder = Path.Join(Directory.GetCurrentDirectory(), ApplicationFolder);
            }

            if (!Directory.Exists(applicationFolder)) Directory.CreateDirectory(applicationFolder);

            return applicationFolder;
        }

        public string GetLogsFolder()
        {
            string logsFolder;

            try
            {
                Path.GetFullPath(LogsFolder);

                logsFolder = LogsFolder;
            }
            catch (Exception)
            {
                logsFolder = Path.Join(Directory.GetCurrentDirectory(), LogsFolder);
            }

            if (!Directory.Exists(logsFolder)) Directory.CreateDirectory(logsFolder);

            return logsFolder;
        }

        private string GenerateDefaultAddress()
        {

            Random r = new Random();

            string address = string.Empty;

            for (int i = 0; i < 5; i++) address += _validChars[r.Next(0, _validChars.Length)];

            return address;
        }

        private string GenerateDefaultKey()
        {

            Random r = new Random();

            string address = string.Empty;

            for (int i = 0; i < 8; i++) address += _validChars[r.Next(0, _validChars.Length)];

            return address;
        }
    }
}