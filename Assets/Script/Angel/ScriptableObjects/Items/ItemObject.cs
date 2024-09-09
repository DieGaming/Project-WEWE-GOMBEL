using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "ScriptableObjects/Items")]
public class ItemObject : ScriptableObject
{
    public GameObject prefab;
    [TextArea(15, 20)]
    public string description;
    

}
