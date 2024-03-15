

namespace DevInterview.MobileApp.Models
{
    public class Topic
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Number {  get; set; }

        public string Title => $"{Number}. {Name}";
    }
}