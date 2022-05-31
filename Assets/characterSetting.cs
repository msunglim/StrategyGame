using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSetting : MonoBehaviour
{
    [SerializeField]
    private Sprite sp;

    private SpriteRenderer spr;

    private int direction;

    [SerializeField]
    private GameObject[] skillList;

    private GameObject currSkill;

    [SerializeField]
    private GameObject minProfile;

    //private GameObject skill1Effect;
    private Animator anime;

    private float

            moveDirectionX,
            moveDirectionY,
            adjustedX,
            adjustedY;

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        spr.sprite = sp;
    }

    void Update()
    {
        if (anime.GetBool("isMove") == true)
        //if(transform.position.x != adjustedX && transform.position.y != adjustedY)
        {
            transform.position =
                Vector3
                    .MoveTowards(transform.position,
                    new Vector3(adjustedX, adjustedY, -2),
                    Time.deltaTime * 5);
            if (
                transform.position.x == adjustedX &&
                transform.position.y == adjustedY
            )
            {
                anime.SetBool("isMove", false);
            }
            // transform.position += new Vector3(moveDirectionX, moveDirectionY, 0)* 4* Time.deltaTime;
        }
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
        //use skill if it has enough energy to cast.
        if (
            pc.getEN() >=
            skillList[4 + skillindex].GetComponent<skillManager>().getCost()
        )
        {
            anime.SetInteger("useSkill", skillindex);
            pc
                .setEN(pc.getEN() -
                skillList[4 + skillindex]
                    .GetComponent<skillManager>()
                    .getCost());
            currSkill = skillList[4 + skillindex];
            return skillList[4 + skillindex];
        }
        else
        {
            return null;
        }
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
        anime.SetBool("isHeal", true);
        return skillList[9];
    }

    public GameObject guard(playerControll pc)
    {
        //Debug.Log("pc def"+pc.getDEF());
        pc.setDEF(15);
        anime.SetBool("isGuard", true);
        return skillList[4];
    }

    public void getHit()
    {
        anime.SetBool("isHit", true);
    }

    public void standBack()
    {
        anime.SetBool("isHit", false);
        anime.SetBool("isHeal", false);
        currSkill = null;
    }

    public void die()
    {
        anime.SetBool("isDead", true);
    }

    public Sprite getSprite()
    {
        return sp;
    }

    public void actionComplete()
    {
        Debug.Log("..");
        anime.SetInteger("useSkill", 0);
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
        anime.SetBool("isMove", true);
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
