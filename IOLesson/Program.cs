// Binary serialization
// public and private members of an object, the name of the object, and the assembly that it's part of

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

string binPath = @"C:\Users\zacharie.montreuil\source\repos\W23\IOLesson\IOLesson\ioFile.bin";

IFormatter binFormatter = new BinaryFormatter();

SerializedObject binObj = new SerializedObject() { Name = "Binfile Bob", Age = 42 };

try
{
    // serializing a C# object
    using (Stream fileStream = new FileStream(binPath, FileMode.Create, FileAccess.Write, FileShare.None))
    {
        binFormatter.Serialize(fileStream, binObj);
    }

    // deserialize: translate bin file to C# object
    using (Stream deStream = new FileStream(binPath, FileMode.Open, FileAccess.Read))
    {
        SerializedObject deserializedObject = (SerializedObject)binFormatter.Deserialize(deStream);

        Console.WriteLine(deserializedObject.Name);
        Console.WriteLine(deserializedObject.Age);
    }
} catch (IOException ex)
{
    Console.WriteLine($"I/OException: {ex.Message}");
} catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


[Serializable]
public class SerializedObject
{
    public string Name { get; set; }
    public int Age { get; set; }
}

