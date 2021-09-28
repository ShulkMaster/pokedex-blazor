namespace Pokedex.Api
{
    public static class Endpoint
    {
        public const string BaseUrl = "https://pokeapi.co/api/v2/";

        public static class Pokemon
        {
            public const string Index = "pokemon";

            public static string Details(int id) => $"{Index}/{id}";
            public static string Details(string name) => $"{Index}/{name}";
            public static string Abilities(int id) => $"ability/{id}";
        }

    }
}
