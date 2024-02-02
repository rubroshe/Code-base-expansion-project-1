using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{

    [SerializeField] private GameObject Camera_Obj;

    private void Awake()
    {
        Camera_Obj = GameObject.Find("PlayerCam");
    }

    void Update()
    {
        this.transform.LookAt(Camera_Obj.transform.position);
    }
}
