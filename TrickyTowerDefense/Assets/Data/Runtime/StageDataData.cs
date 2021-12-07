using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
/// 
[System.Serializable]
public class StageDataData
{
  [SerializeField]
  int idx;
  public int Idx { get {return idx; } set { this.idx = value;} }
  
  [SerializeField]
  int enemycount1;
  public int Enemycount1 { get {return enemycount1; } set { this.enemycount1 = value;} }
  
  [SerializeField]
  int enemycount2;
  public int Enemycount2 { get {return enemycount2; } set { this.enemycount2 = value;} }
  
  [SerializeField]
  int enemycount3;
  public int Enemycount3 { get {return enemycount3; } set { this.enemycount3 = value;} }
  
  [SerializeField]
  int enemycount4;
  public int Enemycount4 { get {return enemycount4; } set { this.enemycount4 = value;} }
  
  [SerializeField]
  int enemycount5;
  public int Enemycount5 { get {return enemycount5; } set { this.enemycount5 = value;} }
  
  [SerializeField]
  int enemycount6;
  public int Enemycount6 { get {return enemycount6; } set { this.enemycount6 = value;} }
  
  [SerializeField]
  bool isbossround;
  public bool Isbossround { get {return isbossround; } set { this.isbossround = value;} }
  
    public int EnemyCount() // 적들 개수의 합
    {
        return
            enemycount1 +
            enemycount2 +
            enemycount3 +
            enemycount4 +
            enemycount5 +
            enemycount6;
    }

    public void Copy(out StageDataData data)
    {
        data = new StageDataData();
        data.enemycount1 = enemycount1;
        data.enemycount2 = enemycount2;
        data.enemycount3 = enemycount3;
        data.enemycount4 = enemycount4;
        data.enemycount5 = enemycount5;
        data.enemycount6 = enemycount6;
    }

    public int GetLastestEnemeyTier()
    {
        if(enemycount1 > 0)
        {
            enemycount1--;
            return 0;
        }
        else if (enemycount2 > 0)
        {
            enemycount2--;
            return 1;
        }
        else if (enemycount3 > 0)
        {
            enemycount3--;
            return 2;
        }
        else if (enemycount4 > 0)
        {
            enemycount4--;
            return 3;
        }
        else if (enemycount5 > 0)
        {
            enemycount5--;
            return 4;
        }
        else if (enemycount6 > 0)
        {
            enemycount6--;
            return 5;
        }
        else
        {
            return -1;
        }    
    }
}