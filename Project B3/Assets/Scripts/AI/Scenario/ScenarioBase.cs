using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ScenarioBase : MonoBehaviour
{
    public List<(NPC,int)> npcs;
    public List<string> targets;
    public List<int> boundaries;
    public List<Transform> spots;
    [HideInInspector]
    public List<bool> bspots;
    public virtual void GetNPCs()
    {
        npcs = FindObjectsOfType<NPC>().Where(npc => targets.Contains(npc.name)).Select(npc => (npc,0)).ToList();
    }
    public abstract void StartScenario();
    public abstract void EndScenario();
    public abstract void GetNextGoal(NPC npc,int currentGoal);
    public abstract void Update();
}
