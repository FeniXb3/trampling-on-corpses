using UnityEngine;

namespace Services
{
	public interface ILocalStorageService
	{
		void SetColor(string name, Color value);

		Color GetColor(string name);

		bool HasColorKey(string key);

		void DeleteColorKey(string key);
	}
}
