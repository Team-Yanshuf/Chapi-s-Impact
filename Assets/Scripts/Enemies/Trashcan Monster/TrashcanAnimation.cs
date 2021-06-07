using System.Collections;
using UnityEngine;

public class TrashcanAnimation : MonoBehaviour
{
    Trashcan trashM;
    Animator animator;
    SpriteRenderer renderer;

    [SerializeField] bool enableAnimation;

    void Start()
    {
        trashM = GetComponent<Trashcan>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        trashM.addJumpEventListener(haltAnimation);
        trashM.addLandEventListener(resumeAnimation);

        animator.Play("TrashJump", 0, Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
       // if (enableAnimation)
            setParameters();

        setLookDirection();

    }

    void setParameters()
	{
        animator.SetBool("Attacking", trashM.isAttacking());
        bool isHurt  = trashM.isHurt();
        if (isHurt)
		{
            StartCoroutine(colorRed());
		}
        //animator.SetBool("IsHurt", isHurt);


        //animator.SetBool("isMoving", trashM.isMoving());
	}


    IEnumerator colorRed()
	{
        Color origin = renderer.color;
        Color dest = new Color(120f, 0, 0);

        renderer.color = dest;

        float interpolator = 0f;
        for (int i=0; i<50; i++)
		{
            renderer.color = Color.Lerp(dest, origin, interpolator);
            interpolator += 0.02f;
            yield return null;
		}
	}

    void setLookDirection()
    {
        float direction = trashM.getLookDirection();

        if (direction > 0)
            renderer.flipX = false;

        else if (direction < 0)
            renderer.flipX = true;

    }

    void haltAnimation()
    { 
        animator.speed = 0;
    }

    void resumeAnimation()
    {
        animator.speed = 1;
    }

}
