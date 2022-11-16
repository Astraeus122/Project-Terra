using UnityEngine;

public class RecreationCenter : Building
{
    private float resourceRate = 10f;
    private float energyCost = 2;
    
    public override bool CanBuild()
    {
        if (GameManager.Instance.m_metals < 150)
        {
            Debug.Log("Building Recreation Center failed. Not enough metal.");
        }
        else if (GameManager.Instance.m_minerals < 150)
        {
            Debug.Log("Building Recreation Center failed. Not enough minerals.");
        }
        else if (GameManager.Instance.m_energy + energyCost > GameManager.Instance.m_energyCapacity)
        {
            Debug.Log("Building Recreation Center failed. Not enough energy capacity.");
        }
        else
        {
            Debug.Log("Built Recreation Center.");

            GameManager.Instance.m_metals -= 150;
            GameManager.Instance.m_minerals -= 150;
            
            GameManager.Instance.m_energy += energyCost;
            
            return true;
        }

        return false;
    }

    public override void ResourceTick()
    {
        GameManager.Instance.m_habitability += resourceRate;
    }
}
