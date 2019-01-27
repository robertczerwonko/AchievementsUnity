# AchievementsUnity
Simple achievement system based on 2 scriptable objects(property and achievement) <br />
It's my first "tutorial type" repo so it might not be that great ;) 

## Table of Contents

- [Introduction](#Introduction)
- [Tutorial](#tutorial)
- [Example](#Example)
- [Motivation](#morivation) 

## Introduction
Achievement system to simply add any achievement you like to your Unity project. <br />
I created this because I like to simplify things in Unity to maximum and with this system,<br />
creating new achievement is limited only to 3 steps. In the next section I will exaplain 

## Tutorial
1. First of all define what kind of properties your game will need i.e. "killed enemies" etc.<br />
  - then you will have to add names of those properties to public ENUM called "PropertiesName"
2. Now when you have done that, you can create SCRIPTABLE OBJECT called "Property" and define:

        PropertiesName _pName;  -> Enum with your properties names
        int mValue;             -> value which is used to count progress of this property
        Activation mActivation; -> condition symbol for your value and ActivationValue i.e( value >= ActivationValue)
        int mActivationValue;   -> goal of your property 
        int mInitialValue;      -> initial value of your property( you want this to be 0, when i.e you count killed enemies)
      
3. When all properties required for achievement are created, we can start to define achievement:
  - Achievement is SCRIPTABLE OBJECT as well, so after you create one add:
  
         string mName;                        -> your Achviev name i.e (Great Hunter)
         PropertiesName[] mRelatedProperties; -> Array of enums we created earlier i.e(killed enemies,deaths)
                                                 those properties are required for this achievement to be unlocked
                                                 
                                                 
4. After all of this is done, just add to game "Achievement manager"(script) and drag all of your properties and achievements to it.
This manager is using SINGLETON so make sure it's always active. Now whenever you need to add values to properties, use this manager.
For example when I kill one enemy i will call 
          
                AchievementManager.instance.addValue(PropertyName.killedEnemies,1) 
                this will add 1 value to killed enemies
  
IN PROJECT IS EXAMPLE OF COUPLE ACHIEVEMENTS AND PROPERTIES TOGETHER WITH <br />
GAME MANANGER WHERE I CONTROL INPUT TO ACTIVE SPECIFIC PROPERTIES 

## Example
![example](yaktocat.png)

