﻿using System.Collections.Generic;
using Sources.Scripts.InfrastructureInterfaces.StateMachines.FiniteStateMachines.Transitions;

namespace Sources.Scripts.Infrastructure.StateMachines.FiniteStateMachines.States
{
    public class FiniteState
    {
        private readonly List<IFiniteTransition> _transitions = new ();

        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }

        public virtual void Update(float deltaTime)
        {
        }

        public void AddTransition(IFiniteTransition transition) =>
            _transitions.Add(transition);

        public void RemoveTransition(IFiniteTransition transition) =>
            _transitions.Remove(transition);

        public bool TryGetNextState(out FiniteState nextState)
        {
            nextState = default;

            foreach (IFiniteTransition transition in _transitions)
            {
                if (transition.CanMoveNextState(out nextState))
                    return true;
            }

            return false;
        }
    }
}