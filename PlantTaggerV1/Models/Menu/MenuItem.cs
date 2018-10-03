
namespace PlantTaggerV1.Models.Menu
{
    public class MenuItem
    {
        public MenuItem(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUri { get; set; }
    }
}
