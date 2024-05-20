using UnityEngine;

public class RangedWeaponAudio : AudioManager
{
    [SerializeField] private AudioClip gunshotClip;
    [SerializeField] private RangedWeapon weapon;

    private void OnEnable()
    {
        weapon.OnWeaponAttack += PlayGunshotSound;
    }

    private void OnDisable()
    {
        weapon.OnWeaponAttack -= PlayGunshotSound;
    }

    private void PlayGunshotSound(Vector3 position)
    {
        PlayClip(gunshotClip);
    }
}
