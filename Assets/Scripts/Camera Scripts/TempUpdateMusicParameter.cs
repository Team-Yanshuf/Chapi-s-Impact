using UnityEngine;

public class TempUpdateMusicParameter : MonoBehaviour
{
    LevelManager levelM;
    [SerializeField] FMODUnity.StudioEventEmitter backgroud;
    [SerializeField] FMODUnity.StudioEventEmitter seagulls;
    float fogLevel;
    // Start is called before the first frame update
    void Start()
    {
        levelM = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
		if (levelM.getRoomManagerInfo().finishedLoading)
		{

			float val = 1f-levelM.getRoomManagerInfo().remainingFogPrecentage;
			backgroud.SetParameter("Nature Revive", val);
            seagulls.SetParameter("Nature Revive", val);
		}

	}
}
