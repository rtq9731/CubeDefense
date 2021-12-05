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
    EnemyDirection dir;
    public EnemyDirection Dir { get { return dir; } set { dir = value; } }


    public enum EnemyDirection
    {
        right,
        left
    }

    public void Damage(float damage)
    {
        hp -= damage;
    }
}