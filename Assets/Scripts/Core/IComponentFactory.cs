using UnityEngine.UIElements;

public interface IComponentFactory
{
    T Create<T>() where T : VisualElement;
}
