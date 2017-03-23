using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour {

    public GameObject projectilePrefab;
    private List<GameObject> Projectiles = new List<GameObject>();
    private Vector3 mousePosition;
    //private float aimAngel;
    //private Vector3 crossProduct;
    Camera cam;

    private float projectileVelocity;



	// Use this for initialization
	void Start () {
        cam = GameObject.Find("CameraPlayer").GetComponent<Camera>();        
        projectileVelocity = 10f;

	}
	
	// Update is called once per frame
	void Update ()
    {
        //aimAngel = Vector2.Angle(Vector2.up, mousePosition);
        //crossProduct = Vector3.Cross(Vector2.up, mousePosition);

        //if (crossProduct.z < 0)
        //    aimAngel = 360 - aimAngel;

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject arrow = (GameObject)Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Projectiles.Add(arrow);
            mousePosition = cam.ScreenToWorldPoint(Input.mousePosition).normalized;
            Debug.Log(mousePosition);
            Rigidbody rigidbody = arrow.GetComponent<Rigidbody>();
            Vector3 arrowDirection = new Vector3(mousePosition.x, mousePosition.y);
            rigidbody.AddForce(arrowDirection * projectileVelocity, ForceMode.Impulse);

            Destroy(arrow, 3.0f);
        }

	}

}
