﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// @haeejuut 10.17.2018
/// </summary>
public class CameraScript : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {

        /*
         * Sends a ray from camera (script as camera component) center.
         * Starts Coroutine on hit.
        */
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            StartCoroutine(LockOnTarget(hit));
        }
	}

    /// <summary>
    /// If you hit the target for 1 second, it will change color to red.
    /// After 0.5 seconds the target will be destroyed.
    /// Functionality of hit objects can be implemented in this dummy.
    /// </summary>
    /// <param name="hit"></param>
    /// <returns></returns>
    IEnumerator LockOnTarget(RaycastHit hit)
    {
        
        Transform wanha = hit.transform;
        yield return new WaitForSeconds(1);
        Transform uusi = hit.transform;
        if (wanha && uusi && wanha == uusi)
        {
            GameObject destroyable = hit.transform.gameObject;
            MeshRenderer m_rend = destroyable.GetComponent<MeshRenderer>();
            m_rend.material.color = Color.red;
            yield return new WaitForSeconds(.5f);
            Destroy(destroyable);
        }
    }
}
