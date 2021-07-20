using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Reflection;
using System;

public class ViewEditor : EditorWindow
{


    private Vector2 _scrollpos = Vector2.zero;


    //ウィンドウ作成
    [MenuItem("Window/EditorEx")]
    static void Open()
    {
        EditorWindow.GetWindow<ViewEditor>("EditorEx");
    }
    /// <summary>
    /// 変数をすべて取得最初の列にはスクリプト名、その後変数名、変数の型、変数情報の数が連続して格納されている
    /// </summary>
    private object[][] _labelArea = new object[0][];
    /// <summary>
    /// 選択しているオブジェクトを全て入れる
    /// </summary>
    private List<GameObject> AllObjects;
    //各変数の型に合わせて配列に連続で保存する。変数の個数分、出力していくcountは配列ごとに何個目まで参照したかのポインタとして使用する
    private List<GameObject> _getgameobjects = new List<GameObject>();
    private int _gameobjectcount = default;
    private List<int> _intobjects = new List<int>();
    private int _intobjectcount=default;
    private List<float> _floatobjects = new List<float>();
    private int _floatobjectcount = default;
    private List<double> _doubleobjects = new List<double>();
    private int _doubleobjectcount = default;
    private List<string> _stringobjects = new List<string>();
    private int _stringobjectcount = default;
    private List<bool> _boolobjects = new List<bool>();
    private int _boolobjectcount = default;
    private List<MonoBehaviour> allMonobehaviourList;
    private string _scriptname = "";
    private bool _scriptchanged = false;
    private bool[] _isoepn = new bool[0];
    private bool[] _arrayopen = new bool[0];
    private int _arrayopencount = default;

