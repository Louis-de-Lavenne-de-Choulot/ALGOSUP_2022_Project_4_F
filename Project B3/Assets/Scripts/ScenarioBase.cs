using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ScenarioBase : MonoBehaviour
{
    public bool active = false;
    public List<NPC> npcs;
    public List<string> targets;
    public List<Transform> spots;
    [HideInInspector]
    public List<bool> bspots;
    public virtual List<NPC> GetNPCs()
    {
        List<GameObject> tmp = GameObject.FindGameObjectsWithTag("NPC").Where(npc => targets.Contains(npc.name)).ToList();
        Debug.Log($"TMP count : {tmp.Count}");
        Debug.Log(tmp[0]);
        List<NPC> _npcs = new List<NPC>();
        foreach(GameObject npc in tmp)
        {
            _npcs.Add(npc.GetComponent<NPC>());
        }
        Debug.Log($"NPC count : {_npcs.Count}");
        return _npcs;
    }
    public abstract void StartScenario();
    public abstract void EndScenario();
    public abstract IEnumerator GetNextGoal(NPC npc);
}
