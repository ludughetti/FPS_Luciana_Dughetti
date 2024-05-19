using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private CharacterHealth health;
    [SerializeField] private Weapon weapon;
    [SerializeField] private string isWalkingParam = "isRunning";
    [SerializeField] private string attackAnimation = "Attack";
    [SerializeField] private string deathAnimation = "Death";

    private void OnEnable()
    {
        health.OnDeath += PlayDeathAnimation;
        weapon.OnWeaponAttack += PlayAttackAnimation;
    }

    private void OnDisable()
    {
        health.OnDeath -= PlayDeathAnimation;
        weapon.OnWeaponAttack -= PlayAttackAnimation;
    }

    private void Update()
    {
        animator.SetBool(isWalkingParam, enemyController.IsRunning());
    }

    public void PlayDeathAnimation()
    {
        animator.Play(deathAnimation);
    }

    public void PlayAttackAnimation(Vector3 position)
    {
        animator.Play(attackAnimation);
    }
}