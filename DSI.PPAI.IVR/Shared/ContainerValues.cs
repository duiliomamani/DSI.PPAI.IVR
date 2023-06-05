namespace DSI.PPAI.IVR.Shared
{
    public class ContainerValues
    {
        public Dictionary<string, object> Value { get; set; }
        public event Action OnStateChange;
        public void SetValue(string key, object value)
        {
            Value ??= new Dictionary<string, object>();
            Value.Add(key, value);
            NotifyStateChanged();
        }
        private void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}
