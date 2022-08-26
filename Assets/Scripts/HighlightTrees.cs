using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightTrees : MonoBehaviour
{
    // Start is called before the first frame update

    Transform lastTree = null;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100)) {
            if(hit.transform.tag == "Tree"){
                if(lastTree != null && hit.transform.name != lastTree.name) lastTree.gameObject.GetComponent<cakeslice.Outline>().enabled = false;
                lastTree = hit.transform;
                lastTree.gameObject.GetComponent<cakeslice.Outline>().enabled = true;
            } else if(lastTree != null){
                lastTree.gameObject.GetComponent<cakeslice.Outline>().enabled = false;
            }
        }
    }
}
