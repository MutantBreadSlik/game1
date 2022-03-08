using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  private Rigidbody2D rb;
  public CircleCollider2D collider;

  private void Start() {
      rb = GetComponent<Rigidbody2D>();
  }

  
  private void OnCollisionEnter2D(Collision2D other) {
    if(other.collider.gameObject.tag == "Enemy"){
      Destroy(other.collider.gameObject);   
    }
  }
       
  private void Update() {
    Vector2 v = rb.velocity;
    v = v.normalized;
    v *= 10;
    rb.velocity = v;  
  }
       
}
