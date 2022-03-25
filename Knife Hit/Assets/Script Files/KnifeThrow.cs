using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KnifeThrow : MonoBehaviour
{
    [SerializeField]
    private Vector2 _hitForce;

    private bool _isHitActive = true;
    private bool _isHit = true;

    private Rigidbody2D _knifeRD2D;
    private BoxCollider2D _knifeCollidor2D;


    private AudioSource _hitSound;
    public AudioClip[] _hitClip;

    private ParticleSystem _hitParticle;
    public static int _SCORE=0;
    
    //public Text scoreText;


    private void Awake()
    {
        //score = 0;
        _knifeRD2D = GetComponent<Rigidbody2D>();
        _knifeCollidor2D = GetComponent<BoxCollider2D>();
        _hitSound = GetComponent<AudioSource>();
        _hitParticle = GetComponent<ParticleSystem>();
        
    }

    private void Update()
    {
        //Mobile Version 
        if ((Input.touchCount > 0) && _isHitActive) 
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                if (!_isHit)
                return;

                _isHit = false;
                _knifeRD2D.AddForce(_hitForce,ForceMode2D.Impulse);
                _knifeRD2D.gravityScale = 1;
                GameController.Object.GameMUI.RemoveKnifeCount();
            }
        }

        //Desttop Version
        if (Input.GetMouseButtonDown(0) && _isHitActive)
        {
            if (!_isHit)
               return;
            
            _isHit = false;
            _knifeRD2D.AddForce(_hitForce, ForceMode2D.Impulse);
            _knifeRD2D.gravityScale = 1;
            GameController.Object.GameMUI.RemoveKnifeCount();
        }
        // scoreText.text = "Score : " + score;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_isHitActive)
            return;

        _isHitActive = false;
        if(collision.collider.CompareTag("Wheel"))
        {
            _SCORE++;
            _knifeRD2D.velocity = new Vector2(0,0);
            _knifeRD2D.bodyType = RigidbodyType2D.Kinematic;
            transform.SetParent(collision.collider.transform);
            _hitParticle.Play();
            _hitSound.clip = _hitClip[0];
            _hitSound.Play();

            

            _knifeCollidor2D.offset = new Vector2(_knifeCollidor2D.offset.x , -0.2f);
            _knifeCollidor2D.size = new Vector2(_knifeCollidor2D.size.x, 0.8f);

            GameController.Object.ProperKnifeThrow();
        }
        else if(collision.collider.CompareTag("Knife"))
        {
            _knifeRD2D.velocity = new Vector2(_knifeRD2D.velocity.x, -2);
            

            _hitSound.clip = _hitClip[1];
            _hitSound.Play();
            //GameController._LEVEL = 0;
            GameController.Object.GameOver(false);
            _SCORE = 0;
        } 
    }
}
