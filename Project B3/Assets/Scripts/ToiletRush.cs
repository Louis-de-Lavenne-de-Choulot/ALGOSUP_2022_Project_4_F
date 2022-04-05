using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ToiletRush : ScenarioBase
{
    public override void StartScenario()
    {
        boundaries[0] = spots.FindIndex(spots => spots.parent.name != "MToilets")-1;
        boundaries[1] = spots.FindIndex(boundaries[2] + 1,spots => spots.parent.name != "MToiletsWait") - 1;
        boundaries[2] = spots.FindIndex(boundaries[1] + 1,spots => spots.parent.name != "FToilets")-1;
        boundaries[3] = spots.Count - 1;
        targets = new List<string>() { "johnny","steph","alexandre","janka","nick","lindzy","lana","denis"};
        GetNPCs();
        foreach(var npc in npcs)
        {
            npc.Item1.inScenario = true;
            GetNextGoal(npc.Item1, npc.Item2);
        }
    }

    public override void EndScenario()
    {
        foreach (var npc in npcs)
        {
            npc.Item1.inScenario = false;
        }
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }
    public override void GetNextGoal(NPC npc, int currentGoal)
    {
        if(currentGoal < boundaries[0] || currentGoal > boundaries[2])
        {
            npc.inScenario = false;
            bspots[currentGoal] = false;
            npc.ChangeGoal();
            npcs.Remove((npc, currentGoal));
            return;
        }
        switch (npc.name)
        {
            case "johnny":
            case "alexandre":
            case "nick": //TODO : Add all males
                for(int i = 0; i <= boundaries[1];i++)
                {
                    if(bspots[i])
                    {
                        npc.ChangeGoal(spots[i]);
                        bspots[i] = false;
                        break;
                    }
                }
                break;
            case "steph":
            case "janka":
            case "lindzy": //TODO : Add all femoïds
                for(int i = boundaries[3]; i > boundaries[2];i--)
                {
                    if(bspots[i])
                    {
                        npc.ChangeGoal(spots[i]);
                        bspots[i] = false;
                        break;
                    }
                }
                break;
        }

    }

}
