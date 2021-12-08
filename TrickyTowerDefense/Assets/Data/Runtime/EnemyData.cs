using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
/// 
[System.Serializable]
public class EnemyData
{
  [SerializeField]
  int idx;
  public int Idx { get {return idx; } set { this.idx = value;} }
  
  [SerializeField]
  int tier;
  public int Tier { get {return tier; } set { this.tier = value;} }
  
  [SerializeField]
  float hp;
  public float Hp { get {return hp; } set { this.hp = value;} }
  
  [SerializeField]
  float speed;
  public float Speed { get {return speed; } set { this.speed = value;} }
  
  [SerializeField]
  string imagepath;
  public string Imagepath { get {return imagepath; } set { this.imagepath = value;} }

    public void Damage(float damage)
    {
        hp -= damage;
    }

    public EnemyData GetCopiedData()
    {
        EnemyData result = new EnemyData();
        Copy(result);
        return result;
    }

    public void Copy(EnemyData data)
    {
        data.idx = idx;
        data.tier = tier;
        data.hp = hp;
        data.speed = speed;
        data.imagepath = imagepath;
    }
}