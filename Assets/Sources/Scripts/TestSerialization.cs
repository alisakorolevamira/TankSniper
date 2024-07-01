using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Sources.Scripts.Domain.Models.Shop;
using Sources.Scripts.Presentations.Views.Players.Skins.MaterialTypes;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Scripts
{
    public class TestSerialization : MonoBehaviour
    {
        public Button SerializeButton;
        public Button DeSerializeButton;
        
        private List<ShopPatternButton> _buttons = new()
        {
            new ShopPatternButton("1", true, MaterialType.Green),
            new ShopPatternButton("1", false, MaterialType.Grey),
        };

        private List<ShopPatternButton> _buttons2 = new();

        private string json;

        private void OnEnable()
        {
            SerializeButton.onClick.AddListener(Se);
            DeSerializeButton.onClick.AddListener(Dese);
        }

        private void OnDisable()
        {
            SerializeButton.onClick.RemoveListener(Se);
            DeSerializeButton.onClick.RemoveListener(Dese);
        }

        private void Se()
        {
            json = JsonConvert.SerializeObject(_buttons, Formatting.Indented);
            Debug.Log(json);
        }

        private void Dese()
        {
            _buttons2 = JsonConvert.DeserializeObject<List<ShopPatternButton>>(json);
            if(_buttons2[1].MaterialType == MaterialType.Grey)
                Debug.Log("yes3");
        }
    }
}