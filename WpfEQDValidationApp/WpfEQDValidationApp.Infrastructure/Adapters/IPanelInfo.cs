namespace WpfEQDValidationApp.Infrastructure.Adapters
{
    public interface IPanelInfo
    {
        string GetPanelCaption();
        bool ShowCloseButton { get; set; }
    }
}