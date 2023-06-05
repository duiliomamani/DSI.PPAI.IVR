using System.Reflection;

namespace DSI.PPAI.IVR.Domain.BaseTypes
{
    /// <summary>
    /// All the Enumerations inherit from this class. Such as Status, etc.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseEnum<T> : BaseObject where T : BaseEnum<T>, new()
    {
        private static readonly Dictionary<string, IList<T>> EnumsDictionary = new();

        private static readonly object _lockObject = new();

        private readonly string _descripcion;

        public BaseEnum() : base() { }
        public BaseEnum(string descripcion) : base()
        {
            _descripcion = descripcion;
        }

        public string getDescripcion() => _descripcion;
        public override string ToString() => _descripcion;
        public override bool Equals(object? obj)
        {
            if (obj is not BaseEnum<T> otherValue)
            {
                return false;
            }

            var typeMatches = GetType() == obj.GetType();
            var valueMatches = _descripcion.Equals(otherValue._descripcion);
            return typeMatches && valueMatches;
        }
        public override int GetHashCode() => (GetType().GetHashCode() * 3) + _descripcion.GetHashCode();
        public int CompareTo(object? obj)
        {
            if (obj == null)
                return 0;

            return _descripcion.CompareTo(((BaseEnum<T>)obj)._descripcion);
        }
        public static IEnumerable<T> GetAllValues()
        {
            var type = typeof(T);

            lock (_lockObject)
            {
                if (!EnumsDictionary.ContainsKey(type.ToString()))
                {
                    var fields = type.GetTypeInfo().GetFields(BindingFlags.Public |
                                                              BindingFlags.Static |
                                                              BindingFlags.DeclaredOnly);
                    var items = new List<T>();
                    foreach (var info in fields)
                    {
                        var instance = new T();
                        if (info.GetValue(instance) is T locatedValue)
                        {
                            items.Add(locatedValue);
                        }
                    }

                    EnumsDictionary.Add(type.ToString(), items);
                }
            }

            foreach (var item in EnumsDictionary[type.ToString()])
            {
                yield return item;
            }
        }
        public static T? GetOneValue(string descripcion) => GetAllValues().FirstOrDefault(e => e._descripcion == descripcion);
    }
}
