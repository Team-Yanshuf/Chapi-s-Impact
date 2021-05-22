using UnityEngine;

public class FogManager : MonoBehaviour
{
    [SerializeField] int initialFogCount;
    BoxCollider fogBoundries;
    FogContainer pollution;
    //LevelManager levelM;

    public void initSelf()
	{
        //levelM = GetComponent<LevelManager>();
        fogBoundries = GetComponent<BoxCollider>();

        GameManagerEvents.enemyDefeated.AddListener(clearFogBy20Precent);
        GameManagerEvents.treePlanted.AddListener(clear200FogParticles);
    }
    public void initFog()
    {
        pollution = GameObject.Instantiate(Resources.Load<FogContainer>("FogContainer/FogContainer"));
        pollution.setBounds(fogBoundries);
        pollution.setFogCount(initialFogCount);

        //pollution.setFogTransform(levelM.transform.Find("LevelBoundries").transform);
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
