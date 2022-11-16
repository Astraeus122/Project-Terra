public class GasPoweredGenerator : Building
{
    private float habitabilityCost = 1;
    public override bool CanBuild()
    {
        if (GameManager.Instance.m_metals >= 20 &&
            GameManager.Instance.m_minerals >= 100)
        {
            GameManager.Instance.m_metals -= 20;
            GameManager.Instance.m_minerals -= 100;

            GameManager.Instance.m_energyCapacity += 2;
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void ResourceTick()
    {
        GameManager.Instance.m_habitability -= habitabilityCost;
    }
}
