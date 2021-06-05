using UnityEngine;

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

        animator.Play("Walk", 0, Random.Range(0f, 1f));
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
