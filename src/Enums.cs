global using static LizardTemplate.Enums;
namespace LizardTemplate;

public class Enums
{
    public class CreatureTemplateType
    {
        // change TestLizard to your lizard's name
        public static CreatureTemplate.Type TestLizard = new(nameof(TestLizard), true);
        public void UnregisterValues()
        {
            if (TestLizard != null)
            {
                TestLizard.Unregister();
                TestLizard = null;
            }
        }
    }

    public class SandboxUnlockID
    {
        // same as above
        public static MultiplayerUnlocks.SandboxUnlockID TestLizard = new(nameof(TestLizard), true);

        public void UnregisterValues()
        {
            if (TestLizard != null)
            {
                TestLizard.Unregister();
                TestLizard = null;
            }
        }
    }
}