    //ウィンドウに表示
    void OnGUI()
    {
        if (Selection.activeGameObject != null)
        {
            if (GUILayout.Button("Enter"))
            Find();

            _scrollpos = EditorGUILayout.BeginScrollView(_scrollpos, GUI.skin.box);
            {
                _intobjectcount = 0;
                _floatobjectcount = 0;
                _doubleobjectcount = 0;
                _stringobjectcount = 0;
                _gameobjectcount = 0;
                _boolobjectcount = 0;
                _arrayopencount = 0;
                for (int i = 0; i < _labelArea.Length; i++)
                {
                    _isoepn[i] = EditorGUILayout.Foldout(_isoepn[i], (string)_labelArea[i][0]);
                    if (_isoepn[i])
                    {
                        for (int j = 1; j < _labelArea[i].Length; j += 3)
                        {
                            if (_labelArea[i][j + 1].ToString().Contains("Int"))
                            {

                                if (Convert.ToInt32(_labelArea[i][j + 2]) > 1)
                                {
                                    _arrayopen[_arrayopencount] = EditorGUILayout.Foldout(_arrayopen[_arrayopencount], (string)_labelArea[i][j]);
                                    if (_arrayopen[_arrayopencount])
                                    {
                                        for (int k = 0; k < Convert.ToInt32(_labelArea[i][j + 2]); k++)
                                        {
                                            _intobjects[_intobjectcount] = EditorGUILayout.IntField(_intobjects[_intobjectcount]);
                                            _intobjectcount++;
                                        }
                                    }
                                    _arrayopencount++;
                                }
                                else if (Convert.ToInt32(_labelArea[i][j + 2]) == 1)
                                {
                                    _intobjects[_intobjectcount] = EditorGUILayout.IntField((string)_labelArea[i][j], 0);
                                    _intobjectcount++;

                                }
                            }
                            else if (_labelArea[i][j + 1].ToString().Contains("Single"))
                            {
                                if (Convert.ToInt32(_labelArea[i][j + 2]) > 1)
                                {
                                    _arrayopen[_arrayopencount] = EditorGUILayout.Foldout(_arrayopen[_arrayopencount], (string)_labelArea[i][j]);
                                    if (_arrayopen[_arrayopencount])
                                    {
                                        for (int k = 0; k < Convert.ToInt32(_labelArea[i][j + 2]); k++)
                                        {
                                            _floatobjects[_floatobjectcount] = EditorGUILayout.FloatField(_floatobjects[_floatobjectcount]);
                                            _floatobjectcount++;
                                        }
                                    }
                                    _arrayopencount++;
                                }
                                else if (Convert.ToInt32(_labelArea[i][j + 2]) == 1)
                                {
                                    _floatobjects[_floatobjectcount] = EditorGUILayout.FloatField((string)_labelArea[i][j], 0);
                                    _floatobjectcount++;
                                }
                            }
                            else if (_labelArea[i][j + 1].ToString().Contains("Double"))
                            {
                                if (Convert.ToInt32(_labelArea[i][j + 2]) > 1)
                                {
                                    _arrayopen[_arrayopencount] = EditorGUILayout.Foldout(_arrayopen[_arrayopencount], (string)_labelArea[i][j]);
                                    if (_arrayopen[_arrayopencount])
                                    {
                                        for (int k = 0; k < Convert.ToInt32(_labelArea[i][j + 2]); k++)
                                        {
                                            _doubleobjects[_doubleobjectcount] = EditorGUILayout.DoubleField(_doubleobjects[_doubleobjectcount]);
                                            _doubleobjectcount++;
                                        }
                                    }
                                    _arrayopencount++;
                                }
                                else if (Convert.ToInt32(_labelArea[i][j + 2]) == 1)
                                {
                                    _doubleobjects[_doubleobjectcount] = EditorGUILayout.DoubleField((string)_labelArea[i][j], 0);
                                    _doubleobjectcount++;
                                }
                            }
                            else if (_labelArea[i][j + 1].ToString().Contains("String"))
                            {
                                if (Convert.ToInt32(_labelArea[i][j + 2]) > 1)
                                {
                                    _arrayopen[_arrayopencount] = EditorGUILayout.Foldout(_arrayopen[_arrayopencount], (string)_labelArea[i][j]);
                                    if (_arrayopen[_arrayopencount])
                                    {
                                        for (int k = 0; k < Convert.ToInt32(_labelArea[i][j + 2]); k++)
                                        {
                                            _stringobjects[_stringobjectcount] = EditorGUILayout.TextField(_stringobjects[_stringobjectcount]);
                                            _stringobjectcount++;
                                        }
                                    }
                                    _arrayopencount++;
                                }
                                else if (Convert.ToInt32(_labelArea[i][j + 2]) == 1)
                                {
                                    _stringobjects[_stringobjectcount] = EditorGUILayout.TextField((string)_labelArea[i][j], "");
                                    _stringobjectcount++;
                                }
                            }
                            else if (_labelArea[i][j + 1].ToString().Contains("GameObject"))
                            {
                                if (Convert.ToInt32(_labelArea[i][j + 2]) > 1)
                                {
                                    _arrayopen[_arrayopencount] = EditorGUILayout.Foldout(_arrayopen[_arrayopencount], (string)_labelArea[i][j]);
                                    if (_arrayopen[_arrayopencount])
                                    {
                                        for (int k = 0; k < Convert.ToInt32(_labelArea[i][j + 2]); k++)
                                        {
                                            _getgameobjects[_gameobjectcount] = (GameObject)EditorGUILayout.ObjectField(_getgameobjects[_gameobjectcount], typeof(GameObject));
                                            _gameobjectcount++;
                                        }
                                    }
                                    _arrayopencount++;
                                }
                                else if(Convert.ToInt32(_labelArea[i][j + 2]) == 1)
                                {
                                    _getgameobjects[_gameobjectcount] = (GameObject)EditorGUILayout.ObjectField((string)_labelArea[i][j], null, typeof(GameObject));
                                    _gameobjectcount++;
                                }
                            }
                            else if (_labelArea[i][j + 1].ToString().Contains("Bool"))
                            {
                                if (Convert.ToInt32(_labelArea[i][j + 2]) > 1)
                                {
                                    _arrayopen[_arrayopencount] = EditorGUILayout.Foldout(_arrayopen[_arrayopencount], (string)_labelArea[i][j]);
                                    if (_arrayopen[_arrayopencount])
                                    {
                                        for (int k = 0; k < Convert.ToInt32(_labelArea[i][j + 2]); k++)
                                        {
                                            _boolobjects[_boolobjectcount] = EditorGUILayout.Toggle(_boolobjects[_boolobjectcount]);
                                            _boolobjectcount++;
                                        }
                                    }
                                    _arrayopencount++;
                                }
                                else if(Convert.ToInt32(_labelArea[i][j + 2]) == 1)
                                {
                                    _boolobjects[_boolobjectcount] = EditorGUILayout.Toggle((string)_labelArea[i][j], _boolobjects[_boolobjectcount]);
                                    _boolobjectcount++;
                                }
                            }
                        }
                    }
                }
            }
            EditorGUILayout.EndScrollView();
        }
        else
        {
            _labelArea = new string[0][];
            AllObjects = new List<GameObject>();
            _getgameobjects = new List<GameObject>();
            _intobjects = new List<int>();
            _floatobjects = new List<float>();
            _doubleobjects = new List<double>();
            _stringobjects = new List<string>();
            _boolobjects = new List<bool>();
            allMonobehaviourList = new List<MonoBehaviour>();
        }

    }


