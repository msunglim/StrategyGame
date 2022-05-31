using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//actually FieldManager would be more appropriate name.
public class FieldGenerator : MonoBehaviour
{
    //'field' is a cell of field
    [SerializeField]
    private GameObject field;

    [SerializeField]
    private GameObject player1;

    [SerializeField]
    private GameObject player2;

    //this is the clone of player 1 and 2 that are actually shown in the screen.
    //to control players, we need to use this objects.
    private GameObject p1;

    private GameObject p2;

    //list is consisted of 'field' which is a cell.
    private GameObject[,] list = new GameObject[3, 4];

    private float[]

            x,
            y;

    //player.GetComponent<playerControll>();
    private playerControll

            p1controll,
            p2controll;

    //true if p1 -> <- p2. false if p2 -> <-p1.
    private bool crossDirection;

    void Start()
    {
        crossDirection = false;
        x = new float[] { -4.5f, -1.5f, 1.5f, 4.5f };
        y = new float[] { 0.0f, -1.3f, -2.6f };

        //+-0.5f is to adjust player image and field.
        GameObject player1Character =
            player1.GetComponent<playerControll>().getCharacter();
        p1 =
            Instantiate(player1Character,
            new Vector3(x[GameMaster.p1x] - 0.5f, y[GameMaster.p1y] + 0.8f, -2),
            Quaternion.identity);
        p1controll = player1.GetComponent<playerControll>();
      
        p1controll.setXY(GameMaster.p1x, GameMaster.p1y);
        p1controll.setHP(GameMaster.p1HP);
        p1controll.setEN(GameMaster.p1EN);
        p1controll.setDEF(0);
        p1.GetComponent<characterSetting>().setDirection(1);

        GameObject player2Character =
            player2.GetComponent<playerControll>().getCharacter();
        p2 =
            Instantiate(player2Character,
            new Vector3(x[GameMaster.p2x] + 0.5f, y[GameMaster.p2y] + 0.8f, -2),
            Quaternion.identity);
        p2controll = player2.GetComponent<playerControll>();
        p2controll.setXY(GameMaster.p2x, GameMaster.p2y);
        p2controll.setHP(GameMaster.p2HP);
        p2controll.setDEF(0);
        p2controll.setEN(GameMaster.p2EN);
        p2.GetComponent<characterSetting>().setDirection(-1);
        p2.transform.Rotate(new Vector3(0, 180, 0));

        //this will allow other scenes to get min profile of players.
        // GameMaster.p1c = p1controll;
        // GameMaster.p2c = p2controll;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                GameObject clone =
                    Instantiate(field,
                    new Vector3(x[j], y[i], -1),
                    Quaternion.identity);
                list[i, j] = clone;
            }
        }
    }

    private void movePlayer(float endX, float endY, GameObject player)
    {
        float adjustedX = (player == p1) ? endX - 0.5f : endX + 0.5f;
        float adjustedY = endY + 0.8f;

        GameObject skill =
            p1.GetComponent<characterSetting>().move(adjustedX, adjustedY);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            GameObject skill =
                p1.GetComponent<characterSetting>().guard(p1controll);
        }
        if (Input.GetKeyDown("s"))
        {
            GameObject skill =
                p1.GetComponent<characterSetting>().heal(p1controll);
              updatePlayerInfoBar(p1controll, 0 , false);    
        }
        if (Input.GetKeyDown("d"))
        {
            GameObject skill =
                p1.GetComponent<characterSetting>().useSkill(p1controll,1);
            if (skill != null)
            {
                int[] targetArea =
                    skill.GetComponent<skillManager>().getTargetArea();
                StartCoroutine(applyAttackSkill(skill,
                targetArea,
                p1controll,
                p2controll));
                StartCoroutine(endPhase(p1.GetComponent<characterSetting>(),
                p2.GetComponent<characterSetting>()));
            }
        }
        if (Input.GetKeyDown("g"))
        {
            GameObject skill =
                p1.GetComponent<characterSetting>().useSkill(p1controll,2);
            if (skill != null)
            {
                int[] targetArea =
                    skill.GetComponent<skillManager>().getTargetArea();
                StartCoroutine(applyAttackSkill(skill,
                targetArea,
                p1controll,
                p2controll));
                StartCoroutine(endPhase(p1.GetComponent<characterSetting>(),
                p2.GetComponent<characterSetting>()));
            }
        }
         if (Input.GetKeyDown("h"))
        {
            GameObject skill =
                p1.GetComponent<characterSetting>().useSkill(p1controll,3);
            if (skill != null)
            {
                int[] targetArea =
                    skill.GetComponent<skillManager>().getTargetArea();
                StartCoroutine(applyAttackSkill(skill,
                targetArea,
                p1controll,
                p2controll));
                StartCoroutine(endPhase(p1.GetComponent<characterSetting>(),
                p2.GetComponent<characterSetting>()));
            }
        }
         if (Input.GetKeyDown("j"))
        {
            GameObject skill =
                p1.GetComponent<characterSetting>().useSkill(p1controll,4);
            if (skill != null)
            {
                int[] targetArea =
                    skill.GetComponent<skillManager>().getTargetArea();
                StartCoroutine(applyAttackSkill(skill,
                targetArea,
                p1controll,
                p2controll));
                StartCoroutine(endPhase(p1.GetComponent<characterSetting>(),
                p2.GetComponent<characterSetting>()));
            }
        }
        if (Input.GetKeyDown("f"))
        {
            // p2.GetComponent<characterSetting>().useSkill1();
            GameObject skill =
                p2.GetComponent<characterSetting>().useSkill(p2controll, 1);
            if (skill != null)
            {
                int[] targetArea =
                    skill.GetComponent<skillManager>().getTargetArea();
                StartCoroutine(applyAttackSkill(skill,
                targetArea,
                p2controll,
                p1controll));
                StartCoroutine(endPhase(p1.GetComponent<characterSetting>(),
                p2.GetComponent<characterSetting>()));
            }
        }
        int p1X = p1controll.getX();
        int p1Y = p1controll.getY();
        int p2X = p2controll.getX();
        int p2Y = p2controll.getY();

        //currently only can move player 1.
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            p1controll.moveLeft();
            movePlayer(x[p1controll.getX()], y[p1controll.getY()], p1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            p1controll.moveRight();
            movePlayer(x[p1controll.getX()], y[p1controll.getY()], p1);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            p1controll.moveUp();
            movePlayer(x[p1controll.getX()], y[p1controll.getY()], p1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            p1controll.moveDown();
            movePlayer(x[p1controll.getX()], y[p1controll.getY()], p1);
        }

        if ((crossDirection && p1X <= p2X) || (!crossDirection && p1X > p2X))
        {
            p1.GetComponent<characterSetting>().changeDirection();
            p2.GetComponent<characterSetting>().changeDirection();
            crossDirection = !crossDirection;
        }
    }

    //show targeted area in red for 0.xf second, and change its color back to white.
    //if an opponent player(pc2) is located in the area, then apply the skill effect to it.
    //pc1: the player who casts its skill
    //pc2: the opponent of player who casts its skill
    private IEnumerator
    applyAttackSkill(
        GameObject skill,
        int[] targetArea,
        playerControll pc1,
        playerControll pc2
    )
    {
        List<int[]> coordinateList = new List<int[]>();
        for (int i = 0; i < targetArea.Length; i++)
        {
            int x = pc1.getX();
            int y = pc1.getY();
            try
            {
                switch (targetArea[i])
                {
                    case 0:
                        list[y - 1, x - 1]
                            .GetComponent<SpriteRenderer>()
                            .color = new Color(255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y - 1, x - 1 });
                        break;
                    case 1:
                        list[y - 1, x].GetComponent<SpriteRenderer>().color =
                            new Color(255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y - 1, x });
                        break;
                    case 2:
                        list[y - 1, x + 1]
                            .GetComponent<SpriteRenderer>()
                            .color = new Color(255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y - 1, x + 1 });
                        break;
                    case 3:
                        list[y, x - 1].GetComponent<SpriteRenderer>().color =
                            new Color(255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y, x - 1 });
                        break;
                    case 4:
                        list[y, x].GetComponent<SpriteRenderer>().color =
                            new Color(255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y, x });
                        break;
                    case 5:
                        list[y, x + 1].GetComponent<SpriteRenderer>().color =
                            new Color(255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y, x + 1 });
                        break;
                    case 6:
                        list[y + 1, x - 1]
                            .GetComponent<SpriteRenderer>()
                            .color = new Color(255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y + 1, x - 1 });
                        break;
                    case 7:
                        list[y + 1, x].GetComponent<SpriteRenderer>().color =
                            new Color(255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y + 1, x });
                        break;
                    case 8:
                        list[y + 1, x + 1]
                            .GetComponent<SpriteRenderer>()
                            .color = new Color(255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y + 1, x + 1 });
                        break;
                }
            }
            catch (System.Exception ex)
            {
                //if targeted area of skill is out of field.
                Debug.Log (ex);
                //it's ok to have outofrange exception.
            }
        }

        //return the cell color to its original state.
        yield return new WaitForSeconds(0.5f);

        int opponentX = pc2.getX();
        int opponentY = pc2.getY();

        for (int j = 0; j < coordinateList.Count; j++)
        {
            //skillXY: where skill lands, opponextXY
            int[] cell = coordinateList[j];
            int skillX = cell[1];
            int skillY = cell[0];

            GameObject playerInfo = GameObject.Find("PlayerInfo");
            // GameObject playerInfo = GameMaster.gameObject;
            //update EN bar of a skill caster.
            //p2는 피격자다. 피격자가 p2가 아닐경우에는 p2가 스킬시전자란소리.
            int playerCode2 = (pc2 != p2controll) ? 1 : 0;
            updatePlayerInfoBar(pc1, playerCode2, false);
            // GameObject casterEN =
            //     playerInfo.transform.GetChild(playerCode2).gameObject;
            // casterEN
            //     .transform
            //     .GetChild(2)
            //     .GetComponent<statManager>()
            //     .updateENbar(pc1.getEN());

            //if opponent is located in targeted area, reduce its hp by skill damage.
            if (skillX == opponentX && skillY == opponentY)
            {
                pc2
                    .setHP((pc2.getHP() + pc2.getDEF()) -
                    skill.GetComponent<skillManager>().getDamage());

                //update HP bar of opponent of a skill caster.
                int playerCode = (pc2 == p2controll) ? 1 : 0;
                updatePlayerInfoBar(pc2, playerCode, true);
                // GameObject opponentHP =
                //     playerInfo.transform.GetChild(playerCode).gameObject;
                // opponentHP
                //     .transform
                //     .GetChild(1)
                //     .GetComponent<statManager>()
                //     .updateHPbar(pc2.getHP());

                //가드일경우 하지않는다!
                //player 1 is hit by the skill
                if (playerCode == 0)
                {
                    p1.GetComponent<characterSetting>().getHit();
                }
                else
                {
                    p2.GetComponent<characterSetting>().getHit();
                }
            }

            //return the color of cell to white.
            list[skillY, skillX].GetComponent<SpriteRenderer>().color =
                new Color(255, 255, 255, 0.5f);
        }
    }

    private void updatePlayerInfoBar(
        playerControll pc,
        int playerCode,
        bool updateHP
    )
    {
        GameObject playerInfo = GameObject.Find("PlayerInfo");

        //update EN bar of a skill caster.
        //int playerCode2 = (pc != p2controll) ? 1 : 0;
        if (updateHP)
        {
            // GameObject opponentHP =
                playerInfo.transform.GetChild(playerCode).GetComponent<statManager>().updateHPbar(pc.getHP());
                //실제로는 playerInfo.transform.GetChild(playerCode).gameObject .transform.GetChild(1) 이 opponent HP다.
            // opponentHP
            //     .transform
            //     .GetChild(1)
            //     .GetComponent<statManager>()
            //     .updateHPbar(pc.getHP());
        }
        else
        {
              playerInfo.transform.GetChild(playerCode).GetComponent<statManager>().updateENbar(pc.getEN());
            // GameObject casterEN =
            //     playerInfo.transform.GetChild(playerCode).gameObject;
            // casterEN
            //     .transform
            //     .GetChild(2)
            //     .GetComponent<statManager>()
            //     .updateENbar(pc.getEN());
        }
    }

    //exeucte this code after any attack skill executes.
    //if player's hp is less or equal to zero, it dies.
    private IEnumerator endPhase(characterSetting p1, characterSetting p2)
    {
        yield return new WaitForSeconds(0.5f);
        if (p1controll.getHP() <= 0)
        {
            p1.die();
        }
        if (p2controll.getHP() <= 0)
        {
            p2.die();
        }
    }
}
