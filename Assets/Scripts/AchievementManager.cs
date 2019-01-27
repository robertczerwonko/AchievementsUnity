using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PropertiesFoo
{
    public PropertiesName propName;
    public Property prop;
}

[System.Serializable]
public class AchievementFoo
{
    public string achievName;
    public Achievement achiev;
}


public class AchievementManager : MonoBehaviour {

    #region singleton
    public static AchievementManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    public List<PropertiesFoo> mProp;
    public List<AchievementFoo> mAchievement;

    public int getValue(PropertiesName theProp)
    {
        if (mProp.ContainsPropName(theProp))
            return mProp.returnPropValue(theProp);
        return 0;
    }

    public void addValue(PropertiesName theProp, int theValue)
    {

        setValue(theProp, getValue(theProp) + theValue);

    }

    public void addValue2<T>(T theProp, int theValue)
    {
        if (theProp is PropertiesName[])
        {
            PropertiesName[] tempArray = theProp as PropertiesName[];
            for (int i = 0; i < tempArray.Length; i++)
            {
                setValue(tempArray[i], getValue(tempArray[i]) + theValue);
            }
        }
    }

    public void setValue(PropertiesName theProp, int theValue)
    {
        foreach(PropertiesFoo prop in mProp)
        {
            if (prop.propName == theProp)
            {
                prop.prop.mValue = theValue;
            }

        }
    }

    public void setValue2<T>(T theProp, int theValue)
    {
        if (theProp is PropertiesName[])
        {
            PropertiesName[] tempArray = theProp as PropertiesName[];
            for (int i = 0; i < tempArray.Length; i++)
            {
                foreach (PropertiesFoo propFoo in mProp)
                {
                    if (propFoo.propName == tempArray[i])
                        propFoo.prop.mValue = theValue;
                }
            }
        }
    }

    public void resetProperties()
    {
        foreach (PropertiesFoo propFoo in mProp)
        {
            Property aProp = propFoo.prop;
            aProp.reset();
        }
        
    }

    public void resetAchievements()
    {
        foreach(AchievementFoo achievfoo in mAchievement)
        {
            achievfoo.achiev.unlocked = false;
        }
    }

    public void checkAchievementsAndDumbThem()
    {
        List<Achievement> tempAchiv = checkAchievements();
        if (tempAchiv.Count > 0)
        {
            foreach (Achievement ach in tempAchiv)
            {
                Debug.Log(ach.toString() + " - SUCCEEDED!");
            }
        }
    }

    public List<Achievement> checkAchievements()
    {
        List<Achievement> aRet = new List<Achievement>();
        Debug.Log("Achievement in list: "+mAchievement.Count);
        foreach (AchievementFoo achieveFoo in mAchievement)
        {
            Achievement aAchivement = achieveFoo.achiev;
            if (!aAchivement.unlocked)
            {
                
                int aActiveProps = 0;
                for (int i = 0; i < aAchivement.mRelatedProperties.Length; i++)
                {
                    Property aProp = mProp.returnProperty(aAchivement.mRelatedProperties[i]);
                    if (aProp.isActive())
                    {
                        aActiveProps++;
                    }
                }
                if (aActiveProps == aAchivement.mRelatedProperties.Length)
                {
                    aAchivement.unlocked = true;
                    aRet.Add(aAchivement);
                }
            }
        }
        return aRet;
    }

}
