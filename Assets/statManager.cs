using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statManager : MonoBehaviour
{
    //used to adjust PlayerInfo panel.
    [SerializeField]
    private float playerNumber; //player 1:1, 2:-1

    private float defaultSize;

    private float currentSizeHP;

    private float currentSizeEN;

    private float startingX;

    [SerializeField]
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        defaultSize = 4.5f;
        startingX =
            player.transform.position.x +
            playerNumber *
            player.GetComponent<SpriteRenderer>().bounds.size.x /
            2;
        gameObject.transform.position =
            new Vector2(startingX + playerNumber * (defaultSize / 2),
                gameObject.transform.position.y);

        if (playerNumber == 1)
        {
            currentSizeHP = defaultSize * (float)(GameMaster.p1HP / 100.0);
            gameObject.transform.localScale =
                new Vector2(currentSizeHP, gameObject.transform.localScale.y);
            gameObject.transform.position =
                new Vector2(startingX + playerNumber * (currentSizeHP / 2),
                    gameObject.transform.position.y);
            currentSizeEN = defaultSize * (float)(GameMaster.p1EN / 100.0);
            gameObject.transform.localScale =
                new Vector2(currentSizeEN, gameObject.transform.localScale.y);
            gameObject.transform.position =
                new Vector2(startingX + playerNumber * (currentSizeEN / 2),
                    gameObject.transform.position.y);
        }
        else
        {
            currentSizeHP = defaultSize * (float)(GameMaster.p2HP / 100.0);
            gameObject.transform.localScale =
                new Vector2(currentSizeHP, gameObject.transform.localScale.y);
            gameObject.transform.position =
                new Vector2(startingX + playerNumber * (currentSizeHP / 2),
                    gameObject.transform.position.y);
            currentSizeEN = defaultSize * (float)(GameMaster.p2EN / 100.0);
            gameObject.transform.localScale =
                new Vector2(currentSizeEN, gameObject.transform.localScale.y);
            gameObject.transform.position =
                new Vector2(startingX + playerNumber * (currentSizeEN / 2),
                    gameObject.transform.position.y);
        }
    }

    public void updateHPbar(int newHP)
    {
        currentSizeHP = defaultSize * (float)(newHP / 100.0);
        gameObject.transform.localScale =
            new Vector2(currentSizeHP, gameObject.transform.localScale.y);
        gameObject.transform.position =
            new Vector2(startingX + playerNumber * (currentSizeHP / 2),
                gameObject.transform.position.y);
    }

    public void updateENbar(int newEN)
    {
        currentSizeEN = defaultSize * (float)(newEN / 100.0);
        gameObject.transform.localScale =
            new Vector2(currentSizeEN, gameObject.transform.localScale.y);
        gameObject.transform.position =
            new Vector2(startingX + playerNumber * (currentSizeEN / 2),
                gameObject.transform.position.y);
    }
}
