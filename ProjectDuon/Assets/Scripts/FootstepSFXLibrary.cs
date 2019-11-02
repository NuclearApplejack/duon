using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSFXLibrary {

    public List<AudioClip> stone = new List<AudioClip>();
    public List<AudioClip> wood = new List<AudioClip>();

    public FootstepSFXLibrary()
    {
        stone.Add(Resources.Load("Sound/SFX/Footsteps/footstep stone 1") as AudioClip);

        wood.Add(Resources.Load("Sound/SFX/Footsteps/footstep wood 1") as AudioClip);
        wood.Add(Resources.Load("Sound/SFX/Footsteps/footstep wood 2") as AudioClip);
        wood.Add(Resources.Load("Sound/SFX/Footsteps/footstep wood 3") as AudioClip);

    }
	
}
