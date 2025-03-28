﻿using Sources.Scripts.DomainInterfaces.Models.Payloads;

namespace Sources.Scripts.Domain.Models.Payloads
{
    public class ScenePayload : IScenePayload
    {
        public ScenePayload(string sceneId, bool canLoad, bool canFromGameplay)
        {
            SceneId = sceneId;
            CanLoad = canLoad;
            CanFromGameplay = canFromGameplay;
        }

        public string SceneId { get; }
        public bool CanLoad { get; }
        public bool CanFromGameplay { get; }
    }
}