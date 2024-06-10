using Sources.Scripts.InfrastructureInterfaces.StateMachines.ContextStateMachines.Contexts;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Inputs
{
    public class InputData : IContext
    {
        public bool IsAttacking { get; set; }
    }
}