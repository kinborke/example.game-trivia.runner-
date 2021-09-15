using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static Rigidbody playerRb;
    public float PlayerHizi;
    float deltaX;
    float prePosX;
    public float SagsolHizi;
    public float k;
    [SerializeField] ParticleSystem zart;
    public GameObject Canvas;
    public bool gameOver=false;
    public bool gameStart = false;  
    [SerializeField] ParticleSystem zart1;
    public bool kazandi = false;
    public GameObject enemy;
    Enemy enemyScript;

    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        enemyScript = enemy.GetComponent<Enemy>();
    }
    void Update()
    {
        if (gameOver == false && gameStart == true)
        {
            playerRb.transform.Translate(Vector3.forward * PlayerHizi * Time.deltaTime, Space.World);
            swipe();
        }
        else if (gameStart == false && gameOver == false)
        {
            swipe();
        }
        transform.GetChild(0).rotation = Quaternion.Slerp(transform.GetChild(0).rotation, Quaternion.Euler(transform.GetChild(0).eulerAngles.x, 0, transform.GetChild(0).eulerAngles.z), Time.deltaTime * 5);
    }
    private void swipe()
    {
        if (Input.GetMouseButton(0))
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Mathf.Clamp(transform.position.x + deltaX, -k, k), transform.position.y, transform.position.z), Time.deltaTime * SagsolHizi);
            deltaX = Input.mousePosition.x - prePosX;
            prePosX = Input.mousePosition.x;
            float z;
            z = Mathf.Clamp(deltaX, -30, 30);
            transform.GetChild(0).rotation = Quaternion.Slerp(transform.GetChild(0).rotation, Quaternion.Euler(transform.GetChild(0).eulerAngles.x,z*3, transform.GetChild(0).eulerAngles.z), Time.deltaTime * 8);

        }

        if (Input.GetMouseButtonDown(0))
        {
            deltaX = 0;
            prePosX = 0;
            if (gameStart == false)
            {
                gameStart = true;
                transform.GetChild(0).GetComponent<Animator>().SetTrigger("Run");
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            deltaX = 0;
            prePosX = 0;
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("restke"))
        {
            gameOver = true;
            Canvas.SetActive(true);
            
            if (enemyScript.kazandi==false)
            {
                kazandi = true;
                transform.GetChild(0).GetComponent<Animator>().SetTrigger("Happy");
                zart.Play();
                enemyScript.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Fall");
                enemyScript.gameOver = true;
            }
           

        }
        if (other.gameObject.GetComponent<TrueFalse>().answer==true)
        {

            zart.Play();
            
        }
        else
        {
            gameOver = true;
            transform.GetChild(0).GetComponent<Animator>().SetTrigger("Fall");
            zart1.Play();
            Canvas.SetActive(true);

        }        
            

    }
}
