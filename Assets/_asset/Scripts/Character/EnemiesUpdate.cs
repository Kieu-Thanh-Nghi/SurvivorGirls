using Lean.Pool;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesUpdate : MonoBehaviour
{
    internal static EnemiesUpdate Instance;
    [SerializeField] internal EnemySpawner enemySpawner;
    [SerializeField] int enemyQuantityLimiter = 1000;
    [SerializeField] internal int enemyQuantity;
    internal DeathCount killedZomCount => GamePlayCtrler.Instance.killedZomCount;
    [SerializeField] internal LeanGameObjectPool EnemyDeadEff;
    [SerializeField] internal RockPools rockPools;
    [SerializeField] internal List<EndGameReward> endGameRewards;

    internal List<Enemy> enemies = new List<Enemy>(500);
    Vector3 playerPosition;
    int enemyIndex;
    Enemy temp;

    public bool isPause;

    private void Awake()
    {
        Instance = this;
    }
    public void AddAnEnemy(Enemy theEnemy)
    {
        enemies.Add(theEnemy);
        theEnemy.enemyIndex = enemies.Count - 1;
        enemyQuantity = enemies.Count;
    }
    public void RemoveAnEnemy(Enemy theEnemy)
    {
        var quantity = enemies.Count;
        if (quantity == 1)
        {
            enemies.RemoveAt(0);
        }
        else
        {
            //enemies[quantity - 1].enemyIndex = theEnemy.enemyIndex;
            (theEnemy, enemies[quantity - 1]) = (enemies[quantity - 1], theEnemy);
            enemies.RemoveAt(quantity - 1);
        }
        enemyQuantity = enemies.Count;
        killedZomCount.DoCount();
    }    
    
    public void RemoveAnEnemy(int enemyIndex)
    {
        var quantity = enemies.Count;
        if (quantity == 1)
        {
            enemies.RemoveAt(0);
        }
        else
        {
            (enemies[enemyIndex], enemies[quantity - 1]) = (enemies[quantity - 1], enemies[enemyIndex]);
            enemies.RemoveAt(quantity - 1);
        }
        enemyQuantity = enemies.Count;
        killedZomCount.DoCount();
    }
    private void FixedUpdate()
    {
        if (isPause) return;
        //playChar.DoFixedUpdate();
        int n = enemies.Count;
        for (int i = 0; i < n; i++)
        {
            if (enemies[i] == null) continue;
            if (enemies[i].isActiveAndEnabled)
            {
                enemies[i].EnemyRotate();
            }
        }
    }

    private void Update()
    {
        if (isPause) return;
        bool isPlayerMoveEnough = false;
        if (GamePlayCtrler.Instance != null)
        {
            isPlayerMoveEnough = Vector3.Distance(playerPosition, GamePlayCtrler.Instance.Player.position) > 2;
        }
        if (isPlayerMoveEnough)
        {
            playerPosition = GamePlayCtrler.Instance.Player.position;
        }
        int n = enemies.Count;        
        
        for (int i = 0; i < n; i++)
        {
            if (enemies[i] == null || !enemies[i].gameObject.activeInHierarchy)
            {
                RemoveAnEnemy(i);
                n--;
                i--;
            }
        }
        //playChar.DoUpdate();

        //if (playChar.characterData.moveDirect == Vector3.zero) return;
        if (enemyIndex >= n) enemyIndex = 0;
        for (int i = 0; i < Mathf.CeilToInt((float)n/2) && enemyIndex < n; i++)
        {
            enemies[enemyIndex].EnemyMove(isPlayerMoveEnough);
            enemyIndex++;
        }
    }
    internal bool CheckEnemyLimit() => enemyQuantity > enemyQuantityLimiter;

}

public class BakeAnimation : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public AnimationClip clip;
    public int frameRate = 30;

    private List<Mesh> bakedFrames = new List<Mesh>();

    void Start()
    {
        Bake();
    }

    void Bake()
    {
        float length = clip.length;
        int totalFrames = Mathf.CeilToInt(length * frameRate);

        for (int i = 0; i < totalFrames; i++)
        {
            float time = i / (float)frameRate;

            clip.SampleAnimation(gameObject, time);

            Mesh mesh = new Mesh();
            skinnedMeshRenderer.BakeMesh(mesh);

            bakedFrames.Add(mesh);
        }

        Debug.Log("Bake xong: " + bakedFrames.Count + " frames");
    }
}