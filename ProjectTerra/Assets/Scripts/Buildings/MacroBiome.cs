public class MacroBiome : Building
{
    private float m_habitabilityGenerationRate = 10f;
    private float m_mineralGenerationRate = 5f;
    private int energyCost = 3;
    public override bool CanBuild()
    {
        if (GameManager.Instance.m_metals >= 150 &&
            GameManager.Instance.m_minerals >= 100 && 
            GameManager.Instance.m_energy + energyCost <= GameManager.Instance.m_energyCapacity)
        {
            GameManager.Instance.m_metals -= 150;
            GameManager.Instance.m_minerals -= 100;

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
        GameManager.Instance.m_habitability += m_habitabilityGenerationRate;
        GameManager.Instance.m_minerals += m_mineralGenerationRate;
    }
}
