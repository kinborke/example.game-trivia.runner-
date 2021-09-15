using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;


public class Enemy : MonoBehaviour
{
    Rigidbody enemyRb;
    public float enemySpeed = 25;
    public float sagsolhiz = 40;
    System.Random ras;
    public bool gameOver = false;
    public bool gameStart = false;
    public enum States { running, stoping }
    public States currentBehaviour;
    PlayerController playerController;
    public bool kazandi = false;
    public GameObject player;
    [SerializeField] ParticleSystem coki;
    [SerializeField] ParticleSystem coki1;


    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();

        ras = new System.Random();

        currentBehaviour = States.running;

        playerController = player.GetComponent<PlayerController>();

    }

    // trigira giriyo random sag sol alaný olustur 0 if zeroysa biyere one ise baska yere random gitcek saga sola da move towardsla götürcez 
    // eger dogruysa konumu 0 olcak move towardsa 0 yazcaz sonra trigira girdidiginde ayný iþlem yine olcak 

    void Update()
    {
        if (gameOver == false && gameStart == true)
        {
            enemyRb.transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime, Space.World);
            //_running();
            Swipe();

        }
        else if (gameOver == false && gameStart == false)
        {
            Swipe();
            //stoping();

        }


        //enemyRb.transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime, Space.World);
        // transform.GetChild(0).GetComponent<Animator>().SetTrigger("Run");


        //void _running()
        //{
        //    enemyRb.transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime, Space.World);
        //}
        //void stoping()
        //{

    }
    void Swipe()
    {
        if (Input.GetMouseButton(0))
        {

        }
        if (Input.GetMouseButtonDown(0))
        {
            if (gameStart == false)
            {
                gameStart = true;
                transform.GetChild(0).GetComponent<Animator>().SetTrigger("Run");
            }
        }
        if (Input.GetMouseButtonUp(0))
        {

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            int z = ras.Next(0, 2);
            if (z == 1)      //(other.gameObject.GetComponent<TrueFalse>().answer==true)
            {
                transform.DOMoveX(Mathf.Clamp(5, -7, 7), 1f);
                //transform.position = Vector3.MoveTowards(transform.position, new Vector3(Mathf.Clamp(7, -9, 9), transform.position.y, transform.position.z), Time.deltaTime * sagsolhiz);
            }
            else
            {
                transform.DOMoveX(Mathf.Clamp(-5, -7, 7), 1f);
                //transform.position = Vector3.MoveTowards(transform.position, new Vector3(Mathf.Clamp(-7, -9, 9), transform.position.y, transform.position.z), Time.deltaTime * sagsolhiz);
            }

        }
        if (other.gameObject.CompareTag("dogru"))
        {
            if (other.gameObject.GetComponent<TrueFalse>().answer == true)
            {
                coki.Play();
                transform.DOMoveX(Mathf.Clamp(0, -9, 9), 1f);

                //transform.position = Vector3.MoveTowards(transform.position, new Vector3(Mathf.Clamp(transform.position.x + 0, -9, 9), transform.position.y, transform.position.z), Time.deltaTime * sagsolhiz);
            }
            else
            {
                coki1.Play();
                gameOver = true;
                transform.GetChild(0).GetComponent<Animator>().SetTrigger("Fall");

            }
        }

        if (other.gameObject.CompareTag("restke"))
        {
            gameOver = true;

            currentBehaviour = States.stoping;
      
            if (playerController.kazandi==false)
            {
                kazandi = true;
                transform.GetChild(0).GetComponent<Animator>().SetTrigger("Happy");
                playerController.gameOver = true;
                player.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Fall");
                playerController.Canvas.SetActive(true);
            }
        }
    }


}


