using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementHint : MonoBehaviour
{
    public Text movementText;
    public Text jumpHint;
    void Start() {
        movementText.gameObject.SetActive(true);
        jumpHint.gameObject.SetActive(true);
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) ) {
            movementText.gameObject.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.Space)){
            jumpHint.gameObject.SetActive(false);
        }
    }
}
