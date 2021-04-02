using System.Collections.Generic;
using UnityEngine;

public class FogContainer : MonoBehaviour
{
    FogParticle particle;
    Bounds bounds;
    List<FogParticle> pollution;
    int fogAmount;

    void Start()
    {
        particle = Resources.Load<FogParticle>("FogContainer/FogContainer");
        pollution = new List<FogParticle>();
    }

    void initFog()
    {

    }

    void setFogCount()
    {
        
    }

    void dwindleFogByPrecentage(int precent)
    {

    }

    void dwindleFogByAmount(int amount)
    {

    }



    void Update()
    {
        
    }

    void setBounds(Bounds bounds)
    {
        this.bounds = bounds;
    }

    Vector3 generateRandomPointInsideBounds()
    {
        if (bounds==null)
            return Vector3.zero;
     
        Vector3 point = new Vector3(Random.Range(bounds.min.x, bounds.max.x),
                            Random.Range(bounds.min.y, bounds.max.y),
                            Random.Range(bounds.min.z, bounds.max.z));

        point = GameObject.FindGameObjectWithTag("LevelManager").transform.Find("LevelBoundries")
                .TransformPoint(point);
        
        return point;
    }



}
