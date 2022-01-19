using models.first_web_api;

namespace first_web_api.DTOs.Character
{
    public class GetCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Bader";
        public int age { get; set; } = 22;
        public string Description { get; set; } = "Hello, Welcome to my first WepApi. using Api dotnet";

        public RpgClass Class { get; set; } = RpgClass.Nader;
    }
}
