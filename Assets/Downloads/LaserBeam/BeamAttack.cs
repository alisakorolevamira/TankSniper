using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeamAttack : MonoBehaviour
{
    public float timeDestroy = 500f;
    public GameObject effect;
    public Transform parentObjectPosition;
    public GameObject parentObject;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject effectGo = (GameObject)Instantiate(effect, parentObjectPosition.position, parentObjectPosition.rotation);
            effectGo.transform.parent = parentObject.transform;
            //Destroy(effectGo, timeDestroy);    
        }
    }
}