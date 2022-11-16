public class RecreationCenter : Building
{
    private float resourceRate = 10f;
    private float energyCost = 2;
    
    public override bool CanBuild()
    {
        if (GameManager.Instance.m_metals >= 150 &&
            GameManager.Instance.m_minerals >= 150 &&
            GameManager.Instance.m_energy + energyCost <= GameManager.Instance.m_energyCapacity)
        {
            GameManager.Instance.m_metals -= 150;
            GameManager.Instance.m_minerals -= 150;
            
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