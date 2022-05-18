using System.Collections.ObjectModel;
using Data;

namespace Logic
{
    public abstract class LogicAbstractApi
    {
        public static LogicAbstractApi CreateLogicApi() => new LogicApi();
    }
}