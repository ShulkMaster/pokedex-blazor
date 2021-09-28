using System;
using System.Collections.Generic;

namespace Pokedex.Api
{
    public record Result<T> where T : class
    {
        public sealed record Success: Result<T>
        {
            public T Value { get; init; } = default!;
        }

        public sealed record Failure: Result<T>
        {
            public IEnumerable<string> Errors { get; set; } = Array.Empty<string>();
        }

    }
}
