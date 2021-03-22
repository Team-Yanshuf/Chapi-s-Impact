using System.Collections.Generic;
using UnityEngine;

public class FogContainer : MonoBehaviour
{

    List<FogParticle> particles;
    FogParticle particle;

    Transform levelTransform;

    int initialFogCount;

    // Start is called before the first frame update
    void Awake()
    {
        particle = Resources.Load<FogParticle>("FogParticle/FogParticle");
        particles = new List<FogParticle>();
    }

    public void generateFog(Bounds bounds, int amountToGenerate)
	{
        initialFogCount = amountToGenerate;
        for (int i= 0; i<amountToGenerate; i++)
		{
            Vector3 point = getRandomPointInsideFogCollider(bounds);
            FogParticle fog= Instantiate<FogParticle>(particle, point, Quaternion.identity,transform);
            particles.Add(fog);
		}
	}

    public void dwindleByAmount(int amount)
	{
        if (amount > particles.Count)
		{
            particles.Clear();
            return;
        }


        else
		{
            for (int i=0; i<amount; i++)
			{
                Destroy(particles[0].gameObject);
                particles.RemoveAt(0);
			}
		}
	}

    public void dwindleByPrecent(int precentage)
	{
        if (precentage == 0)
            return;

        int amount = (int)(particles.Count * (precentage / 100f));


		for (int i = 0; i < amount; i++)
		{
			int indexToRemove = Random.Range(0, initialFogCount);
            Destroy(particles[0].gameObject);//.gameObject);
            particles.RemoveAt(0);

		}


		//      for (int i=0; i<precentage; i++)
		//{
		//          print(particles.Count);

		//          if (particles[0]!=null)
		//          Destroy(particles[0].gameObject);
		//          particles.RemoveAt(0);
		//          print(particles.Count);
		//}
	}

    public void clearAllFog()
	{
        particles.Clear();
	}

    Vector3 getRandomPointInsideFogCollider(Bounds bounds)
    {
        Vector3 point;
        do
        {
            point = new Vector3(Random.Range(bounds.min.x, bounds.max.x),
                            Random.Range(bounds.min.y, bounds.max.y),
                            Random.Range(bounds.min.z, bounds.max.z));
            levelTransform.TransformPoint(point);
        }
        while (point != bounds.ClosestPoint(point));

        //point = levelM.transform.Find("LevelBoundries").transform.TransformPoint(point);
        return point;
    }

    public void setLevelBoundriesTransform(Transform transform)
	{
        levelTransform = transform;
	}
}