    //選択しているオブジェクトのメソッドと変数をリストに入れる
    private void Find()
    {
        _labelArea = new string[0][];
        AllObjects = new List<GameObject>();
        _getgameobjects = new List<GameObject>();
        _intobjects = new List<int>();
        _floatobjects = new List<float>();
        _doubleobjects = new List<double>();
        _stringobjects = new List<string>();
        _boolobjects = new List<bool>();
        allMonobehaviourList = new List<MonoBehaviour>();

        _intobjectcount = 0;
        _floatobjectcount = 0;
        _doubleobjectcount = 0;
        _stringobjectcount = 0;
        _gameobjectcount = 0;
        _boolobjectcount = 0;
        _arrayopencount = 0;

        AllObjects.Add(Selection.activeGameObject);
        int _classcount = 0;
        int _fieldcount = 0;

        allMonobehaviourList.AddRange(GetComponentsInList<MonoBehaviour>(AllObjects));
        foreach (var componentData in allMonobehaviourList)
        {
            if (!componentData.GetType().ToString().Contains("UnityEngine"))
            {
                _classcount++;
            }
        }
        _labelArea = new string[_classcount][];
        _isoepn = new bool[_classcount];
        _classcount = 0;
        foreach (var componentData in allMonobehaviourList)
        {
            if (!componentData.GetType().ToString().Contains("UnityEngine"))
            {
                _fieldcount = 0;
                foreach (FieldInfo mi in componentData.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
                {
                    if (mi.MemberType.ToString() == "Field")
                    {
                        _fieldcount++;
                    }
                }
                _labelArea[_classcount] = new string[_fieldcount*3 + 1];
                _classcount++;
            }
        }
        _classcount = 0;
        //アタッチされている全てのスクリプトを取得
        foreach (var componentData in allMonobehaviourList)
        {
            if (!componentData.GetType().ToString().Contains("UnityEngine"))
            {
                _fieldcount = 0;
                _labelArea[_classcount][_fieldcount] =componentData.GetType().ToString();
                _fieldcount++;
                //変数をすべて取得
                foreach (FieldInfo mi in componentData.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
                {
                    int _count = 0;
                    _isoepn[_classcount] = true;
                    _labelArea[_classcount][_fieldcount] = mi.Name;
                    Type t = mi.GetType();
                    string str = mi.FieldType.ToString();
                    _labelArea[_classcount][_fieldcount + 1] = str;
                    //型ごとに配列に格納
                    if (mi.FieldType.ToString().Contains("GameObject"))
                    {
                        if (mi.GetValue(componentData) != null && mi.GetValue(componentData) != default)
                        {
                            if (mi.GetValue(componentData).GetType().IsArray)
                            {
                                int _copy = _count;
                                foreach (GameObject obj in (Array)mi.GetValue(componentData))
                                {
                                    _getgameobjects.Add(obj);
                                    _count++;
                                }
                                if (_copy != _count)
                                {
                                    _arrayopencount++;
                                }
                            }
                            else
                            {
                                _getgameobjects.Add(null);
                                _count++;
                            }
                        }
                        else
                        {
                            _getgameobjects.Add(default);
                        }
                    }
                    else if (mi.FieldType.ToString().Contains("Int"))
                    {
                        if (mi.GetValue(componentData) != null && mi.GetValue(componentData) != default)
                        {
                            if (mi.GetValue(componentData).GetType().IsArray)
                            {
                                int _copy = _count;
                                foreach (int obj in (Array)mi.GetValue(componentData))
                                {
                                    _intobjects.Add(obj);
                                    _count++;
                                }
                                if (_copy != _count)
                                {
                                    _arrayopencount++;
                                }

                            }
                            else
                            {
                                _intobjects.Add(0);
                                _count++;
                            }
                        }
                        else
                        {
                            _intobjects.Add(default);
                        }
                    }
                    else if (mi.FieldType.ToString().Contains("Single"))
                    {
                        if (mi.GetValue(componentData) != null && mi.GetValue(componentData) != default)
                        {
                            if (mi.GetValue(componentData).GetType().IsArray)
                            {
                                int _copy = _count;
                                foreach (float obj in (Array)mi.GetValue(componentData))
                                {
                                    _floatobjects.Add(obj);
                                    _count++;
                                }
                                if (_copy != _count)
                                {
                                    _arrayopencount++;
                                }

                            }
                            else
                            {
                                _floatobjects.Add(0);
                                _count++;
                            }
                        }
                        else
                        {
                            _floatobjects.Add(default);
                        }
                    }
                    else if (mi.FieldType.ToString().Contains("Double"))
                    {
                        if (mi.GetValue(componentData) != null && mi.GetValue(componentData) != default)
                        {
                            if (mi.GetValue(componentData).GetType().IsArray)
                            {
                                int _copy = _count;
                                foreach (double obj in (Array)mi.GetValue(componentData))
                                {
                                    _doubleobjects.Add(obj);
                                    _count++;
                                }
                                if (_copy != _count)
                                {
                                    _arrayopencount++;
                                }

                            }
                            else
                            {
                                _doubleobjects.Add(0);
                                _count++;
                            }
                        }
                        else
                        {
                            _doubleobjects.Add(default);
                        }
                    }
                    else if (mi.FieldType.ToString().Contains("String"))
                    {
                        if (mi.GetValue(componentData) != null && mi.GetValue(componentData) != default)
                        {
                            if (mi.GetValue(componentData).GetType().IsArray)
                            {
                                int _copy = _count;
                                foreach (string obj in (Array)mi.GetValue(componentData))
                                {
                                    _stringobjects.Add(obj);
                                    _count++;
                                }
                                if (_copy != _count)
                                {
                                    _arrayopencount++;
                                }


                            }
                            else
                            {
                                _stringobjects.Add(null);
                                _count++;
                            }
                        }
                        else
                        {
                            _stringobjects.Add(default);
                        }
                    }
                    else if (mi.FieldType.ToString().Contains("Bool"))
                    {
                        if (mi.GetValue(componentData) != null && mi.GetValue(componentData) != default)
                        {
                            if (mi.GetValue(componentData).GetType().IsArray)
                            {
                                int _copy = _count;
                                foreach (bool obj in (Array)mi.GetValue(componentData))
                                {
                                    _boolobjects.Add(obj);
                                    _count++;
                                }
                                if (_copy != _count)
                                {
                                    _arrayopencount++;
                                }

                            }
                            else
                            {
                                _boolobjects.Add(false);
                                _count++;
                            }
                        }
                        else
                        {
                            _boolobjects.Add(default);
                        }
                    }
                    _labelArea[_classcount][_fieldcount + 2] = _count.ToString();
                    _fieldcount += 3;
                }
                _classcount++;
                _arrayopen = new bool[_arrayopencount];
                for (int i=0; i<_arrayopen.Length;i++)
                {
                    _arrayopen[i] = true;
                }
            }
        }
    }



    //オブジェクトのコンポーネントを探索して格納する
    public static IEnumerable<T> GetComponentsInList<T>(IEnumerable<GameObject> gameObjects) where T : Component
    {
        var componentList = new List<T>();

        foreach (var obj in gameObjects)
        {
            var components = obj.GetComponents<T>();
            if (components != null)
            {
                foreach (var component in components)
                {
                    componentList.Add(component);
                }
            }
        }
        return componentList;
    }
}
