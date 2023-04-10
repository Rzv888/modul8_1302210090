using Newtonsoft.Json;

namespace modul8_1302210090
{
    class BankTransferConfig
    {
        public string Language { get; set; }
        public decimal TransferThreshold { get; set; }
        public decimal TransferLowFee { get; set; }
        public decimal TransferHighFee { get; set; }
        public List<string> TransferMethods { get; set; }
        public string ConfirmationEn { get; set; }
        public string ConfirmationId { get; set; }


        public static BankTransferConfig LoadFromFile(string fileName)
        {
            string json = System.IO.File.ReadAllText(bank_tranfer_config.Json);
            BankTransferConfig config = JsonConvert.DeserializeObject<BankTransferConfig>(json);


            if (string.IsNullOrEmpty(config.Language))
            {
                config.Language = "en";
            }
            if (config.TransferThreshold <= 0)
            {
                config.TransferThreshold = 25000000;
            }
            if (config.TransferLowFee <= 0)
            {
                config.TransferLowFee = 6500;
            }
            if (config.TransferHighFee <= 0)
            {
                config.TransferHighFee = 15000;
            }
            if (config.TransferMethods == null || config.TransferMethods.Count == 0)
            {
                config.TransferMethods = new List<string> { "RTO (real-time)", "SKN", "RTGS", "BI FAST" };
            }
            if (string.IsNullOrEmpty(config.ConfirmationEn))
            {
                config.ConfirmationEn = "yes";
            }
            if (string.IsNullOrEmpty(config.ConfirmationId))
            {
                config.ConfirmationId = "ya";
            }

            return config;
        }
    }
}