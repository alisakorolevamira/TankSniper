using ShatterToolkit;
using ShatterToolkit.Helpers;
using Sources.Scripts.PresentationsInterfaces.Views.BossPeaces;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.BossPeaces
{
    public class RobotBossPieceView : View, IBossPieceView
    {
        [SerializeField] private ShatterTool _shatter;
        [SerializeField] private PieceRemover _pieceRemover;

        public bool IsDestroyed { get; private set; }

        private void OnEnable() => 
            transform.SetParent(null);

        public void Explode()
        {
            gameObject.SetActive(true);
            IsDestroyed = true;
            _shatter.enabled = true;
            _pieceRemover.startAtGeneration = 1;
        }
    }
}