using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct PollutionContainerInfo
{
    public float initialFogCount { get; set; }
    public float remainingFogAmount { get; set; }
    public float remainingFogPrecentage { get; set; }
    public PollutionContainerInfo(float initial, float remainingAmount, float remainingPrecentage)
    {
        this.initialFogCount = initial;
        this.remainingFogAmount = remainingAmount;
        this.remainingFogPrecentage = remainingPrecentage;
    }

    public override string ToString()
    {
        return ($"initialFogCount: {initialFogCount}, remaining amount: {remainingFogAmount} , remaining precent: {remainingFogPrecentage}");
    }
}

public class FogContainer : MonoBehaviour
{
    PollutionContainerInfo info;
    FogParticle particle;
    BoxCollider collider;
    List<GameObject> pollution;
    int fogAmount;
    Transform fogTransform;

    public void setFogTransform(Transform transform)
    {
        this.fogTransform = transform;
    }
    void Start()
    {
        particle = Resources.Load<FogParticle>("FogParticle/FogParticle");
        pollution = new List<GameObject>();
        info = new PollutionContainerInfo(0, 0, 0);
    }
    private void Update()
    {
        updateFogInfo();
    }
    public PollutionContainerInfo getPollutionStatus() => info;
    void updateFogInfo()
    {
        info.remainingFogAmount = fogAmount;
        info.remainingFogPrecentage = (pollution.Count / fogAmount) * 100f;
        info.remainingFogAmount = pollution.Count;
    }
    public void initFog()
    {
        StartCoroutine(initFogCoroutine());
    }
    public IEnumerator initFogCoroutine()
    {
        while (particle == null)
        {
            yield return null;
           // print("coroutine partic is null");
        }

        if (fogAmount==0)
        {
            print("fog count is zero.");
            yield break;
        }

        for (int i=0; i<fogAmount;)
        {
            for (int j=0; j<10; j++,i++)
            {
                Vector3 point = generateRandomPointInsideBounds();
                FogParticle fog = Instantiate(Resources.Load<FogParticle>("FogPArticle/FogParticle"), point, Quaternion.identity); ;
                pollution.Add(fog.gameObject);
                fog.transform.SetParent(this.transform);
            }
            yield return null;
        }
    }
    public void setFogCount(int count)
    {
        this.fogAmount = count;
    }
    public void dwindleByPrecentage(int precent)
    {
        StartCoroutine(dwindleFogByPrecentage());

         IEnumerator dwindleFogByPrecentage()
        {
            int amount = (pollution.Count * precent) / 100;
            for (int i = 0; i < amount;)
            {
                for (int j = 0; j < 7; j++, i++)
                {
                    Destroy(pollution[0]);
                    pollution.RemoveAt(0);
                }
                yield return null;
            }
        }
    }
    public void dwindleByAmout(int amount)
    {
        StartCoroutine(dwindleFogByAmount());

        IEnumerator dwindleFogByAmount()
        {
            if (amount >= pollution.Count)
            {
                foreach (GameObject particle in pollution)
                {
                    Destroy(particle);
                }
                pollution.Clear();
            }

            else
            {
                for (int i = 0; i < amount;)
                {
                    for (int j=0; j<7; j++, i++)
                    {
                        Destroy(pollution[0]);
                        pollution.RemoveAt(0);
                    }
                    yield return null;
                }
            }
        }
    }
    public void setBounds(BoxCollider collider)
    {
        this.collider = collider;
    }
    Vector3 generateRandomPointInsideBounds()
    {
        if (collider==null)
            return Vector3.zero;

        Vector3 point;
        Bounds bounds = collider.bounds;

        do
        {
            point = new Vector3(Random.Range(bounds.min.x, bounds.max.x),
                                Random.Range(bounds.min.y, bounds.max.y),
                                Random.Range(bounds.min.z, bounds.max.z));
            point = fogTransform.TransformPoint(point);
        }
        while (point != collider.ClosestPoint(point));

        return point;
    }

}
