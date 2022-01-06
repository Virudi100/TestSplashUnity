using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ded : MonoBehaviour
{
    public GameObject DCanvas;
    private bool isded = false;
    private bool isplaying = false;
    public GameObject Bcanvas;
    private bool win = false;
    public GameObject CWin;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ded")
        {
            DCanvas.SetActive(true);
            Time.timeScale = 0;
            isplaying = false;
            isded = true;
        }

        if (other.gameObject.tag == "win")
        {
            CWin.SetActive(true);
            Time.timeScale = 0;
            isplaying = false;
            win = true;
        }

    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && isded == true)
            {
                SceneManager.LoadScene("Main");
            }

            if (touch.phase == TouchPhase.Began && win == true)
            {
                SceneManager.LoadScene("Main");
            }

            if (touch.phase == TouchPhase.Began && isplaying == false)
            {
                Bcanvas.SetActive(false);
                Time.timeScale = 1;
                isplaying = true;
            }
        }
       
    }

    private void Awake()
    {
        Time.timeScale = 0;
        isded = false; 
    }

}
