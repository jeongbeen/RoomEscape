using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public class DoorControls
    {
        public float openingSpeed = 1;
        public float closingSpeed = 1.3f;
        public float closeStartFrom = 0.6f;
        public KeyCode openButton = KeyCode.E;
        public bool autoClose = false;
        public float OpenedAtStart = 0;
    }
    public class AnimNames
    {
        public string OpeningAnim = "Door_open";
        public string LockedAnim = "Door_locked";
    }

    public string PlayerHeadTag = "Player";
    public Transform knob;

    public DoorControls controls = new DoorControls();
    public AnimNames AnimationNames = new AnimNames();

    Transform player;
    bool Opened = false;
    bool inZone = false;
    Canvas TextObj;
    Animation doorAnimation;
    Animation LockAnim;

    void Start()
    {
        doorAnimation = GetComponent<Animation>();

        if (controls.OpenedAtStart > 0)
        {
            doorAnimation[AnimationNames.OpeningAnim].normalizedTime = controls.OpenedAtStart;
            doorAnimation[AnimationNames.OpeningAnim].speed = 0;
            doorAnimation.Play(AnimationNames.OpeningAnim);
        }
    }

    void Update()
    {
        if (Opened)
        {
            CloseDoor();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != PlayerHeadTag)
            return;

        inZone = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag != PlayerHeadTag)
            return;

        CloseDoor();

        inZone = false;
    }

    void OpenDoor()
    {
        doorAnimation[AnimationNames.OpeningAnim].speed = controls.openingSpeed;
        doorAnimation[AnimationNames.OpeningAnim].normalizedTime = doorAnimation[AnimationNames.OpeningAnim].normalizedTime;
        doorAnimation.Play(AnimationNames.OpeningAnim);

        Opened = true;
    }

    void CloseDoor()
    {
        if (doorAnimation[AnimationNames.OpeningAnim].normalizedTime < 0.98f && doorAnimation[AnimationNames.OpeningAnim].normalizedTime > 0)
        {
            doorAnimation[AnimationNames.OpeningAnim].speed = -controls.closingSpeed;
            doorAnimation[AnimationNames.OpeningAnim].normalizedTime = doorAnimation[AnimationNames.OpeningAnim].normalizedTime;
            doorAnimation.Play(AnimationNames.OpeningAnim);
        }
        else
        {
            doorAnimation[AnimationNames.OpeningAnim].speed = -controls.closingSpeed;
            doorAnimation[AnimationNames.OpeningAnim].normalizedTime = controls.closeStartFrom;
            doorAnimation.Play(AnimationNames.OpeningAnim);
        }
        if (doorAnimation[AnimationNames.OpeningAnim].normalizedTime > controls.closeStartFrom)
        {
            doorAnimation[AnimationNames.OpeningAnim].speed = -controls.closingSpeed;
            doorAnimation[AnimationNames.OpeningAnim].normalizedTime = controls.closeStartFrom;
            doorAnimation.Play(AnimationNames.OpeningAnim);
        }
        Opened = false;
    }
}
