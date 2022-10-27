using CustomAssetEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollection : MonoBehaviour
{
   [SerializeField]
   VoidEvent keyCollect;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            keyCollect?.Raise();
        }
    }
}
