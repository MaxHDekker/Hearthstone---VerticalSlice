using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyParticle : MonoBehaviour {

	void Update () {
        Destroy(gameObject, 0.7f);
	}
}
