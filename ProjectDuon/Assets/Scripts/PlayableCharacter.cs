using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayableCharacter : MonoBehaviour {

    //input handling
    public bool jumpInput = false;
    protected bool rightInput = false;
    protected bool leftInput = false;
    bool skill1Input = false;
    bool skill2Input = false;
    bool skill3Input = false;
    bool skill4Input = false;
    bool skill5Input = false;
    bool skill6Input = false;

    float basicSkillCooldown = 0f;
    bool skillIsActive = false;

    public bool controlEnabled = false;
    bool controlAllowed = true;

    protected GameObject generalManager;
    public GameObject generalCamera;

    public bool grounded = false;
    public bool isFacingRight = true;
    bool moving = false;
    public bool jumping = false;
    float jumpTimer = 0f;

    public Dimension homeDimension;

    public TerrainType currTerrain;
    FootstepSFXLibrary footstepSounds;
    public AudioSource audioSource;

    

    //stats
    public int maxHealth = 100;
    public int health = 100;

    public int maxStamina = 300;
    public int stamina = 300;
    public int staminaRecoveryRate = 1;
    public bool isExhausted = false;

    public float speed = 30f;
    public int jump = 10000;

    public float invulTimer = 0f;

    public List<GeneralSkill> skills;

    public bool isTakingAction = false;


    public Rigidbody2D rb2d;
    public Animator animator;

    // Use this for initialization
    public void Start()
    {
        generalCamera = GameObject.Find("GeneralCamera");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        generalManager = GameObject.Find("GeneralManager");
        controlEnabled = false;
        audioSource = GetComponent<AudioSource>();
        footstepSounds = new FootstepSFXLibrary();
    }

    // Update is called once per frame
    public void Update()
    {
        animator.SetBool("Grounded", grounded);
        animator.SetBool("Facing_Right", isFacingRight);
        animator.SetBool("Moving", moving);
        animator.SetBool("Jumping", jumping);

        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
            //generalManager.GetComponent<SceneTransitioner>().TransitionInstantlyWithFadeIn("GameOver");
        }

        if (!generalManager.GetComponent<PauseManager>().IsPaused())
        {

            //was here

            if (isFacingRight)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            if (basicSkillCooldown > 0f)
            {
                basicSkillCooldown -= Time.deltaTime;
            }


            if (generalManager.GetComponent<EventIssuer>().EventsAreOn())
            {
                controlEnabled = false;
                /*
                jumpInput = false;
                rightInput = false;
                leftInput = false;
                skill1Input = false;
                skill2Input = false;
                skill3Input = false;
                skill4Input = false;
                skill5Input = false;
                skill6Input = false;*/
            }
            else if (skillIsActive)
            {
                controlEnabled = false;
            }
            else if (generalManager.GetComponent<SceneTransitioner>().transitioning)
            {
                controlEnabled = false;
                /*
                jumpInput = false;
                rightInput = false;
                leftInput = false;
                skill1Input = false;
                skill2Input = false;
                skill3Input = false;
                skill4Input = false;
                skill5Input = false;
                skill6Input = false;*/
            }
            else
            {
                controlEnabled = controlAllowed;
            }




            if (stamina <= 0)
            {
                stamina = 0;
                isExhausted = true;
            }

            if (isExhausted && stamina == maxStamina)
            {
                isExhausted = false;
            }


            if (generalManager.GetComponent<DimensionManager>().currentDimension != homeDimension)
            {
                GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.5f);
                transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
            }
            else
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
                transform.position = new Vector3(transform.position.x, transform.position.y, -1.1f);
            }
            //input handling was here
            
            if (!generalManager.GetComponent<PauseManager>().IsPaused())
            {
                if (controlEnabled)
                {
                    if (generalManager.GetComponent<DimensionManager>().currentDimension == homeDimension)
                    {
                        ManageOneTimeInput();
                    }
                }
            }
        }
    }


    protected void ManageActions()
    {
        
        if (!generalManager.GetComponent<PauseManager>().IsPaused())
        {
            if (controlEnabled)
            {
                if (generalManager.GetComponent<DimensionManager>().currentDimension == homeDimension)
                {
                    ManageContinuousInput();
                }
            }
        }

        if (isTakingAction)
        {

        }
        else
        {
            if (stamina < maxStamina && grounded && !skillIsActive)
            {
                stamina += Mathf.Min(staminaRecoveryRate, (maxStamina - stamina));
            }
        }

        if (controlEnabled)
        {
            

            if (rightInput)
            {
                if (generalManager.GetComponent<DimensionManager>().currentDimension == homeDimension)
                {
                    //gameObject.transform.position += Vector3.right * speed * Time.fixedDeltaTime;
                    gameObject.transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
                    isFacingRight = true;
                    moving = true;
                }
                rightInput = false;
                leftInput = false;
            }
            else if (leftInput)
            {
                if (generalManager.GetComponent<DimensionManager>().currentDimension == homeDimension)
                {
                    //gameObject.transform.position += Vector3.left * speed * Time.fixedDeltaTime;
                    gameObject.transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
                    isFacingRight = false;
                    moving = true;
                }
                rightInput = false;
                leftInput = false;
            }
            else
            {
                moving = false;
            }
            animator.SetBool("Facing_Right", isFacingRight);


            if (!isExhausted && !jumping)
            {
                if (grounded)
                {
                    if (generalManager.GetComponent<DimensionManager>().currentDimension == homeDimension)
                    {
                        
                        if (jumpInput)
                        {
                            jumping = true;
                            jumpTimer = 0.4f;
                            rb2d.AddForce(Vector2.up * jump);
                            stamina -= 30;
                            jumpInput = false;
                        }
                    }
                }
            }
        }
        else
        {
            moving = false;
        }

        if (jumpTimer > 0)
        {
            jumpTimer -= Time.fixedDeltaTime;
        }
        else
        {
            jumping = false;
        }


        if (generalManager.GetComponent<DimensionManager>().currentDimension != homeDimension)
        {
            moving = false;
        }
        else
        {
            #region skillHandling
            if (grounded && !jumping)
            {
                if (skill1Input)
                {
                    if (this is Mark)
                    {
                        ExecuteSkill(SkillsHolder.markSkillSlot1);
                    }
                    else
                    {
                        ExecuteSkill(SkillsHolder.lunaSkillSlot1);
                    }

                    skill1Input = false;
                }
                else if (skill2Input)
                {
                    if (this is Mark)
                    {
                        ExecuteSkill(SkillsHolder.markSkillSlot2);
                    }
                    else
                    {
                        ExecuteSkill(SkillsHolder.lunaSkillSlot2);
                    }

                    skill2Input = false;
                }
                else if (skill3Input)
                {
                    if (this is Mark)
                    {
                        ExecuteSkill(SkillsHolder.markSkillSlot3);
                    }
                    else
                    {
                        ExecuteSkill(SkillsHolder.lunaSkillSlot3);
                    }

                    skill3Input = false;
                }
                else if (skill4Input)
                {
                    if (this is Mark)
                    {
                        ExecuteSkill(SkillsHolder.markSkillSlot4);
                    }
                    else
                    {
                        ExecuteSkill(SkillsHolder.lunaSkillSlot4);
                    }

                    skill4Input = false;
                }

            }

            #endregion
        }
    }

    protected void ManageInput()
    {
        

        
    }

    protected void ManageContinuousInput()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rightInput = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftInput = true;
        }
    }

    protected void ManageOneTimeInput()
    {
        if (!isExhausted && grounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpInput = true;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                skill1Input = true;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                skill2Input = true;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                skill3Input = true;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                skill4Input = true;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                skill5Input = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                skill6Input = true;
            }
        }
    }
    
    public void SetControlEnabled(bool enabled)
    {
        controlAllowed = enabled;
    }

    public void ExecuteSkill(GeneralSkill skill)
    {
        if (!isExhausted) {
            
            if (skill.GetType() == typeof(PlayerBasicSkill))
            {
                animator.SetTrigger(skill.name);
                stamina -= skill.staminaCost;
                generalManager.GetComponent<ComboManager>().basicSkillsUsed.Add((PlayerBasicSkill)skill);
                if (isFacingRight)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    GetComponent<Rigidbody2D>().AddForce(skill.velocityMod);
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(skill.velocityMod.x * -1, skill.velocityMod.y));
                }
                //here is shit code
                //ok code is not shit i guess
                if (this is Mark)
                {
                    generalManager.GetComponent<ComboManager>().markSkillName = skill.name;
                    generalManager.GetComponent<ComboManager>().markSkillTimer = 5f;
                }
                else
                {
                    generalManager.GetComponent<ComboManager>().lunaSkillName = skill.name;
                    generalManager.GetComponent<ComboManager>().lunaSkillTimer = 5f;
                }
            }
            else if (skill.GetType() == typeof(PlayerArt))
            {
                if (generalManager.GetComponent<ComboManager>().DetermineIfArtCanBeUsed((PlayerArt)skill))
                {
                    animator.SetTrigger(skill.name);
                    stamina -= skill.staminaCost;
                    generalManager.GetComponent<ComboManager>().basicSkillsUsed.Clear();
                    GameObject artEffect = Instantiate(Resources.Load<GameObject>("Prefabs/ArtEffect"));
                    artEffect.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.01f);
                    if (this is Mark)
                    {
                        generalManager.GetComponent<ComboManager>().markSkillName = skill.name;
                        generalManager.GetComponent<ComboManager>().markSkillTimer = 5f;
                        artEffect.GetComponent<Animator>().SetBool("IsMark", true);
                    }
                    else
                    {
                        generalManager.GetComponent<ComboManager>().lunaSkillName = skill.name;
                        generalManager.GetComponent<ComboManager>().lunaSkillTimer = 5f;
                        artEffect.GetComponent<Animator>().SetBool("IsMark", false);
                    }
                }
            }
            if (stamina <= 0)
            {
                stamina = -1;
            }
        }
    }

    public void PlayFootstepAudio()
    {
        if (currTerrain == TerrainType.STONE)
        {
            audioSource.PlayOneShot(footstepSounds.stone[Random.Range(0, footstepSounds.stone.Count)], 0.5f);
        }
        else if (currTerrain == TerrainType.WOOD)
        {
            audioSource.PlayOneShot(footstepSounds.wood[Random.Range(0, footstepSounds.wood.Count)], 0.2f);
        }
    }

    public void InitiateSkill()
    {
        skillIsActive = true;
    }

    public void FinalizeSkill()
    {
        skillIsActive = false;
    }

    public void TeleportCharacter(Vector2 vector)
    {
        transform.Translate(vector);
    }
}
