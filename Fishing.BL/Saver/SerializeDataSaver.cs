using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Saver.BL.Controller {

    public class SerializeDataSaver : IDataSaver {

        public T Load<T>(string fileName) {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate)) {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items) {
                    return items;
                }
                return default;
            }
        }

        public void Save<T>(string fileName, T item) {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate)) {
                formatter.Serialize(fs, item);               
            }
        }
    }
}
