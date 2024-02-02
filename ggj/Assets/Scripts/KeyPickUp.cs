using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    [SerializeField] private KeysCollected keysClass;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            keysClass.KeysCollected_num += 1;
            GameObject.Destroy(this.gameObject);
        }
    }

}
