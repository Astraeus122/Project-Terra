using UnityEngine;

public class DirectAirCapture : Building
{
    private float resourceRate = 15f;
    private float energyCost = 5;
    public override bool CanBuild()
    {
        if (GameManager.Instance.m_metals < 150)
        {
            Debug.Log("Building DAC Facility failed. Not enough metal");
        }
        else if (GameManager.Instance.m_minerals < 200)
        {
            Debug.Log("Building DAC Facility failed. Not enough minerals");
        }
        else if (GameManager.Instance.m_energy + energyCost > GameManager.Instance.m_energyCapacity)
        {
            Debug.Log("Building DAC Facility failed. Not enough energy capacity");
        }
        else
        {
            GameManager.Instance.m_metals -= 150;
            GameManager.Instance.m_minerals -= 200;

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
