using UnityEngine;
using UnityEngine.UI;

namespace Unfair.UI
{
	public class Menu
	{
		public class MenuComponent : Graphic
		{
			public T Add<T>() where T : MenuComponent
			{
				var obj = new GameObject();
				obj.AddComponent<T>();
				obj.transform.SetParent(transform);
				
				return obj.GetComponent<T>();
			}
		}
		
		private GameObject _gameObject;
		
		// components
		private Canvas _canvas;
		private CanvasScaler _canvasScaler;
		private GraphicRaycaster _graphicRaycaster;
		
		public Menu()
		{
			_gameObject = new GameObject();
			Object.DontDestroyOnLoad(_gameObject); // so our UI doesn't kill itself when we load into a new scene
			
			// add components
			_canvas = _gameObject.AddComponent<Canvas>(); // will also create a RectTransform
			_canvasScaler = _gameObject.AddComponent<CanvasScaler>();
			_graphicRaycaster = _gameObject.AddComponent<GraphicRaycaster>();
			
			// config stuff
			_canvas.renderMode = RenderMode.ScreenSpaceOverlay;
			_canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			
			Toggle(); // hidden by default
		}
		
		// add a component to the menu
		public T Add<T>() where T : MenuComponent
		{
			var obj = new GameObject();
			obj.AddComponent<T>();
			obj.transform.SetParent(_gameObject.transform);
			
			return obj.GetComponent<T>();
		}
		
		public void Toggle()
		{
			_gameObject.SetActive(!_gameObject.activeSelf);
		}
	}
}