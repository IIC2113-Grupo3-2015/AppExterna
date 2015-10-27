using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppExternaDDS.Models
{
    public class User
    {
        public static readonly User EmptyInstance = new User();

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("followed_candidates")]
        public List<CandidateMetadata> FollowedCandidates { get; set; }

    }
}
