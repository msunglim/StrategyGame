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
    GameObject[,] list = new GameObject[3, 4];

    //player.GetComponent<playerControll>();
    private playerControll p1controll, p2controll;
    private float[] x, y;
    //true if p1 -> <- p2. false if p2 -> <-p1.
    private bool crossDirection;
    void Start()
    {
        crossDirection = false;
        x = new float[] { -4.5f, -1.5f, 1.5f, 4.5f };
        y = new float[] { 0.0f, -1.3f, -2.6f };
        //+-0.5f is to adjust player image and field.

        GameObject player1Character = player1.GetComponent<playerControll>().getCharacter();
        p1 = Instantiate(player1Character, new Vector3(x[0] - 0.5f, y[1] + 0.8f, -2), Quaternion.identity);
        p1controll = player1.GetComponent<playerControll>();
        p1controll.setXY(0, 1);
        p1.GetComponent<characterSetting>().setDirection(1);

        GameObject player2Character = player2.GetComponent<playerControll>().getCharacter();
        p2 = Instantiate(player2Character, new Vector3(x[1] + 0.5f, y[1] + 0.8f, -2), Quaternion.identity);
        p2controll = player2.GetComponent<playerControll>();
        p2controll.setXY(1, 1);
        p2.GetComponent<characterSetting>().setDirection(-1);
        p2.transform.Rotate(new Vector3(0, 180, 0));
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                GameObject clone = Instantiate(field, new Vector3(x[j], y[i], -1), Quaternion.identity);
                list[i, j] = clone;
            }

        }


    }
    private void movePlayer(float inputX, float inputY, GameObject player)
    {
        float adjustedX = (player == p1) ? inputX - 0.5f : inputX + 0.5f;
        float adjustedY = inputY + 0.8f;
        player.transform.position = new Vector3(adjustedX, adjustedY, -2);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("d"))
        {
            GameObject skill = p1.GetComponent<characterSetting>().useSkill1(p1controll);
            if (skill != null)
            {
                int[] targetArea = skill.GetComponent<skillManager>().getTargetArea();
                StartCoroutine(applyAttackSkill(skill, targetArea, p1controll, p2controll));
                StartCoroutine(endPhase(p1.GetComponent<characterSetting>(), p2.GetComponent<characterSetting>()));
            }

        }
        if (Input.GetKeyDown("f"))
        {
            // p2.GetComponent<characterSetting>().useSkill1();
            GameObject skill = p2.GetComponent<characterSetting>().useSkill1(p2controll);
            if (skill != null)
            {
                int[] targetArea = skill.GetComponent<skillManager>().getTargetArea();
                StartCoroutine(applyAttackSkill(skill, targetArea, p2controll, p1controll));
                StartCoroutine(endPhase(p1.GetComponent<characterSetting>(), p2.GetComponent<characterSetting>()));
            }

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            p1controll.moveLeft();
            movePlayer(x[p1controll.getX()], y[p1controll.getY()], p1);
            // p1.transform.position = new Vector3(x[p1controll.getX()], y[p1controll.getY()], -2);

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


        int p1x = p1controll.getX();
        int p2x = p2controll.getX();
        if ((crossDirection && p1x <= p2x) || (!crossDirection && p1x > p2x))
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
    private IEnumerator applyAttackSkill(GameObject skill, int[] targetArea, playerControll pc1, playerControll pc2)
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
                        list[y - 1, x - 1].GetComponent<SpriteRenderer>().color = new Color (255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y - 1, x - 1 });
                        break;
                    case 1:
                        list[y - 1, x].GetComponent<SpriteRenderer>().color =new Color (255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y - 1, x });
                        break;
                    case 2:
                        list[y - 1, x + 1].GetComponent<SpriteRenderer>().color =new Color (255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y - 1, x + 1 });
                        break;
                    case 3:
                        list[y, x - 1].GetComponent<SpriteRenderer>().color = new Color (255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y, x - 1 });
                        break;
                    case 4:
                        list[y, x].GetComponent<SpriteRenderer>().color = new Color (255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y, x });
                        break;
                    case 5:
                        list[y, x + 1].GetComponent<SpriteRenderer>().color = new Color (255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y, x + 1 });
                        break;
                    case 6:
                        list[y + 1, x - 1].GetComponent<SpriteRenderer>().color =new Color (255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y + 1, x - 1 });
                        break;
                    case 7:
                        list[y + 1, x].GetComponent<SpriteRenderer>().color = new Color (255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y + 1, x });
                        break;
                    case 8:
                        list[y + 1, x + 1].GetComponent<SpriteRenderer>().color = new Color (255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y + 1, x + 1 });
                        break;
                }

            }
            catch (System.Exception ex)
            {
                Debug.Log(ex);
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
            //update EN bar of a skill caster.           
            int playerCode2 = (pc2 != p2controll) ? 1 : 0;
            GameObject casterEN = playerInfo.transform.GetChild(playerCode2).gameObject;
            casterEN.transform.GetChild(2).GetComponent<statManager>().updateENbar(pc1.getEN());



            //if opponent is located in targeted area, reduce its hp by skill damage.
            if (skillX == opponentX && skillY == opponentY)
            {
                pc2.setHP(pc2.getHP() - skill.GetComponent<skillManager>().getDamage());

                //update HP bar of opponent of a skill caster.
                int playerCode = (pc2 == p2controll) ? 1 : 0;
                GameObject opponentHP = playerInfo.transform.GetChild(playerCode).gameObject;
                opponentHP.transform.GetChild(1).GetComponent<statManager>().updateHPbar(pc2.getHP());
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
            list[skillY, skillX].GetComponent<SpriteRenderer>().color = new Color (255, 255, 255, 0.5f);
        }
        Debug.Log("p1 " + GameMaster.p1HP + "P2" + GameMaster.p2HP);
    }
    //exeucte this code after any attack skill executes.
    //if player's hp is less or equal to zero, it dies.
    private IEnumerator endPhase(characterSetting p1, characterSetting p2)
    {
        yield return new WaitForSeconds(0.5f);
         Debug.Log("ENDPHAS Ep1 " + GameMaster.p1HP + "," +p1controll.getHP() + "P2" + GameMaster.p2HP + ", "+p2controll.getHP());
        if (GameMaster.p1HP <= 0)
        {
            p1.die();
        }
        if (GameMaster.p2HP <= 0)
        {
            p2.die();
        }

    }
}
