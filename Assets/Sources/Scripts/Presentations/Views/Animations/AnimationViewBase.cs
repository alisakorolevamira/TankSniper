using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Animations
{
    public abstract class AnimationViewBase : View
    {
        protected List<Action> StoppingAnimations { get; private set; } = new ();

        protected void ExceptAnimation(Action exceptAnimation)
        {
            foreach (Action animation in StoppingAnimations)
            {
                if (animation == exceptAnimation)
                    continue;

                animation.Invoke();
            }
        }
    }
}