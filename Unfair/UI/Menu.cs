using Unfair.Util;
using UnityEngine;
using UnityEngine.UI;

namespace Unfair.UI
{
	public class Menu
	{
		private GameObject _gameObject;
		
		// components
		private Canvas _canvas;
		private CanvasScaler _canvasScaler;

		public bool Enabled
		{
			get => _gameObject.activeSelf;
			set => _gameObject.SetActive(value);
		}
		
		public Menu()
		{
			_gameObject = new GameObject();
			Object.DontDestroyOnLoad(_gameObject); // so our UI doesn't kill itself when we load into a new scene
			
			// add components
			_canvas = _gameObject.AddComponent<Canvas>(); // will also create a RectTransform
			_canvasScaler = _gameObject.AddComponent<CanvasScaler>();
			_gameObject.AddComponent<GraphicRaycaster>();
			
			// using ScreenSpaceCamera here for LineRenderer
			_canvas.renderMode = RenderMode.ScreenSpaceOverlay;

			_canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			_canvasScaler.referenceResolution = new Vector2(1920, 1080);
			_canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
		}

		public T AddComponent<T>() where T : Component
		{
			GameObject obj = new GameObject();
			obj.transform.SetParent(_gameObject.transform);
			return obj.AddComponent<T>();
		}

		public void DebugRender()
		{
			Render.DrawString(new Vector2(50, 300), $"Menu active: {Enabled}");
			
			if (!_gameObject.activeSelf) return;
			
			Render.DrawString(new Vector2(50, 320), $"Menu position: {_gameObject.transform.position}");
			Render.DrawString(new Vector2(50, 340), $"Menu scale: {_gameObject.transform.localScale}");
			Render.DrawString(new Vector2(50, 360), $"Canvas size: {_canvas.pixelRect.size}");
			Render.DrawString(new Vector2(50, 380), $"Component count: {_gameObject.transform.childCount}");
		}
	}
}