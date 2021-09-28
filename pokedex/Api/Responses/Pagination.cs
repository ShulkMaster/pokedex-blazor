using System.Collections.Generic;

namespace Pokedex.Api.Responses
{
    public class Pagination<T> where T : class
    {
        public int Count { get; set; }

        public string Next { get; set; } = string.Empty;

        public string Previous { get; set; } = string.Empty;

        public List<T> Results {  get; set; } = new ();
    }
}
