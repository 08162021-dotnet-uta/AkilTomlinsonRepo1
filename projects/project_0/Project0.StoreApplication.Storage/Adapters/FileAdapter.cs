using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Project0.StoreApplication.Domain.Abstracts;
//demo
namespace Project0.StoreApplicatetion.Storage.Adapters
{
  public class FileAdapter
  {
    public List<Store> ReadFromFile()
    {
      // file path
      var path = "~/revature/akil_repo/data/project_0.xml";
      // open file
      var file = new StreamReader(path);
      // serialize object
      var xml = new XmlSerializer(typeof(List<Store>));
      // read from file
      var stores = xml.Deserialize(file) as List<Store>;
      // return data
      return stores;
    }


    public void WriteToFile(List<Store> stores)
    {
      // file path
      var path = "~/revature/akil_repo/data/project_0.xml";
      // open file
      var file = new StreamWriter(path);
      // serialize object
      var xml = new XmlSerializer(typeof(List<Store>));
      // write to file
      xml.Serialize(file, stores);
      // close file
      file.Close();
    }
  }
}