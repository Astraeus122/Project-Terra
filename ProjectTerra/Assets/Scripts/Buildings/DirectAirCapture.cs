public class DirectAirCapture : Building
{
    private float resourceRate = 15f;
    private float energyCost = 5;
    public override bool CanBuild()
    {
        if (GameManager.Instance.m_metals >= 150 &&
            GameManager.Instance.m_minerals >= 200 && 
            GameManager.Instance.m_energy + energyCost <= GameManager.Instance.m_energyCapacity)
        {
            GameManager.Instance.m_metals -= 150;
            GameManager.Instance.m_minerals -= 200;

            GameManager.Instance.m_energy += energyCost;
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void ResourceTick()
    {
        GameManager.Instance.m_habitability += resourceRate;
    }
}
