namespace Saver.BL.Controller {

    internal interface IDataSaver {

        void Save<T>(string fileName, T item);

        T Load<T>(string fileName);
    }
}