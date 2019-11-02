using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class CrossDimensionalCamera : MonoBehaviour {

    int dimensionACullingMask;
    int dimensionZCullingMask;
    DimensionManager dimensionManager;

	void Start()
    {
        dimensionACullingMask = (1 << LayerMask.NameToLayer("Dimension A") | 1 << LayerMask.NameToLayer("Both Dimensions") | 1 << LayerMask.NameToLayer("Mark") | 1 << LayerMask.NameToLayer("Luna"));
        dimensionZCullingMask = (1 << LayerMask.NameToLayer("Dimension Z") | 1 << LayerMask.NameToLayer("Both Dimensions") | 1 << LayerMask.NameToLayer("Luna") | 1 << LayerMask.NameToLayer("Mark"));
        dimensionManager = GameObject.Find("GeneralManager").GetComponent<DimensionManager>();
    }


	// Update is called once per frame
	void Update () {
		if (dimensionManager.currentDimension == Dimension.DIMENSION_A)
        {
            GetComponent<Camera>().cullingMask = dimensionACullingMask;
        }
        else
        {
            GetComponent<Camera>().cullingMask = dimensionZCullingMask;
        }
	}
}
