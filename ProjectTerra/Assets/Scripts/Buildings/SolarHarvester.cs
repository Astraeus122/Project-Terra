public class SolarHarvester : Building
{
    public override bool CanBuild()
    {
        if (GameManager.Instance.m_metals >= 50 &&
            GameManager.Instance.m_minerals >= 50)
        {
            GameManager.Instance.m_metals -= 50;
            GameManager.Instance.m_minerals -= 50;
            
            GameManager.Instance.m_energyCapacity++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void ResourceTick() { }
}
