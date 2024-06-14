using Sources.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class TestWeapon : MonoBehaviour
{
    [SerializeField] private Transform _weaponMuzzle; //дуло оружия
    [SerializeField] private BulletTest _bulletPrefab; //префаб пульки
    [SerializeField] private ForceMode _forceMode = ForceMode.Force;
    [SerializeField] private float _force = 10f;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(PerformAttack);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(PerformAttack);
    }

    private void PerformAttack()
    {
        var projectile = Instantiate(_bulletPrefab, _weaponMuzzle.position, _weaponMuzzle.rotation);
        projectile.Rigidbody.AddForce(_weaponMuzzle.forward * _force, _forceMode);
    }
}
