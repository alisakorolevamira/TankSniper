using Sources.Scripts.Presentations.Views;
using Sources.Scripts.UIFramework.Presentations.Animations.Types;
using Sources.Scripts.UIFramework.Services.Animations;
using Sources.Scripts.UIFramework.ServicesInterfaces.Animations;
using UnityEngine;

namespace Sources.Scripts.UIFramework.Presentations.Animations
{
    public class UIAnimator : View
    {
        [SerializeField] private AnimationType _animationType = AnimationType.Move;
        [SerializeField] private MoveAnimationType _moveAnimationType;
        [SerializeField] private float _animationDuration = 0.1f;
        [SerializeField] private Vector3 _fromPosition;
        [SerializeField] private Vector3 _targetPosition;

        private IAnimationService _animationService = new AnimationService();

        public AnimationType AnimationType => _animationType;

        public MoveAnimationType MoveAnimationType => _moveAnimationType;

        public float AnimationDuration => _animationDuration;

        public Vector3 FromPosition => _fromPosition;

        public Vector3 TargetPosition => _targetPosition;
        
        private void Awake() => 
            _animationService.Construct(this);

        private void OnEnable() =>
            _animationService.Enable();

        private void OnDisable() =>
            _animationService.Disable();
    }
}