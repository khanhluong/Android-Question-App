using System;
namespace Android_Question_App.Model
{
    public class SubReddit
    {
        public SubReddit(String name, String imageUrl)
        {
            Name = name;
            ImageUrl = imageUrl;
        }

        public string Name { get; }
        public string ImageUrl { get; }
    }
}
