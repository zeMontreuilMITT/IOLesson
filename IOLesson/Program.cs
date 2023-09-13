// Binary serialization
// public and private members of an object, the name of the object, and the assembly that it's part of

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

string path = @"C:\Users\zacharie.montreuil\source\repos\W23\IOLesson\IOLesson\ioFile.json";

SerializedObject serObj = new SerializedObject() { Name = "Name", Age = 32 };

string jsonString = JsonSerializer.Serialize(serObj);

Console.WriteLine(jsonString);

try
{
    //File.WriteAllText(path, jsonString);
    string textJson = File.ReadAllText(path);

    serObj = JsonSerializer.Deserialize<SerializedObject>(textJson);

    Console.WriteLine(serObj.ToString());
} catch (Exception ex)
{
    Console.WriteLine(ex.ToString());   
}





[Serializable]
public class SerializedObject
{
    public string Name { get; set; }
    public int Age { get; set; }
}

