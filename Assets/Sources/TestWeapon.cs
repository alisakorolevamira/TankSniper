using Sources.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class TestWeapon : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Rigidbody _rigidbodyy;
    [SerializeField] private Button _button;
    [SerializeField] private ForceMode _forceMode;

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

        
        _rigidbody.AddForce(new Vector3(transform.position.x -2, 
            transform.position.y+5, transform.position.z +3), _forceMode);
        
        _rigidbodyy.AddForce(new Vector3(transform.position.x +2, 
            transform.position.y+5, transform.position.z -3), _forceMode);
    }
}
