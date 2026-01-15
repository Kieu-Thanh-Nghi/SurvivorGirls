using UnityEngine;

public class BossSpawnStarter : SpawnStarter
{
    [SerializeField] Sprite bossSprite;
    internal override bool Spawn(float time)
    {
        GamePlayCtrler.Instance.IsPause = true;
        warningReveal();
        return base.Spawn(time);
    }

    void warningReveal()
    {
        var warningPanel = GamePlayCtrler.Instance.warningPanel;
        warningPanel.SetBossImage(bossSprite);
        warningPanel.Reveal(() => GamePlayCtrler.Instance.IsPause = false);
    }
}