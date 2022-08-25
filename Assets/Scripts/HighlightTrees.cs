using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightTrees : MonoBehaviour
{
    // Start is called before the first frame update

    cakeslice.Outline lastTree = null;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100)) {
            if(hit.transform.tag == "Tree"){
                lastTree = hit.transform.gameObject.GetComponent<cakeslice.Outline>();
                lastTree.enabled = true;
            } else if(lastTree != null){
                lastTree.enabled = false;
            }
        }
    }
}
