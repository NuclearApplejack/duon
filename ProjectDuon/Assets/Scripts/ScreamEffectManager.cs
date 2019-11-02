using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamEffectManager : MonoBehaviour {

    void Start()
    {
        transform.Rotate(new Vector3(0, 0, 90 * Random.Range(0, 4)));
    }

    public void DestroyEffect()
    {
        Destroy(gameObject);
    }
}
