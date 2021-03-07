using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OilMonsterAnimation : MonoBehaviour
{
    OilMonster oilMonsterM;
    Animator animator;
    SpriteRenderer render;
    [SerializeField] float relativeStart;
    [SerializeField] float relativeEnd;
    // Start is called before the first frame update
    void Start()
    {
        oilMonsterM = GetComponent<OilMonster>();
        animator = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        flipX();
        setAnimationParameters();
    }

    public bool isInActiveCrawl()
    {
        float length;
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        length = state.normalizedTime % 1;

        if (state.IsName("Walk") && length > relativeStart && length < relativeEnd)
        { 
            return true;
        }
        return false;
    }

    void flipX()
    {
        float direction = Mathf.Sign(oilMonsterM.getTargetPosition().x - transform.position.x);

        if (direction == -1)
            render.flipX = true;
        else
            render.flipX = false;
    }

    void setAnimationParameters()
	{
        animator.SetBool("Agroed", oilMonsterM.isAgroed());
        animator.SetBool("IsHurt", oilMonsterM.isHurt());
	}
}
