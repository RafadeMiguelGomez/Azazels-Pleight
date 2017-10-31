using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
//Este namespace es el que se encarga del manejo de archivos
using System.IO;

public class Serializacion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		        //Creamos una variable del tipo de la clase que vamos a serializar
        ClassToSerialize test = new ClassToSerialize();

        //Le damos valores al primer campo publico
        test.PublicField1 = 150;
		test.Jugador = "Marcel";

        //Le damos valor al segundo campo publico
        test.PublicField2 = "Casa de la abuela";

        SaveXML<ClassToSerialize>(Application.dataPath+"/Data/", "MyXML.xml", test);
    }

	    public static void SaveXML<T>(string path, string fileName, object data) where T : class
    {
Debug.Log(path);
        Directory.CreateDirectory(path).Create();
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        if (!fileName.Contains(".xml"))
            fileName += ".xml";
        FileStream stream = new FileStream(path + fileName, FileMode.Create);
        StreamWriter streamWriter = new StreamWriter(stream, System.Text.Encoding.UTF8);
        serializer.Serialize(streamWriter, data);
        stream.Close();
        streamWriter.Close();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	[System.Serializable]
	public class ClassToSerialize
	{
   		    public int PublicField1;
		    public string Jugador;	
   		    public string PublicField2;

        	public void Method1()
        	{
             //hacer algo
        	}
	}

}
