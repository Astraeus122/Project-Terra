public class RoboticsLab : Building
{
    private float energyCost = 1;
    public override bool CanBuild()
    {
        if (GameManager.Instance.m_metals >= 100  && 
           GameManager.Instance.m_minerals >= 50 && 
           GameManager.Instance.m_energy + energyCost <= GameManager.Instance.m_energyCapacity)
        {
            GameManager.Instance.m_metals -= 100;
            GameManager.Instance.m_minerals -= 50;
            
            GameManager.Instance.m_energy += energyCost;
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void ResourceTick() { }
}
