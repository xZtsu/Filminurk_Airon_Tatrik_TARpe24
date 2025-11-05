namespace Filminurk.Models.Actors
{
    public class ImageViewModel
    {
        public Guid ImageID { get; set; }
        public string? FilePath { get; set; }
        public Guid? ActorID { get; set; }
        public bool? IsPoster { get; set; } //määrab ära kas pilt on poster või mitte
    }
}
