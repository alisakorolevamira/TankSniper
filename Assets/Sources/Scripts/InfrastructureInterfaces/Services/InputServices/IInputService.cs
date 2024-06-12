using System;
using Sources.Scripts.ControllersInterfaces.ControllerLifetimes;
using Sources.Scripts.Domain.Models.Inputs;
using UnityEngine;

namespace Sources.Scripts.InfrastructureInterfaces.Services.InputServices
{
    public interface IInputService : IEnterable, IExitable
    {
        event Action<Vector2> RotationInputReceived;
        event Action AttackInputReceived;
    }
}