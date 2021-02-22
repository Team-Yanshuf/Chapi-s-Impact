using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OilMonsterAnimation : MonoBehaviour
{
    OilMonster monsterM;
    Animator animator;
    SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        monsterM = GetComponent<OilMonster>();
        animator = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        flipX();
    }

    public bool isInActiveCrawl()
    {
        float length, start = 0.3f, end = 0.7f;
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        length = state.normalizedTime % 1;

        if (state.IsName("Walk") && length > start && length < end)
        { 
            return true;
        }
        return false;
    }

    void flipX()
    {
        float direction = Mathf.Sign(monsterM.getTargetPosition().x - transform.position.x);

        if (direction == -1)
            render.flipX = true;
        else
            render.flipX = false;
            

    }
}
