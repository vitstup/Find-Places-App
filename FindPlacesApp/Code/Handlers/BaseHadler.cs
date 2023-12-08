namespace FindPlacesApp.Code.Handlers
{
	public abstract class BaseHadler<T>
	{
		private T value;

		public void Save(T value)
		{
			this.value = value;
		}

		public T Get() => value;
	}
}