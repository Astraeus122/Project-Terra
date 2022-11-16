using UnityEngine;

public class RoboticsLab : Building
{
    private float energyCost = 1;
    public override bool CanBuild()
    {
        if (GameManager.Instance.m_metals < 100)
        {
            Debug.Log("Building Robotics Lab failed. Not enough metal.");
        }
        else if (GameManager.Instance.m_minerals < 50)
        {
            Debug.Log("Building Robotics Lab failed. Not enough minerals.");
        }
        else if (GameManager.Instance.m_energy + energyCost > GameManager.Instance.m_energyCapacity)
        {
            Debug.Log("Building Robotics Lab failed. Not enough energy capacity.");
        }
        else
        {
            GameManager.Instance.m_metals -= 100;
            GameManager.Instance.m_minerals -= 50;
            
            GameManager.Instance.m_energy += energyCost;
            return true;
        }

        return false;
        
    }

    public override void ResourceTick() { }
}
