using System;
using System.Reflection;
using System.Linq;

class Program {
    static void Main() {
        try {
            Assembly.LoadFrom(@"..\..\..\SharpDX.dll");
            Assembly.LoadFrom(@"..\..\..\SharpDX.Mathematics.dll");
            var asm = Assembly.LoadFrom(@"..\..\..\ExileCore.dll");
            var t = asm.GetTypes().FirstOrDefault(x => x.Name == "ItemsOnGroundLabelElement");
            if (t != null) {
                Console.WriteLine("Properties of " + t.Name + ":");
                foreach (var p in t.GetProperties()) {
                    Console.WriteLine("  " + p.Name + " (" + p.PropertyType.Name + ")");
                }
            } else {
                Console.WriteLine("Type ItemsOnGroundLabelElement not found.");
            }
        } catch (ReflectionTypeLoadException ex) {
            foreach (var e in ex.LoaderExceptions) {
                Console.WriteLine(e.Message);
            }
        } catch (Exception ex) {
            Console.WriteLine(ex.ToString());
        }
    }
}
