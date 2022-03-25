using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManagerUI : MonoBehaviour
{
    [SerializeField] private GameObject _knifeStore;
    [SerializeField] private GameObject _knifeIcon;
    [SerializeField] private Color baseKnifeColor;

    [SerializeField] private GameObject[] _uiButton;

    [SerializeField] private Text _knifeScore;
    [SerializeField] private Text _level;
    private void Start()
    {
        _uiButton[0].SetActive(false);
        _uiButton[1].SetActive(false);
        _uiButton[2].SetActive(true);
    }

    private void Update()
    {
        _knifeScore.text = "Score : " + KnifeThrow._SCORE.ToString();
        _level.text = "Level : " + GameController._LEVEL.ToString();
    }

    public void DefaultKnifeCount(int count)
    {
        for(int i=0; i<count; i++)
        {
            Instantiate(_knifeIcon,_knifeStore.transform);
        }
    }

    

    private int _knifeIconIndex = 0;
    public void RemoveKnifeCount()
    {
        _knifeStore.transform.GetChild(_knifeIconIndex++).GetComponent<Image>().color = baseKnifeColor;
    }


    public void GameRestartButton()
    {
        _uiButton[0].SetActive(true);
        _uiButton[1].SetActive(true);
        _uiButton[2].SetActive(false);
    }
    public void GoHome()
    {
        GameController._LEVEL = 0;
        KnifeThrow._SCORE = 0;
        SceneManager.LoadScene("MainScene");
    }

}
