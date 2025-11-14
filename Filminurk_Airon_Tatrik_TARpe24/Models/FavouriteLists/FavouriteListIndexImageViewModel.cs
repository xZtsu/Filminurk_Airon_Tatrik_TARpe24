using System.ComponentModel.DataAnnotations;

namespace Filminurk.Models.FavouriteLists
{
    public class FavouriteListIndexImageViewModel
    {
        [Key]
        public Guid ImageID { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string Image { get; set; } //määrab ära kas pilt on poster või mitte
        public Guid? ListID { get; set; }
    }
}
