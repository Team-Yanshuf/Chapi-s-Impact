using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public struct PollutionContainerInfo
{
    public int InitialFogCount { get; set; }
    public int RemainingFogAmount { get; set; }
    public float RemainingFogPrecentage { get; set; }
    public float RemainingFogPrecentageInverse { get; set; }
    public bool FinishedLoading { get; set; }
    public PollutionContainerInfo(int initial, int remaining, bool finishedLoading)
	{
        this.InitialFogCount = initial;
        this.RemainingFogAmount = remaining;
        this.FinishedLoading = finishedLoading;
        this.RemainingFogPrecentage = ((float)remaining / (float)initial);
        this.RemainingFogPrecentageInverse = 1f - RemainingFogPrecentage;
    }
    public override string ToString()
    {
        return ($"initialFogCount: {InitialFogCount}, remaining amount: {RemainingFogAmount} , remaining precent: {RemainingFogPrecentage}");
    }
}

public class FogContainer : MonoBehaviour
{
    public static Action<float> FogDwindledEventHandler;
    PollutionContainerInfo info;
    FogParticle particle;
    BoxCollider collider;
    List<GameObject> pollution;
    int fogAmount;
    Transform fogTransform;
    bool isFinishedLoading;
    public void setFogTransform(Transform transform)
    {
        this.fogTransform = transform;
    }

    public void initSelf(int initialAmount)
	{
        particle = Resources.Load<FogParticle>("FogParticle/FogParticle");
        pollution = new List<GameObject>();
        fogAmount = initialAmount;
        isFinishedLoading = false;
        //info = new PollutionContainerInfo(0, 0, 0, false);
    }
    public PollutionContainerInfo getPollutionStatus()
    {
        if (pollution.Count == fogAmount)
            isFinishedLoading = true;

        return new PollutionContainerInfo(fogAmount, pollution.Count, isFinishedLoading);
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

    public void dwindleByPrecentage(int precent)
    {
        StartCoroutine(dwindleFogByPrecentage());
         IEnumerator dwindleFogByPrecentage()
        {
            int amount = (pollution.Count * precent) / 100;
            for (int i = 0; i < amount;)
            {
                for (int j = 0; j < 2 && i<amount; j++, i++)
                {
                    Destroy(pollution[0]);
                    pollution.RemoveAt(0);
                    PollutionContainerInfo info = getPollutionStatus();
                    FogDwindledEventHandler.Invoke(info.RemainingFogPrecentageInverse);
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
                for(int i = pollution.Count - 1; i >= 0; i--)
                {

                    Destroy(pollution[0]);
                    pollution.RemoveAt(0);
                    FogDwindledEventHandler.Invoke(getPollutionStatus().RemainingFogPrecentageInverse);
                    yield return null;
                }
            }

            else
            {
                for (int i = 0; i < amount;)
                {
                    for (int j=0; j<2 && i<amount; j++, i++)
                    {
                        Destroy(pollution[0]);
                        pollution.RemoveAt(0);
                        FogDwindledEventHandler.Invoke(getPollutionStatus().RemainingFogPrecentageInverse);

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
        int limiter = 0;
        do
        {
            point = new Vector3(UnityEngine.Random.Range(bounds.min.x, bounds.max.x),
								UnityEngine.Random.Range(bounds.min.y, bounds.max.y),
								UnityEngine.Random.Range(bounds.min.z, bounds.max.z));
            point = transform.TransformPoint(point);
            
            limiter++;
        }
        while (point != collider.ClosestPoint(point) );

        return point;
    }

}
