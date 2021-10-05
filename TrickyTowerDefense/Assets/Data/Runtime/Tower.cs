using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

///
/// !!! Machine generated code !!!
///
/// A class which deriveds ScritableObject class so all its data 
/// can be serialized onto an asset data file.
/// 
[System.Serializable]
public class Tower : ScriptableObject 
{	
    [HideInInspector] [SerializeField] 
    public string SheetName = "";
    
    [HideInInspector] [SerializeField] 
    public string WorksheetName = "";
    
    // Note: initialize in OnEnable() not here.
    public TowerData[] dataArray;

    public Dictionary<string, TowerData> towerDataDictionary = new Dictionary<string, TowerData>();
    
    void OnEnable()
    {		
//#if UNITY_EDITOR
        //hideFlags = HideFlags.DontSave;
//#endif
        // Important:
        //    It should be checked an initialization of any collection data before it is initialized.
        //    Without this check, the array collection which already has its data get to be null 
        //    because OnEnable is called whenever Unity builds.
        // 		
        if (dataArray == null)
            dataArray = new TowerData[0];

        foreach (var item in dataArray)
        {
            towerDataDictionary.Add(item.Towername, item);
        }

    }

    public TowerData FindTower(TowerData.TowerType towerType, TowerData.TowerGrade towerGrade)
    {
        return towerDataDictionary.Values.ToList().Find(x => (x.TOWERTYPE == towerType || x.TOWERGRADE == towerGrade));
    }

    public List<TowerData> FindAllTower(TowerData.TowerType towerType)
    {
        return towerDataDictionary.Values.ToList().FindAll(x => x.TOWERTYPE == towerType);
    }

    //
    // Highly recommand to use LINQ to query the data sources.
    //

}
