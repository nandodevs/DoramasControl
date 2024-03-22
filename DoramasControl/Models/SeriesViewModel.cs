using DoramasControl.Models;

namespace DoramasControl.ViewModels
{
    public class SeriesViewModel
    {
        public List<SeriesModel> Series { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
