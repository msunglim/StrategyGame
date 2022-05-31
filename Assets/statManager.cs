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

    private GameObject

            hpBar,
            enBar;

    private float startingX;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.GetChild(0).gameObject;
        player.GetComponent<SpriteRenderer>().sprite =
            (playerNumber == 1)
                ? GameMaster.p1c.getCharacterProfile()
                : GameMaster.p2c.getCharacterProfile();
         player.GetComponent<SpriteRenderer>().transform.localScale = new Vector2(1,1);
        if(playerNumber ==-1){
              player.GetComponent<SpriteRenderer>().transform.Rotate(new Vector3(0, 180, 0));
        }
        defaultSize = 4.5f;
        startingX =
            player.transform.position.x +
            playerNumber *
            player.GetComponent<SpriteRenderer>().bounds.size.x /
            2;

        // transform.position =
        //     new Vector2(startingX + playerNumber * (defaultSize / 2),
        //         transform.position.y);
        if (playerNumber == 1)
        {
            hpBar = transform.GetChild(1).gameObject;
            enBar = transform.GetChild(2).gameObject;
            currentSizeHP = defaultSize * (float)(GameMaster.p1HP / 100.0);
            hpBar.transform.localScale =
                new Vector2(currentSizeHP, hpBar.transform.localScale.y);
            hpBar.transform.position =
                new Vector2(startingX + playerNumber * (currentSizeHP / 2),
                    hpBar.transform.position.y);
            currentSizeEN = defaultSize * (float)(GameMaster.p1EN / 100.0);
            enBar.transform.localScale =
                new Vector2(currentSizeEN, enBar.transform.localScale.y);
            enBar.transform.position =
                new Vector2(startingX + playerNumber * (currentSizeEN / 2),
                    enBar.transform.position.y);
        }
        else
        {
            hpBar = transform.GetChild(1).gameObject;
            enBar = transform.GetChild(2).gameObject;
            currentSizeHP = defaultSize * (float)(GameMaster.p2HP / 100.0);

            hpBar.transform.localScale =
                new Vector2(currentSizeHP, hpBar.transform.localScale.y);
            hpBar.transform.position =
                new Vector2(startingX + playerNumber * (currentSizeHP / 2),
                    hpBar.transform.position.y);
            currentSizeEN = defaultSize * (float)(GameMaster.p2EN / 100.0);
            enBar.transform.localScale =
                new Vector2(currentSizeEN, enBar.transform.localScale.y);
            enBar.transform.position =
                new Vector2(startingX + playerNumber * (currentSizeEN / 2),
                    enBar.transform.position.y);
        }
    }

    public void updateHPbar(int newHP)
    {
        currentSizeHP = defaultSize * (float)(newHP / 100.0);
        transform.GetChild(1).transform.localScale =
            new Vector2(currentSizeHP, gameObject.transform.localScale.y);
        transform.GetChild(1).transform.position =
            new Vector2(startingX + playerNumber * (currentSizeHP / 2),
                transform.GetChild(1).transform.position.y);
    }

    public void updateENbar(int newEN)
    {
        currentSizeEN = defaultSize * (float)(newEN / 100.0);
        transform.GetChild(2).transform.localScale =
            new Vector2(currentSizeEN,
                transform.GetChild(2).transform.localScale.y);
        transform.GetChild(2).transform.position =
            new Vector2(startingX + playerNumber * (currentSizeEN / 2),
                transform.GetChild(2).transform.position.y);
    }
}
