using System.Text.Json.Serialization;

[
JsonDerivedType(typeof(MondayDriverColumnStatusSettingSchema)),
JsonDerivedType(typeof(MondayDriverColumnDropDownSettingSchema))
]
public class MondayDriverColumnSettingSchema{

    public static MondayDriverColumnSettingSchema Create(){
        return new MondayDriverColumnSettingSchema();
    }

}