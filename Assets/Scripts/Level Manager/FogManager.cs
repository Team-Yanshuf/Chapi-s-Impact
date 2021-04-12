using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogManager : MonoBehaviour
{
    [SerializeField] int initialFogCount;
    BoxCollider fogBoundries;
    FogContainer pollution;
    LevelManager levelM;

    void Start()
    {
        levelM = GetComponent<LevelManager>();
        fogBoundries= GetComponentInChildren<BoxCollider>();

        GameManagerEvents.enemyDefeated.AddListener(clearFogBy20Precent);
        GameManagerEvents.treePlanted.AddListener(clear200FogParticles);
    }
    void clearFogBy20Precent()
    {
        pollution.dwindleByPrecentage(20);
    }
    void clear200FogParticles()
    {
        pollution.dwindleByAmout(200);
    }
    public void initFog()
	{
        StartCoroutine(initFogCoroutine());
	}
    public IEnumerator initFogCoroutine()
    {

        while (!levelM || !fogBoundries)
            yield return null; 
        pollution = GameObject.Instantiate(Resources.Load<FogContainer>("FogContainer/FogContainer"));
        pollution.setBounds(fogBoundries);
        pollution.setFogCount(initialFogCount);
        //pollution.setFogTransform(this.transform);
        pollution.setFogTransform(levelM.transform.Find("LevelBoundries").transform);
        pollution.initFog();
    }

    public PollutionContainerInfo getPollutionInfo()
    {
        return pollution.getPollutionStatus();
    }
	
}
