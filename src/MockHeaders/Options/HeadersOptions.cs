using System.Collections.Generic;

namespace MockHeaders
{
    public class HeadersOptions
    {
        public HeadersOptions()
        {
            Headers = new Dictionary<string, string>();
        }

        public IDictionary<string, string> Headers { get; }
    }
}

