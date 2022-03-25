using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(GameManagerUI))]
public class GameController : MonoBehaviour
{
    public static GameController Object { get; set; }

    [SerializeField] private int _knifeCount;
    private int _minKnifes;
    private int _maxKnifes;
    [SerializeField] private Vector2 _knifePositionSpawn;
    [SerializeField] private GameObject _knifePrefabs;
    public GameManagerUI GameMUI { get; set; }

    public static int _LEVEL = 0;
    private void Awake()
    {
        Object = this;
        GameMUI = GetComponent<GameManagerUI>();
        _minKnifes = 8;
        _maxKnifes = 11;
        _knifeCount = Random.Range(_minKnifes,_maxKnifes);
    }

    private void Start()
    {
        GameMUI.DefaultKnifeCount(_knifeCount);
        KnifeSpawning();
        //_LEVEL = 1;
    }

    public void ProperKnifeThrow()
    {
        if(_knifeCount > 0 )
        {
            KnifeSpawning();
        }
        else if(_knifeCount <= 0)
        {
            GameOver(true);
        }
    }

    private void KnifeSpawning()
    {
        _knifeCount--;
        Instantiate(_knifePrefabs,_knifePositionSpawn,Quaternion.identity);
    }

    public void GameOver(bool won)
    {
        StartCoroutine(StartGameOver(won));
    }

    private IEnumerator StartGameOver(bool won)
    {
        if(won)
        {
            yield return new WaitForSeconds(1.0f);
            _LEVEL++;
            GameRestart();
        }
        else
        {
            _LEVEL = 0;
            GameMUI.GameRestartButton();            
        }
    }

    public void GameRestart()
    {
        SceneManager.LoadScene("FirstScene");
    }
    
    public void GotoHome()
    {
        SceneManager.LoadScene("MainScene");
    }
}
