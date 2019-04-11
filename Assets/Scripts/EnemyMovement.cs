using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;
    private float mvt = 1;

    void Start(){
      rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col){
      if (col.gameObject.CompareTag("Wall")){
        mvt = -mvt;
      }
    }

    void Update()
    {
      Vector3 movement = new Vector3 (mvt, 0, 0);

      rb.AddForce(movement * speed);
    }
}
