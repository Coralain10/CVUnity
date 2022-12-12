public class TargetInfo
{
    public string name;
    public string spriteName;

    public TargetInfo (string name, string spriteName)
    {
        this.name        = name;
        this.spriteName  = spriteName;
    }
}

//////////////////////////////////////////////////

public enum TypeStar {
    Education,
    GameRel,
    Work,
}

public class StarInfo : TargetInfo
{
    public TypeStar type;
    public string description;
    public StarInfo (TypeStar type, string name, string spriteName, string description)
    : base(name, spriteName)
    {
        this.type        = type;
        this.description = description;
    }
}

//////////////////////////////////////////////////

public enum TypeSkill {
    Software,
    Language,
    Database,
    WebF,
}

public class SkillInfo : TargetInfo
{
    public TypeSkill type;
    public byte progress; //[0-100]
    public SkillInfo (TypeSkill type, string name, string spriteName, byte progress)
    : base(name, spriteName)
    {
        this.type        = type;
        this.progress    = progress;
    }
}