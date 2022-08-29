using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    
    [SerializeField]
    public List<GameObject> images;

    [SerializeField]
    public string nextScene = "HouseScene";

    [SerializeField]
    List<GameObject> texts;

    GameObject actualImage;
    GameObject actualText;



    void Start() {
        actualImage = images[0];
        images.Remove(actualImage);
        actualText = texts[0];
        texts.Remove(actualText);

        actualImage.SetActive(true);
        actualText.SetActive(true);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Destroy(actualImage);
            Destroy(actualText);
            if(images.Count > 0){
                actualImage = images[0];
                images.Remove(actualImage);
                if(texts[0] != null){
                    actualText = texts[0];
                    texts.Remove(actualText);
                    actualImage.SetActive(true);
                    actualText.SetActive(true);
                }

            } else {
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
