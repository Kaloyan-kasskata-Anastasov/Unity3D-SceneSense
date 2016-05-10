using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Object = UnityEngine.Object;

[CustomEditor(typeof(Object), true)]
public class SceneSense : Editor
{

    private string[] crudBuild = { "Child", "Create", "Read", "Update", "Delete" };
    public Type[] components =
    {
        typeof(Image), typeof(RawImage), typeof(Mask),typeof(RectMask2D),typeof(Slider),typeof(Text),
        typeof(Button), typeof(ScrollRect), typeof(RectTransform), typeof(CanvasGroup), typeof(LayoutElement),
        typeof(ContentSizeFitter), typeof(HorizontalLayoutGroup), typeof(VerticalLayoutGroup), typeof(GridLayoutGroup),
        typeof(GridLayoutGroup), typeof(GridLayoutGroup), typeof(GridLayoutGroup), typeof(GridLayoutGroup)
    };

    private GenericMenu genericMenu;
    private GameObject selectedObject;
    private bool shiftDown;
    private bool ctrlDown;

    public void OnSceneGUI()
    {
        if (Event.current.type == EventType.mouseDrag || Event.current.button == 0)
        {
            return;
        }

        if (Event.current.type != EventType.KeyDown && Event.current.type != EventType.mouseDown)
        {
            return;
        }

        Event action = Event.current;
        this.selectedObject = Selection.activeGameObject;
        this.shiftDown = false;
        this.ctrlDown = false;

        if (action.shift)
        {
            this.shiftDown = true;
        }

        if (action.control)
        {
            this.ctrlDown = true;
        }

        if (action.button == 1)
        {
            this.genericMenu = new GenericMenu();

            IntellyBuild();

            // this.genericMenu.ShowAsContext();
        }
    }

    private void IntellyBuild()
    {
        Component[] componentsOfSelected = this.selectedObject.GetComponents<Component>();

        for (int i = 0; i < componentsOfSelected.Length; i++)
        {
        }
    }

    private void AddItem(string path, bool show, GenericMenu.MenuFunction2 callback, object param)
    {
        this.genericMenu.AddItem(new GUIContent(path), show, callback, param);
    }

    private void AddSeparator(string path)
    {
        this.genericMenu.AddSeparator(path);
    }
}

//if (action.control || action.shift)
//{
//    if (action.control)
//    {
//        XsTools.moveFactor = 0.01f;
//    }

//    if (action.shift)
//    {
//        XsTools.moveFactor = 0.1f;
//    }

//    if (action.keyCode == KeyCode.UpArrow)
//    {
//        XsTools.MoveSelected(XsTools.Direction.Up);
//    }

//    if (action.keyCode == KeyCode.DownArrow)
//    {
//        XsTools.MoveSelected(XsTools.Direction.Down);
//    }

//    if (action.keyCode == KeyCode.LeftArrow)
//    {
//        XsTools.MoveSelected(XsTools.Direction.Left);
//    }

//    if (action.keyCode == KeyCode.RightArrow)
//    {
//        XsTools.MoveSelected(XsTools.Direction.Right);
//    }
//}
