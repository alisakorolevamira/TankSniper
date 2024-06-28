using System;
using Doozy.Runtime.UIManager.Components;
using UnityEngine;

namespace Sources.Scripts
{
    public class ShopTankButton : MonoBehaviour
    {
        [SerializeField] private UIButton _button;

        private void OnEnable()
        {
            _button.enabled = false;
        }
    }
}