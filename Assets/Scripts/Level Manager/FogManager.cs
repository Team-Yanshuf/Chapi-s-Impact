using UnityEngine;

public class FogManager : MonoBehaviour
{
    [SerializeField] int initialFogCount;
    BoxCollider fogBoundries;
    FogContainer pollution;

    RoomEvents events;

    public void initSelf()
	{
        //levelM = GetComponent<LevelManager>();
        fogBoundries = GetComponent<BoxCollider>();

        events = GetComponent<RoomEvents>();
        
        events.dwindleLocalFog.AddListener(clearFogBy20Precent);
        events.treePlanted.AddListener(clear200FogParticles);
    }
    public void initFog()
    {
        pollution = GameObject.Instantiate(Resources.Load<FogContainer>("FogContainer/FogContainer"));
        pollution.setBounds(fogBoundries);
        pollution.setFogCount(initialFogCount);
        pollution.transform.parent = this.transform;

        pollution.setFogTransform(transform);
        pollution.initFog();
    }

    void clearFogBy20Precent()
    {
        pollution.dwindleByPrecentage(20);
    }
    void clear200FogParticles()
    {
        pollution.dwindleByAmout(200);
    }


    public PollutionContainerInfo getPollutionInfo()
    {
        return pollution.getPollutionStatus();
    }
	
}
