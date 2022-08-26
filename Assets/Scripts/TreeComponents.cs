using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeComponents: MonoBehaviour
{

    List<GameObject> bananas = new List<GameObject>();

    public List<GameObject> getBananas(){
        return bananas;
    }

    public void addBanana(GameObject banana){
        bananas.Add(banana);
    }

    public void clear(){
        bananas.Clear();
    }

    public bool haveBananas(){
        return bananas.Count > 0;
    }
}
