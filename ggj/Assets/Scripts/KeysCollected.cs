using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeysCollected : MonoBehaviour
{
    public int KeysCollected_num = 0;

    [SerializeField] private GameObject door;
    [SerializeField] private TextMeshProUGUI keyText;
     
    private void Update()
    {
        keyText.text = "Keys Collected: " + KeysCollected_num;

        if(KeysCollected_num >= 3)
        {
            door.SetActive(false);
        }
    }

}
