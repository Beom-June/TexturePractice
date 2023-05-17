using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasOnOff : MonoBehaviour
{
    public GameObject drawCanvas;
        private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            drawCanvas.SetActive(true);
        }   
    }
    void OnTriggerExit(Collider other)
    {
                if(other.gameObject.CompareTag("Player"))
        {
            drawCanvas.SetActive(false);
        }   
    }
}
