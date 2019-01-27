using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create Achievement", menuName = "Achievement")]
public class Achievement: ScriptableObject {

    public string mName;
    public PropertiesName[] mRelatedProperties;
    public bool unlocked { get; set; }


    public string toString()
    {
        return "[Achivement " + mName + "]";
    }

}
