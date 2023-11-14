using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour{
    private bool isGameover;
    public Text gameOverText;

    private float numAreaTaken;
    public Text numAreaTakenText;

    public GameObjects[] opponentPrefabs;
    public GameObjects[] spawnPoints;

    public Button startButton;
    public Button restartButton;

    //Audio Soucres can be listed here when it's done.


    void Start(){
        isgameover = false;

        gameOverText.gameObject.SetActive(false);
        numAreaTakenText.gameObject.SetActive(false);

        numAreaTaken = 0;

        startButton.onClick.AddListener(SetGameStart); 
        startButton.gameObject.SetActive(true);
        restartButton.onClick.AddListener(SetGameStart); 
        restartButton.gameObject.SetActive(false);

    }

    private void SetGameStart(){
        isGameover = false;
        numAreaTaken = 0;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //Background controll reset

        startButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        numAreaTakenText.gameObject.SetActive(true);

        SpawnOpponents();
        StartCoroutine(CountAreaTaken());

        //BGM Audio Controll
    }

    private void SetGameOver(bool isGameOver){
        if(isGameOver){
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);

            //gamveOver Audio controll
        }
    }

    private void SpawnOpponents(){ //may be IEnumerator?
        while(!isGameOver){
            /*
            spawnPoints[0] spawns three opponents of opponentPrefabs[0]
            spawnPoints[1] spawns four opponents of opponentPrefabs[1]
            spawnPoints[2] spawns five opponents of opponentPrefabs[2]

            Place each spawnPoint in each area, meaning that each area would have three, four, or five opponents
            */

            for(int i = 0; i < spawnPoints.Length; i++){
                int numberOfOpponents = i + 3;

                for(int j = 0; j < numberOfOpponents; j++){
                    Instantiate(opponentPrefabs[i], spawnPoints[i].position, Quaternion.identity);
                    yield return new WaitForSeconds(0.7f); //spawn inverval; can be adjusted
                }
            }
        }
    }


    IEnumerator CountAreaTaken(){
        while(!isGameover){
            /*
            Count Absorb opponents connecting to collision detection file (absorbing opponents file)
            */
            numAreaTaken++;
        }
    }


    void UpdateCountAreaText(){
        numAreaTakenText.text = "Dominated Areas: " + numAreaTaken.ToString() + " areas";
    }

}