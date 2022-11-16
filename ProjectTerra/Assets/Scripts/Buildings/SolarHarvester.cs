using UnityEngine;

public class SolarHarvester : Building
{
    public override bool CanBuild()
    {
        if (GameManager.Instance.m_metals < 50)
        {
            Debug.Log("Building Solar Harvester failed. Not enough metal.");
        }
        else if (GameManager.Instance.m_minerals < 50)
        {
            Debug.Log("Building Solar Harvester failed. Not enough minerals.");
        }
        else
        {
            Debug.Log("Built Solar Harvester.");
            GameManager.Instance.m_metals -= 50;
            GameManager.Instance.m_minerals -= 50;
            
            GameManager.Instance.m_energyCapacity++;
            return true;
        }

        return false;
    }

    public override void ResourceTick() { }
}
