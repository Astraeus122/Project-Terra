using UnityEngine;

public class GasPoweredGenerator : Building
{
    private float habitabilityCost = 1;
    public override bool CanBuild()
    {
        if (GameManager.Instance.m_metals < 20)
        {
            Debug.Log("Building Gas Powered Generator failed. Not enough metal.");
        }
        
        if (GameManager.Instance.m_minerals < 100)
        {
            Debug.Log("Building Gas Powered Generator failed. Not enough minerals.");
        }
        else
        {
            Debug.Log("Built Gas Powered Generator.");

            GameManager.Instance.m_metals -= 20;
            GameManager.Instance.m_minerals -= 100;

            GameManager.Instance.m_energyCapacity += 2;
            
            return true;
        }

        return false;
    }

    public override void ResourceTick()
    {
        GameManager.Instance.m_habitability -= habitabilityCost;
    }
}
