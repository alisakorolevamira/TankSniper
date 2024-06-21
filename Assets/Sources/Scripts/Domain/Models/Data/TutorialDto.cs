﻿using Sources.Scripts.DomainInterfaces.Models.Data;
using Newtonsoft.Json;

namespace Sources.Scripts.Domain.Models.Data
{
    public class TutorialDto : IDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("hasCompleted")]
        public bool HasCompleted { get; set; }
    }
}