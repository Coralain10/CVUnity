public static class TargetsInfo
{
    public const string description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.";
    
    public static readonly StarInfo[] StarsInfo = {
        //Activities
        new StarInfo( TypeStar.GameRel   , "nameAc1"     , "inst_upc_gl"     , description ),
        new StarInfo( TypeStar.GameRel   , "nameAc2"     , "inst_stgj"       , description ),
        new StarInfo( TypeStar.GameRel   , "nameAc3"     , "inst_upc_jg"     , description ),
        new StarInfo( TypeStar.GameRel   , "nameAc4"     , "inst_ntwjam"     , description ),
        new StarInfo( TypeStar.GameRel   , "nameAc5"     , "inst_lgm_past"   , description ),
        new StarInfo( TypeStar.GameRel   , "nameAc6"     , "inst_lgj"        , description ),
        //Education
        new StarInfo( TypeStar.Education , "nameEd1"     , "inst_coar"       , description ),
        new StarInfo( TypeStar.Education , "nameEd2"     , "inst_upc_av"     , description ),
        new StarInfo( TypeStar.Education , "nameEd3"     , "inst_isil_ds"    , description ),
        new StarInfo( TypeStar.Education , "nameEd4"     , "inst_upc_cc"     , description ),
        //Experience
        new StarInfo( TypeStar.Work      , "nameEx1"     , "inst_clbs"       , description ),
        new StarInfo( TypeStar.Work      , "nameEx2"     , "inst_isil"       , description ),
        new StarInfo( TypeStar.Work      , "nameEx3"     , "inst_isil"       , description ),
        new StarInfo( TypeStar.Work      , "nameEx4"     , "inst_make3D"     , description ),
    };

    public static readonly SkillInfo[] SkillsInfo = {
        //Education I
        new SkillInfo( TypeSkill.Language , "csharp"     , "sw_csharp"     , 60 ),
        new SkillInfo( TypeSkill.Software , "vstudio"    , "sw_vstudio"    , 50 ),
        new SkillInfo( TypeSkill.Software , "arduino"    , "sw_arduino"    , 30 ),
        new SkillInfo( TypeSkill.Language , "js"         , "sw_js"         , 80 ),
        new SkillInfo( TypeSkill.WebF     , "jquery"     , "sw_jquery"     , 50 ),
        new SkillInfo( TypeSkill.Database , "sqlserver"  , "sw_sqlserver"  , 50 ),
        new SkillInfo( TypeSkill.Database , "mysql"      , "sw_mysql"      , 50 ),
        //Education U
        new SkillInfo( TypeSkill.Language , "cplusplus"  , "sw_cplusplus"  , 60 ),
        new SkillInfo( TypeSkill.Language , "python"     , "sw_python"     , 70 ),
        new SkillInfo( TypeSkill.WebF     , "typescript" , "sw_typescript" , 80 ),
        new SkillInfo( TypeSkill.WebF     , "react"      , "sw_react"      , 50 ),
        new SkillInfo( TypeSkill.WebF     , "angular"    , "sw_angular"    , 50 ),
        new SkillInfo( TypeSkill.Database , "postgres"   , "sw_postgres"   , 30 ),
        new SkillInfo( TypeSkill.Software , "git"        , "sw_git"        , 30 ),
        //Experience
        new SkillInfo( TypeSkill.Software     , "unity"      , "sw_unity"      , 30 ),
    };
}