namespace ModelLayer.Model.Quotation.WinDoor
{
    public interface IWindoorModel
    {
        string WD_description { get; set; }
        string WD_profile { get; set; }
        decimal WD_discount { get; set; }
        int WD_height { get; set; }
        int WD_id { get; set; }
        string WD_name { get; set; }
        bool WD_orientation { get; set; }
        int WD_price { get; set; }
        int WD_quantity { get; set; }
        bool WD_visibility { get; set; }
        int WD_width { get; set; }
        int WD_zoom { get; set; }
    }
}