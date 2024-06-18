using System.Collections.Generic;
using System.Linq;
using Lean.Touch;
using Sources.Scripts;
using Sources.Scripts.UIFramework.Presentations.CommonTypes;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;


public class TestWeapon : MonoBehaviour
{
    [SerializeField] private Button _addButton;
    [SerializeField] private List<TankPoint> _points;

    private void OnEnable()
    {
        _addButton.onClick.AddListener(AddNewTank);
    }

    private void AddNewTank()
    {
        var point = _points.FirstOrDefault(x => x.IsAvailable);

        if (point != null)
        {
            Debug.Log(point.transform.position);
            var prefab = Resources.Load<GameObject>("Views/Tank1");
            GameObject newTank = Object.Instantiate(prefab, point.transform.position, prefab.transform.rotation);
            point.IsAvailable = false;
        }
    }
}
