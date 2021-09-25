using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    int health;
    Player player;
    Image image;
    float interpolator;
    Vector3 target;
    Vector3 initial;
    void Start()
    {
        //InitSelf();
    }
    
    public void InitSelf()
	{
        interpolator = 0f;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        health = player.getHP();
        print(health);
        image = GetComponentsInChildren<Image>()[2];
        initial = image.rectTransform.localPosition;
        target = new Vector3(initial.x, initial.y - 4f, initial.z);
    }

    // Update is called once per frame
    void Update()
    {
        triggerFlaskReduction();
    }

	private void triggerFlaskReduction()
	{
        if (health != player?.getHP())
            StartCoroutine(updateFlask());
	}

    IEnumerator updateFlask()
	{
        int difference = health - (int)player?.getHP();
        health = (int)player?.getHP();
        for (int i=0; i<difference; i++)
		{
            
            image.rectTransform.localPosition = Vector3.Lerp(initial, target, interpolator);
            interpolator += 0.01f;
            //image.transform.position += new Vector3(0, -1, 0);
            yield return null;
		}

	}

}
