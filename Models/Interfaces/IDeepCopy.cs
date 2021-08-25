namespace Models
{
	public interface IDeepCopy<T> where T : class, new()
	{
		T DeepCopy();
	}
}