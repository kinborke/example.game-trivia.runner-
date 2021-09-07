using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class res:MonoBehaviour
{
     
    public GameObject Canvas;
    public GameObject body;


    public void RestartGame()
    {
        SceneManager.LoadScene("Scenes/SampleScene");

    }





    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("playerRb"))
        {
            Canvas.SetActive(true);

        }
    }
}
