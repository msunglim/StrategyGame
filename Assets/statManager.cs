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

    private bool updateBar;

    private float

            adjustedX,
            adjustedY;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.GetChild(0).gameObject;
        player.GetComponent<SpriteRenderer>().sprite =
            (playerNumber == 1)
                ? GameMaster.p1c.getCharacterProfile()
                : GameMaster.p2c.getCharacterProfile();
        player.GetComponent<SpriteRenderer>().transform.localScale =
            new Vector2(1.05f, 1.05f);

        if (playerNumber == -1)
        {
            player
                .GetComponent<SpriteRenderer>()
                .transform
                .Rotate(new Vector3(0, 180, 0));
        }
        defaultSize = 4.5f;
        startingX =
            player.transform.position.x +
            playerNumber *
            player.GetComponent<SpriteRenderer>().bounds.size.x /
            2;

        if (playerNumber == 1)
        {
            hpBar = transform.GetChild(1).gameObject;
            enBar = transform.GetChild(2).gameObject;
            currentSizeHP = defaultSize * (float)(GameMaster.p1HP / 100.0);
            hpBar.transform.localScale =
                new Vector2(currentSizeHP, hpBar.transform.localScale.y);
            hpBar.transform.position =
                new Vector3(startingX + playerNumber * (currentSizeHP / 2),
                    hpBar.transform.position.y, hpBar.transform.position.z);
            currentSizeEN = defaultSize * (float)(GameMaster.p1EN / 100.0);
            enBar.transform.localScale =
                new Vector2(currentSizeEN, enBar.transform.localScale.y);
            enBar.transform.position =
                new Vector3(startingX + playerNumber * (currentSizeEN / 2),
                    enBar.transform.position.y , enBar.transform.position.z);
        }
        else
        {
            hpBar = transform.GetChild(1).gameObject;
            enBar = transform.GetChild(2).gameObject;
            currentSizeHP = defaultSize * (float)(GameMaster.p2HP / 100.0);

            hpBar.transform.localScale =
                new Vector2(currentSizeHP, hpBar.transform.localScale.y);
            hpBar.transform.position =
                new Vector3(startingX + playerNumber * (currentSizeHP / 2),
                    hpBar.transform.position.y, hpBar.transform.position.z);
            currentSizeEN = defaultSize * (float)(GameMaster.p2EN / 100.0);
            enBar.transform.localScale =
                new Vector2(currentSizeEN, enBar.transform.localScale.y);
            enBar.transform.position =
                new Vector3(startingX + playerNumber * (currentSizeEN / 2),
                    enBar.transform.position.y, enBar.transform.position.z);
        }
    }

    public void updateHPbar(int newHP)
    {
        currentSizeHP = defaultSize * (float)(newHP / 100.0);
        updateBar = true;

        transform.GetChild(3).GetComponent<TMPro.TextMeshPro>().text =
            "HP" + newHP;
    }

    public void updateENbar(int newEN)
    {
        currentSizeEN = defaultSize * (float)(newEN / 100.0);
        updateBar = true;

        transform.GetChild(4).GetComponent<TMPro.TextMeshPro>().text =
            "EN" + newEN;
    }

    void Update()
    {
        if (updateBar)
        {
            int newHP = (playerNumber == 1) ? GameMaster.p1HP : GameMaster.p2HP;

            transform.GetChild(1).transform.localScale =
                Vector3
                    .Lerp(transform.GetChild(1).transform.localScale,
                    new Vector2(defaultSize * (float)(newHP / 100.0), 1),
                    2 * Time.deltaTime);
            transform.GetChild(1).transform.position =
                new Vector3(startingX +
                    playerNumber * (defaultSize * (float)(newHP / 100.0) / 2),
                    transform.GetChild(1).transform.position.y, transform.GetChild(1).transform.position.z);

            //EN update
            int newEN = (playerNumber == 1) ? GameMaster.p1EN : GameMaster.p2EN;
            transform.GetChild(2).transform.localScale =
                Vector3
                    .Lerp(transform.GetChild(2).transform.localScale,
                    new Vector2(defaultSize * (float)(newEN / 100.0), 1),
                    2 * Time.deltaTime);

            transform.GetChild(2).transform.position =
                new Vector3(startingX +
                    playerNumber * (defaultSize * (float)(newEN / 100.0) / 2),
                    transform.GetChild(2).transform.position.y, transform.GetChild(2).transform.position.z);

            if (
                (
                Mathf.Round(transform.GetChild(1).transform.localScale.x * 10) *
                0.1f ==
                Mathf.Round(defaultSize * (float)(newHP / 100.0) * 10) * 0.1f
                ) &&
                (
                Mathf.Round(transform.GetChild(2).transform.localScale.x * 10) *
                0.1f ==
                Mathf.Round(defaultSize * (float)(newEN / 100.0) * 10) * 0.1f
                )
            )
            {
                updateBar = false;
            }
        }
    }
}
