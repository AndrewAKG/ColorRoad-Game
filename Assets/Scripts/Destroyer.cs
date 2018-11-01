using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    public CollectablesManager collectableManager;
    public LightManager lightManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            collectableManager.collectablesSoFar--;
        }

        if (other.gameObject.CompareTag("Light"))
        {
            Destroy(other.gameObject);
            lightManager.lightsSoFar--;
        }
    }
}
