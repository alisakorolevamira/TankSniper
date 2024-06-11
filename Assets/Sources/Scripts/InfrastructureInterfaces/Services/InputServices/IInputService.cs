using System;
using Sources.Scripts.Domain.Models.Inputs;
using UnityEngine;

namespace Sources.Scripts.InfrastructureInterfaces.Services.InputServices
{
    public interface IInputService
    {
        event Action<Vector2> RotationInputReceived;
    }
}