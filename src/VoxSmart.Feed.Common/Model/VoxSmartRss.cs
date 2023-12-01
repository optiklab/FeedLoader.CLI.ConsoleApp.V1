namespace VoxSmart.Feed.Common.Model
{
    public class VoxSmartRss
    {
        public VoxSmartRss()
        {
            Entities = new List<VoxSmartEntity>();
        }

        public List<VoxSmartEntity> Entities { get; set; }
    }
}
