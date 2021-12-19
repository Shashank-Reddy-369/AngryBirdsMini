using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 initialPosition;
    private bool birdWasLaunched = false;
    private float timeSittingAround;
    private Quaternion rotation;
    [SerializeField] private bool resetAfterTrial = false;

    private void Awake()
    {
        initialPosition = transform.position;
        this.rotation = this.transform.rotation;
    }

    // private void Update()
    // {
    //     if(birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
    //         timeSittingAround += Time.deltaTime;
    //     if(transform.position.y > 10 || transform.position.y < -10 || transform.position.x > 10 || transform.position.x < -10 || timeSittingAround > 2)
    //     {
    //         var currentScene = SceneManager.GetActiveScene().name;
    //         SceneManager.LoadScene(currentScene);
    //     }
    // }

    private void Mode1()
    {
        if(birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
            timeSittingAround += Time.deltaTime;
        if(transform.position.y > 10 || transform.position.y < -10 || transform.position.x > 10 || transform.position.x < -10 || timeSittingAround > 2)
        {
            var currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
        }
    }

    private void Mode2()
    {
        if(birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
            timeSittingAround += Time.deltaTime;
        if(transform.position.y > 10 || transform.position.y < -10 || transform.position.x > 10 || transform.position.x < -10)
        {
            //var currentScene = SceneManager.GetActiveScene().name;
            //SceneManager.LoadScene(currentScene);
            var rigidbody = this.GetComponent<Rigidbody2D>();
            // GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            this.transform.position = new Vector3(this.initialPosition.x, this.initialPosition.y);
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
            //this.transform.rotation = this.rotation;
            //birdWasLaunched = false;
            //timeSittingAround = 0;
        }
        if(timeSittingAround > 1)
        {
            this.transform.position = new Vector3(this.initialPosition.x, this.initialPosition.y);
            this.transform.rotation = this.rotation;
            birdWasLaunched = false;
            timeSittingAround = 0;
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    private void Update()
    {
        if(this.resetAfterTrial)
            this.Mode1();
        else
            this.Mode2();
        // if(birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        //     timeSittingAround += Time.deltaTime;
        // if(transform.position.y > 10 || transform.position.y < -10 || transform.position.x > 10 || transform.position.x < -10)
        // {
        //     //var currentScene = SceneManager.GetActiveScene().name;
        //     //SceneManager.LoadScene(currentScene);
        //     var rigidbody = this.GetComponent<Rigidbody2D>();
        //     // GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        //     GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        //     this.transform.position = new Vector3(this.initialPosition.x, this.initialPosition.y);
        //     this.GetComponent<Rigidbody2D>().gravityScale = 0;
        //     //this.transform.rotation = this.rotation;
        //     //birdWasLaunched = false;
        //     //timeSittingAround = 0;
        // }
        // if(timeSittingAround > 1)
        // {
        //     this.transform.position = new Vector3(this.initialPosition.x, this.initialPosition.y);
        //     this.transform.rotation = this.rotation;
        //     birdWasLaunched = false;
        //     timeSittingAround = 0;
        //     this.GetComponent<Rigidbody2D>().gravityScale = 0;
        // }
    }

    private void OnMouseDrag()
    {
        var newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPos.x, newPos.y, 0);
    }

    private void OnMouseUp()
    {
        //var renderer = GetComponent<SpriteRenderer>();
        //renderer.color = Color.green;

        var direction = initialPosition - transform.position;
        this.GetComponent<Rigidbody2D>().AddForce(direction * 500);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        birdWasLaunched = true;
    }
}
