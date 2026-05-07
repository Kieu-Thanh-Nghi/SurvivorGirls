public class PlayerIceEffContainer : IceEffContainer
{
    protected override void FilterEff()
    {
        currentEffect.totalTime = currentEffect.totalTime * (1 - PlayerDataManager.Instance.ElementReg);
    }
}
