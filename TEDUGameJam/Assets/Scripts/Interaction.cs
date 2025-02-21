using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public Text hintText;
    void Start()
    {
        hintText.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E)) {
            hintText.gameObject.SetActive(false);
        }
    }
}
