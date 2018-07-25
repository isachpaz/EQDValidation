namespace WpfEQDValidationApp.DataServices
{
    public interface IApplicationDataService
    {
        string ApplicationTitle { get; set; }
        string ApplicationVersion { get; set; }
    }
}