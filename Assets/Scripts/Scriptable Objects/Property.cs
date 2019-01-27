using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create Property", menuName = "Property")]
public class Property : ScriptableObject{

    public PropertiesName _pName;
    public int mValue;
    public Activation mActivation;
    public int mActivationValue;
    public int mInitialValue;


    public bool isActive()
    {
        bool aRet = false;

        switch (mActivation)
        {
            case Activation.GREATER_THAN:
                    aRet = mValue > mActivationValue;
                break;
            case Activation.LOWER_THAN:
                aRet = mValue < mActivationValue;
                break;
            case Activation.GREATER_THAN_OR_EQUAL_TO:
                aRet = mValue >= mActivationValue;
                break;
            case Activation.LOWER_THAN_OR_EQUAL_TO:
                aRet = mValue <= mActivationValue;
                break;
            case Activation.EQUAL:
                aRet = mValue == mActivationValue;
                break;
        }

        return aRet;
    }

    public void reset()
    {
        mValue = mInitialValue;
    }
	
}
