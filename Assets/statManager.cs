using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statManager : MonoBehaviour
{
    [SerializeField]
    private float playerNumber; //player 1:1, 2:-1

    private float defaultSize;
    private float currentSize;
    private float startingX;

    [SerializeField]
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        defaultSize = 4.5f;
        currentSize= defaultSize;
        startingX = player.transform.position.x + playerNumber * player.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        gameObject.transform.position = new Vector2(startingX + playerNumber * (defaultSize / 2), gameObject.transform.position.y);
        if (playerNumber == -1)
        {
            PlayerPrefs.SetInt("player1HP", 100);
        }
        else
        {
            PlayerPrefs.SetInt("player2HP", 100);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a") && playerNumber == 1)
        {
            defaultSize -= 0.5f;
            // player.GetComponent<characterInfo>().setHP(player.GetComponent<characterInfo>().getHP() - 10);
            gameObject.transform.localScale = new Vector2(defaultSize, gameObject.transform.localScale.y);
            gameObject.transform.position = new Vector2(startingX + playerNumber * (defaultSize / 2), gameObject.transform.position.y);
            int p1HP = PlayerPrefs.GetInt("player1HP");
            PlayerPrefs.SetInt("player1HP", p1HP - 10);

        }
        else if (Input.GetKeyDown("s") && playerNumber == -1)
        {
            defaultSize -= 0.5f;
            // player.GetComponent<characterInfo>().setHP(player.GetComponent<characterInfo>().getHP() - 10);
            gameObject.transform.localScale = new Vector2(defaultSize, gameObject.transform.localScale.y);
            gameObject.transform.position = new Vector2(startingX + playerNumber * (defaultSize / 2), gameObject.transform.position.y);
            int p2HP = PlayerPrefs.GetInt("player2HP");
            PlayerPrefs.SetInt("player2HP", p2HP - 10);
        }
    }
    public void updateHPbar(int newHP)
    {
        currentSize = defaultSize * (float)(newHP / 100.0);
        // player.GetComponent<characterInfo>().setHP(player.GetComponent<characterInfo>().getHP() - 10);
        gameObject.transform.localScale = new Vector2(currentSize, gameObject.transform.localScale.y);
        gameObject.transform.position = new Vector2(startingX + playerNumber * (currentSize / 2), gameObject.transform.position.y);
        // int p1HP = PlayerPrefs.GetInt("player1HP");
        // PlayerPrefs.SetInt("player1HP", p1HP - 10);
    }
}
