using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeThrow : MonoBehaviour
{
    [SerializeField]
    private Vector2 _hitForce;

    private bool _isHitActive = true;

    private Rigidbody2D _knifeRD2D;
    private BoxCollider2D _knifeCollidor2D;


    private void Awake()
    {
        _knifeRD2D = GetComponent<Rigidbody2D>();
        _knifeCollidor2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && _isHitActive)
        {
            _knifeRD2D.AddForce(_hitForce,ForceMode2D.Impulse);
            _knifeRD2D.gravityScale = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_isHitActive)
            return;

        if(collision.collider.CompareTag("Wheel"))
        {
            _knifeRD2D.velocity = new Vector2(0,0);
            _knifeRD2D.bodyType = RigidbodyType2D.Kinematic;
            transform.SetParent(collision.collider.transform);

            _knifeCollidor2D.offset = new Vector2(_knifeCollidor2D.offset.x , -0.2f);
            _knifeCollidor2D.size = new Vector2(_knifeCollidor2D.size.x, 0.8f);
        }
        else if(collision.collider.CompareTag("Knife"))
        {
            _knifeRD2D.velocity = new Vector2(_knifeRD2D.velocity.x, -2);
        }
    }
}
