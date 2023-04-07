using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class DialogueClip : PlayableAsset, ITimelineClipAsset
{
    // public int countCreatedClip = 0;
    public DialogueBehaviour template = new DialogueBehaviour ();
    public ClipCaps clipCaps
    {
        get { return ClipCaps.None; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<DialogueBehaviour>.Create (graph, template);
        //countCreatedClip = playable.GetInputCount();
        // countCreatedClip = owner.;
        // Debug.Log("Total Clip = " + countCreatedClip);
        return playable;
    }
}
