using UnityEngine;

public struct PowerupInfo
{
    public string name;
    public string type;
    public string modifier;
    public string description;

    public PowerupInfo(string name, string type,string modifier, string description)
	{
        this.name = name;
        this.type = type;
        this.modifier = modifier;
        this.description = description;
	}
}

public abstract class PowerupBase : MonoBehaviour
{
    PowerupInfo info;
 
	public void destroy()
	{
        Destroy(this.gameObject);
	}

    public abstract PowerupInfo getPowerupInfo();
}