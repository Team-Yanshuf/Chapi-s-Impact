using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogContainer : MonoBehaviour
{
    GameObject particle;
    FogParticle partic;
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
        particle = Resources.Load<GameObject>("FogParticle/FogParticle");
        partic = Resources.Load<FogParticle>("FogParticle/FogParticle");
        if (!partic)
        {
            print("partic is null");
        }
        if (!particle)
            print("particle is null");
        pollution = new List<GameObject>();
    }

    public void initFog()
    {
        StartCoroutine(initFogCoroutine());
    }

    public IEnumerator initFogCoroutine()
    {
        while (partic == null)
        {
            yield return null;
            print("coroutine partic is null");
        }

        if (fogAmount==0)
        {
            print("fog count is zero.");
            yield break;
        }

        for (int i=0; i<fogAmount; i++)
        {
            Vector3 point = generateRandomPointInsideBounds();
            FogParticle fog = Instantiate(Resources.Load<FogParticle>("FogPArticle/FogParticle"), point, Quaternion.identity); ;
            pollution.Add(fog.gameObject);
        }

    }

    public void setFogCount(int count)
    {
        this.fogAmount = count;
    }
    public void dwindleFogByPrecentage(int precent)
    {

    }
    public void dwindleFogByAmount(int amount)
    {

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
