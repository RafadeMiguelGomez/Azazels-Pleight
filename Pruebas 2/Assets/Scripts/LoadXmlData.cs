using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;


public class LoadXmlData : MonoBehaviour // the Class
{

	

	public TextAsset gameAsset;
	
	List<string[]> preguntas = new List<string[]>();

	
	
	void Start()
	{	//Timeline of the Level creator
	Debug.Log("Se lanza");
		GetLevel();
	}
	
	public void GetLevel()
	{  
		
		MemoryStream assetstream = new MemoryStream(gameAsset.bytes);
        XmlReader xreader = XmlReader.Create(assetstream);
		XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
		
		xmlDoc.Load(xreader); // load the file.
		
		XmlNodeList levelsList = xmlDoc.GetElementsByTagName("questions"); // array of the level nodes.

		Debug.Log(levelsList[0].ChildNodes[0].ChildNodes[1].InnerText);

		}
	}
	


