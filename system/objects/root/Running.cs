namespace Butterfly
{
    public class Butterfly
    {
        public static void fly<ObjectType>() where ObjectType : system.objects.main.Object, new()
        {
            ((system.objects.root.description.ILife)new system.objects.root.Object<ObjectType>()).Run();
        }
    }
}