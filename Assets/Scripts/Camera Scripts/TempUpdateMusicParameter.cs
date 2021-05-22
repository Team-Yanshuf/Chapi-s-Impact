using UnityEngine;

public class TempUpdateMusicParameter : MonoBehaviour
{
    LevelManager levelM;
    [SerializeField] FMODUnity.StudioEventEmitter emitter;
    // Start is called before the first frame update
    void Start()
    {
        levelM = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
  //      if (levelM.getRoomManagerInfo().finishedLoading)
		//{
  //          float val =  100f / levelM.getRoomManagerInfo().remainingFogPrecentage- 1f;
  //          //print(val);
  //          emitter.SetParameter("Nature Revive", val);
  //      }

    }
}
