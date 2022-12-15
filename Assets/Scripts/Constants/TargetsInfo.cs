using System.Linq;

public static class TargetsInfo
{
    public const string description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.";
    
    public static StarInfo[] StarsInfo = setIds( new StarInfo[] {
        //Activities
        new StarInfo( TypeStar.GameRel   , "nameAc1"     , "inst_upc_gl"     , description ), //  0 ,
        new StarInfo( TypeStar.GameRel   , "nameAc2"     , "inst_stgj"       , description ), //  1 ,
        new StarInfo( TypeStar.GameRel   , "nameAc3"     , "inst_upc_jg"     , description ), //  2 ,
        new StarInfo( TypeStar.GameRel   , "nameAc4"     , "inst_ntwjam"     , description ), //  3 ,
        new StarInfo( TypeStar.GameRel   , "nameAc5"     , "inst_lgm_past"   , description ), //  4 ,
        new StarInfo( TypeStar.GameRel   , "nameAc6"     , "inst_lgj"        , description ), //  5 ,
        //Education
        new StarInfo( TypeStar.Education , "nameEd1"     , "inst_coar"       , description ), //  6 ,
        new StarInfo( TypeStar.Education , "nameEd2"     , "inst_upc_av"     , description ), //  7 ,
        new StarInfo( TypeStar.Education , "nameEd3"     , "inst_isil_ds"    , description ), //  8 ,
        new StarInfo( TypeStar.Education , "nameEd4"     , "inst_upc_cc"     , description ), //  9 ,
        //Experience
        new StarInfo( TypeStar.Work      , "nameEx1"     , "inst_clbs"       , description ), // 10 ,
        new StarInfo( TypeStar.Work      , "nameEx2"     , "inst_isil"       , description ), // 11 ,
        new StarInfo( TypeStar.Work      , "nameEx3"     , "inst_isil"       , description ), // 12 ,
        new StarInfo( TypeStar.Work      , "nameEx4"     , "inst_make3D"     , description ) // 13 ,
    });

    public static SkillInfo[] SkillsInfo = setIds( new SkillInfo[] {
        //Education I
        new SkillInfo( TypeSkill.Language , "csharp"     , "sw_csharp"     , 60 ), //  0 ,
        new SkillInfo( TypeSkill.Software , "vstudio"    , "sw_vstudio"    , 50 ), //  1 ,
        new SkillInfo( TypeSkill.Software , "arduino"    , "sw_arduino"    , 30 ), //  2 ,
        new SkillInfo( TypeSkill.Language , "js"         , "sw_js"         , 80 ), //  3 ,
        new SkillInfo( TypeSkill.WebF     , "jquery"     , "sw_jquery"     , 50 ), //  4 ,
        new SkillInfo( TypeSkill.Database , "sqlserver"  , "sw_sqlserver"  , 50 ), //  5 ,
        new SkillInfo( TypeSkill.Database , "mysql"      , "sw_mysql"      , 50 ), //  6 ,
        //Education U
        new SkillInfo( TypeSkill.Language , "cplusplus"  , "sw_cplusplus"  , 60 ), //  7 ,
        new SkillInfo( TypeSkill.Language , "python"     , "sw_python"     , 70 ), //  8 ,
        new SkillInfo( TypeSkill.WebF     , "typescript" , "sw_typescript" , 80 ), //  9 ,
        new SkillInfo( TypeSkill.WebF     , "react"      , "sw_react"      , 50 ), // 10 ,
        new SkillInfo( TypeSkill.WebF     , "angular"    , "sw_angular"    , 50 ), // 11 ,
        new SkillInfo( TypeSkill.Database , "postgres"   , "sw_postgres"   , 30 ), // 12 ,
        new SkillInfo( TypeSkill.Software , "git"        , "sw_git"        , 30 ), // 13 ,
        //Experience
        new SkillInfo( TypeSkill.Software , "unity"      , "sw_unity"      , 30 ) // 14 ,
    });

    // public static readonly StarInfo[] StarsInfo   = _starsInfo;
    // public static readonly SkillInfo[] SkillsInfo = _skillsInfo;

    // public static readonly StarInfo[] StarsInfoByType = StarsInfo.OrderBy(s => s.type).ToArray();
    // public static readonly SkillInfo[] SkillsInfoByType = SkillsInfo.OrderBy(s => s.type).ToArray();

    private static StarInfo[] setIds(StarInfo[] array)
    {
        for (int i = 0; i < array.Length; i++ )
            array[i].id = i;

        array = array.OrderBy(s => s.type).ToArray();

        for (int i = 0; i < array.Length; i++ )
            array[i].idByType = i;
        
        return array;
    }
    private static SkillInfo[] setIds(SkillInfo[] array)
    {
        for (int i = 0; i < array.Length; i++ )
            array[i].id = i;

        array = array.OrderBy(s => s.type).ToArray();

        for (int i = 0; i < array.Length; i++ )
            array[i].idByType = i;
        
        return array;
    }
}