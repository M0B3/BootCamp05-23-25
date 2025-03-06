using UnityEngine;

[CreateAssetMenu(fileName = "SO_Item", menuName = "Scriptable Objects/Item")]
public class SO_Item : ScriptableObject
{
    public string name;
    public GameObject model;

    public virtual void action() { }
}
