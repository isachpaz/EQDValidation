namespace WpfEQDValidationApp.DataServices
{
    public class ApplicationDataService : IApplicationDataService
    {
        public string ApplicationTitle { get; set; }
        public string ApplicationVersion { get; set; }

        public ApplicationDataService()
        {
            ApplicationVersion = $"1.0.0";
            ApplicationTitle = $"EQD Validator App v{ApplicationVersion}";
            
        }

    }
}