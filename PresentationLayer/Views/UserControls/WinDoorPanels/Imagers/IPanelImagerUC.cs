namespace PresentationLayer.Views.UserControls.WinDoorPanels.Imagers
{
    public interface IPanelImagerUC
    {
        int Panel_ID { get; set; }
        string Panel_Placement { get; set; }
        bool pnl_Orientation { get; set; }
    }
}