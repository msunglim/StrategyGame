using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSetting : MonoBehaviour
{
    [SerializeField]
    private Sprite sp;

    [SerializeField]
    private Sprite characterProfile;

    private SpriteRenderer spr;

    private int direction;

    [SerializeField]
    private GameObject[] skillList;

    private GameObject currSkill;

    [SerializeField]
    private GameObject minProfile;

    //private GameObject skill1Effect;
    private Animator anime;

    [SerializeField]
    private string characterCode;

    [SerializeField]
    private string characterName;

    private float

            moveDirectionX,
            moveDirectionY,
            adjustedX,
            adjustedY;

    [SerializeField]
    private GameObject characterUlt;

    // Start is called before the first frame update
    void Awake()
    {
        anime = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        spr.sprite = sp;
    }

    void Update()
    {
        if (anime.GetBool(characterCode + "isMove") == true)
        //if(transform.position.x != adjustedX && transform.position.y != adjustedY)
        {
            int speed = (transform.position.x == adjustedX) ? 2 : 5; //2: move vertically 5: move horizontally
            transform.position =
                Vector3
                    .MoveTowards(transform.position,
                    new Vector3(adjustedX, adjustedY, -2),
                    Time.deltaTime * speed);
            if (
                transform.position.x == adjustedX &&
                transform.position.y == adjustedY
            )
            {
                anime.SetBool(characterCode + "isMove", false);
            }
            // transform.position += new Vector3(moveDirectionX, moveDirectionY, 0)* 4* Time.deltaTime;
        }
    }

    public string getCharacterName()
    {
        return characterName;
    }

    public void setAnime(Animator ani)
    {
        anime = ani;
    }

    public Sprite getCharacterProfile()
    {
        return characterProfile;
    }

    public GameObject[] getSkillList()
    {
        return skillList;
    }

    public GameObject getMinProfile()
    {
        return minProfile;
    }

    public void setDirection(int d)
    {
        direction = d;
    }

    //return SKill object for instantiating skill effect in battle field
    public GameObject useSkill(playerControll pc, int skillindex)
    {
        Debug
            .Log("useSkill again..?" +
            anime.GetInteger(characterCode + "useSkill"));

        //use skill if it has enough energy to cast.
        if (
            pc.getEN() >=
            skillList[4 + skillindex].GetComponent<skillManager>().getCost()
        )
        {
            anime.SetInteger(characterCode + "useSkill", skillindex);
            pc
                .setEN(pc.getEN() -
                skillList[4 + skillindex]
                    .GetComponent<skillManager>()
                    .getCost());
            currSkill = skillList[4 + skillindex];
            if (skillindex == 4)
            {
                StartCoroutine(displayUltImage());
            }
            return skillList[4 + skillindex];
        }
        else
        {
            return null;
        }
    }

    private IEnumerator displayUltImage()
    {
        GameObject ult =
            Instantiate(characterUlt,
            new Vector3(-8 *direction, -1, 1),
            Quaternion.identity);
        ult.GetComponent<MoveToDirection>().setDirection(5* direction, 0);
        yield return new WaitForSeconds(1);
        Destroy (ult);
    }

    //animation에서 사용됨
    //go to 1 direction
    public void effect1()
    {
        currSkill
            .GetComponent<skillManager>()
            .effect(direction,
            transform.position.x,
            transform.position.y,
            15,
            0);
    }

    //go to 8 directions
    public void effect2()
    {
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                if (i == 0 && j == 0) continue;
                currSkill
                    .GetComponent<skillManager>()
                    .effect(direction,
                    transform.position.x,
                    transform.position.y,
                    5 * i,
                    5 * j);
            }
        }
    }

    public void effect3()
    {
        currSkill
            .GetComponent<skillManager>()
            .effect(direction,
            transform.position.x,
            transform.position.y + 10,
            0,
            -15);
    }

    public GameObject heal(playerControll pc)
    {
        pc.setEN(pc.getEN() + 15);
        anime.SetBool(characterCode + "isHeal", true);
        return skillList[9];
    }

    public GameObject guard(playerControll pc)
    {
        pc.setDEF(15);
        anime.SetBool(characterCode + "isGuard", true);
        return skillList[4];
    }

    public void getHit()
    {
        anime.SetBool(characterCode + "isHit", true);
    }

    public void die()
    {
        anime.SetBool(characterCode + "isDead", true);
    }

    public Sprite getSprite()
    {
        return sp;
    }

    public void actionComplete()
    {
        anime.SetInteger(characterCode + "useSkill", 0);
        Debug
            .Log("useSkill ..?" + anime.GetInteger(characterCode + "useSkill"));
        anime.SetBool(characterCode + "isHit", false);
        anime.SetBool(characterCode + "isHeal", false);
        anime.SetBool(characterCode + "isGuard", false);
        currSkill = null;
    }

    public void changeDirection()
    {
        direction = -direction;
        transform.Rotate(new Vector3(0, 180, 0));
    }

    //return which direction move is used.
    //aX,aY: destination of character location.
    public GameObject move(float aX, float aY)
    {
        anime.SetBool(characterCode + "isMove", true);
        adjustedX = aX;
        adjustedY = aY;

        float currX = transform.position.x;
        float currY = transform.position.y;

        if (currX == adjustedX)
        {
            if (currY < adjustedY)
            {
                return skillList[0];
            }
            else
            {
                return skillList[1];
            }
        }
        else
        {
            if (currX < adjustedX)
            {
                return skillList[2];
            }
            else
            {
                return skillList[3];
            }
        }
    }
}
