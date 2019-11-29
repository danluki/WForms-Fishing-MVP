namespace Saver.BL.Controller {

    internal interface IDataSaver {

        void Save(string fileName, object item);

        T Load<T>(string fileName);
    }
}