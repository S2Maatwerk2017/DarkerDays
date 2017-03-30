using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour {


    void Start()
    {

    }


    void Update()
    {
        Move();
    }

    private void Move()
    {
        var HorSpeed = Input.GetAxis("Horizontal") * Time.deltaTime * 5.0f;
        var VerSpeed = Input.GetAxis("Vertical") * Time.deltaTime * 5.0f;
        transform.Translate(HorSpeed,0, VerSpeed);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().PlayerIsSpotted();
        }
    }

}

