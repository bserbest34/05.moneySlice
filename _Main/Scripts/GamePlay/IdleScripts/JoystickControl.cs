using UnityEngine;

public class JoystickControl : MonoBehaviour
{
    FloatingJoystick floatingJoystick;
    CharacterController characterController;
    public float movSpeed, rotSpeed;
    internal bool isRelase = true;
    internal Animator animator;
    IdleCharacter idleMoneyManager;
    JoystickControl jControl;


    private void Awake()
    {
        UIManager.OnStart += GameStarted;
    }

    private void Start()
    {
        idleMoneyManager = GameObject.Find("Player").GetComponent<IdleCharacter>();
        animator = GetComponent<Animator>();
        floatingJoystick = GameObject.FindGameObjectWithTag("FloatingJoystick").GetComponent<FloatingJoystick>();
        characterController = GetComponent<CharacterController>();
        TutorialManager.Instance.OpenTutorial(TutorialTypes.DragAndMove, 4f, 0f);
    }

    public void Update()
    {
        SetPosition();
        SetRotation();
        SetAnimation();
        ConfigureIsRelase();
    }

    void SetRotation()
    {
        if (isRelase)
            return;
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(floatingJoystick.Horizontal, 0, floatingJoystick.Vertical));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
    }

    void SetPosition()
    {
        Vector3 direction = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
        direction.y = 0;
        characterController.Move(direction * movSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, 3.2f, transform.position.z);
    }

    void SetAnimation()
    {
        if (isRelase)
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Idle", true);
        }
        else
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Walk", true);
        }
    }

    void ConfigureIsRelase()
    {
        isRelase = floatingJoystick.Vertical == 0 && floatingJoystick.Horizontal == 0 ? true : false;

        if (idleMoneyManager.onProcess && !isRelase)
        {
            idleMoneyManager.onProcess = false;
        }
    }


    void GameStarted()
    {
        FindObjectOfType<JoystickControl>().enabled = true;
    }
}