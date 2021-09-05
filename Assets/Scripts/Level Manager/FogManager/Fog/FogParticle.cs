using UnityEngine;

public class FogParticle : MonoBehaviour
{
    SpriteRenderer render;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        animator.Play(state.fullPathHash, -1, Random.Range(0f, 1f));
        Color temp = render.color;
        temp.a = 0.5f;
        render.color = temp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
