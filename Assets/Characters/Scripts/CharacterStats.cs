using System.Collections;
using System.Collections.Generic;
using UnityEngine;


struct Skill
{
    // Constants for stat system
    const uint levelCap = 99;
    const uint expBase = 100;

    // This is for actual skill statistics
    string name;
    public string Name { get => name; }

    uint exp;
    public uint EXP { get => exp; private set 
        {
            exp = value;
        } 
    }
    uint level;
    public uint Level
    {
        get => level;
        private set
        {
            if (level < levelCap)
            {
                level = value;
            }
        }
    }

    public Skill(string n, uint l)
    {
        name = n;
        exp = 0;
        level = l;
    }

    void LevelUp()
    {
        // Only level up if we are below the level cap.
        if (EXP < levelCap)
        {
            Level += 1;
            EXP = 0; // Reset for new level.
        }
    }

    uint NextLevelExp()
    {
        return (expBase ^ Level+1) - (expBase - Level+1);
    }

    public void Experience(uint e)
    {
        EXP += e;
        if (EXP >= NextLevelExp())
        {
            LevelUp();
        }
    }
}

public class CharacterStats : MonoBehaviour
{
    // Core Skills
    [SerializeField]
    protected float maxHealth = 100.0f;

    protected float health;
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            Health += value;
            // Clamp logic
            if (health > maxHealth)
            {
                health = maxHealth;
            }
            else if (health < 0.0f)
            {
                health = 0.0f;
            }
        }
    }
    [SerializeField]
    protected float maxMagic = 100.0f;
    protected float magic;
    public float Magic
    {
        get
        {
            return magic;
        }
        set
        {
            Health += value;
            // Clamp logic
            if (magic > maxMagic)
            {
                magic = maxMagic;
            }
            else if (magic < 0.0f)
            {
                magic = 0.0f;
            }
        }
    }
    // It is a flaw to serialize skill titles, but oh well, at least the default levels can be changed for different characters
    [SerializeField]
    uint initialStamina = 1;
    Skill stamina;
    [SerializeField]
    uint initialStrength = 1;
    Skill strength;
    [SerializeField]
    uint initialCharisma = 1;
    Skill charisma;
    [SerializeField]
    uint initialStealth = 1;
    Skill stealth;
    [SerializeField]
    uint initialIntelligence = 1;
    Skill intelligence;
    [SerializeField]
    uint initialMedicine = 1;
    Skill medicine;
    [SerializeField]
    uint initialSpirituality = 1;
    Skill spirituality;

    // Do not reference other scripts in Awake, use Start instead
    private void Awake()
    {
        // Initialize all skills
        stamina = new Skill("Stamina", initialStamina);
        strength = new Skill("Strength", initialStrength);
        charisma = new Skill("Charisma", initialCharisma);
        stealth = new Skill("Stealth", initialStealth);
        intelligence = new Skill("Intelligence", initialIntelligence);
        medicine = new Skill("Medicine", initialMedicine);
        spirituality = new Skill("Spirituality", initialSpirituality);

        health = maxHealth;
        magic = maxMagic;
    }

    // FixedUpdate is called once per physics tick
    void FixedUpdate()
    {
        // Auto-regen health
        if (Health < maxHealth)
        {
            Health += 0.001f * medicine.Level;
        }
    }
}