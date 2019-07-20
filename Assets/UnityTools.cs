using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;

namespace UnityTools
{
    #region Static Classes

    /// <summary>
    /// Tools based around making scene tracking and management easier
    /// </summary>
    public static class SceneTools
    {
        /// <summary>
        /// Will return a List of Scene objects for each active scene registered by the Unity SceneManager.
        /// </summary>
        /// <returns>List of Scene objects</returns>
        public static List<Scene> getActiveScenes()
        {
            //Spin up new list
            List<Scene> activeScenes = new List<Scene>();

            //Add each scene found in the scene indexes
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                activeScenes.Add(SceneManager.GetSceneAt(i));
            }

            //Return all active scenes housed in the list
            return activeScenes;
        }

        /// <summary>
        /// Will return a List of scene names (string) for each active scene registered by the Unity SceneManager
        /// </summary>
        /// <returns>List of Scene names</returns>
        public static List<string> getActiveSceneNames()
        {
            //Spin up list to add to
            List<string> sceneNames = new List<string>();

            //Add the names of all active scenes to the list
            foreach (Scene s in getActiveScenes())
            {
                sceneNames.Add(s.name);
            }

            //return the list of names
            return sceneNames;
        }
    }

    /// <summary>
    /// Tools based around making Vector based work easier
    /// </summary>
    public static class VectorTools
    {
        /// <summary>
        /// Returns the float distance between two provided GameObjects. The actual order or objects 
        /// does not matter when calling this method. 
        /// </summary>
        /// <param name="start">Starting GameObject</param>
        /// <param name="end">Ending GameObject</param>
        /// <returns>Distance between two points in 3-space</returns>
        public static float getObjectDistance(GameObject start, GameObject end)
        {
            return Vector3.Distance(start.transform.position, end.transform.position);
        }

        /// <summary>
        /// Returns the float distance between two provided GameObjects. The actual order or objects 
        /// does not matter when calling this method. 
        /// </summary>
        /// <param name="gObject">GameObject to check distance from</param>
        /// <param name="coordinate">Vector3 to check distance to</param>
        /// <returns>Distance between two points in 3-space</returns>
        public static float getObjectDistance(GameObject gObject, Vector3 coordinate)
        {
            return Vector3.Distance(gObject.transform.position, coordinate);
        }

        /// <summary>
        /// Returns the float distance between two provided GameObjects. The actual order or objects 
        /// does not matter when calling this method. 
        /// </summary>
        /// <param name="gObject">GameObject to check distance to</param>
        /// <param name="coordinate">Vector3 to check distance from</param>
        /// <returns>Distance between two points in 3-space</returns>
        public static float getObjectDistance(Vector3 coordinate, GameObject gObject)
        {
            return Vector3.Distance(coordinate, gObject.transform.position);
        }

        /// <summary>
        /// Returns the float distance between two provided Coordinates.
        /// </summary>
        /// <param name="start">Start position</param>
        /// <param name="end">End Position</param>
        /// <returns>Float - Distance between two points</returns>
        public static float getObjectDistance(Vector3 start, Vector3 end)
        {
            return Vector3.Distance(start, end);
        }

        /// <summary>
        /// Returns if two vectors have approximately the same value
        /// </summary>
        /// <param name="a">First Vector3</param>
        /// <param name="b">Second Vector3</param>
        /// <returns>Boolean - If the provided Vectors have approximately the same values</returns>
        public static bool compareVector3(Vector3 a, Vector3 b)
        {
            return Mathf.Approximately(a.x, b.x) && Mathf.Approximately(a.y, b.y) && Mathf.Approximately(a.z, b.z);
        }
    }

    /// <summary>
    /// Tools based around making work with an Objects Transform component easier
    /// </summary>
    public static class TransformTools
    {
        /// <summary>
        /// Adds all children of the provided transform to a list and returns it.
        /// </summary>
        /// <param name="parent">Parent transform object</param>
        /// <returns>List of Transform</returns>
        public static List<Transform> getChildrenOfTransform(Transform parent)
        {
            //Instanciate List 
            List<Transform> children = new List<Transform>();

            //Iterate through all children for i < childCount and add to list
            for (int i = 0; i < parent.childCount; i++)
            {
                children.Add(parent.GetChild(i));
            }

            //Return found children
            return children;
        }

        /// <summary>
        /// Adds all child gameObjects of the provided GameObject to the list and return it
        /// </summary>
        /// <param name="parent">Parent GameObject</param>
        /// <returns>List of all GameObjects that are children to the parent</returns>
        public static List<GameObject> getChildrenOfGameObject(GameObject parent)
        {
            //Instanciate list
            List<GameObject> children = new List<GameObject>();

            //Get a list of transforms for the children to the gameObject
            List<Transform> childTransforms = getChildrenOfTransform(parent.transform);

            //Convert transforms to GameObjects
            foreach (Transform transform in childTransforms)
            {
                children.Add(transform.gameObject);
            }

            //Return gameObjects
            return children;
        }
    }

    /// <summary>
    /// Tools based around the manipulation of Arrays and Lists
    /// </summary>
    public static class CustomInspectorTools
    {
        /*
        /// <summary>
        /// Takes an array (SerializedProperty) with a header and content name for displaying an array to the associated inspector
        /// </summary>
        /// <param name="array">SerializedProperty array to draw and modify content of</param>
        /// <param name="headerName">Header content to title array content with</param>
        /// <param name="elementName">Content to display alongside array elements as titles for content</param>
        public static void drawSerializedArrayToInspector(SerializedProperty array, string headerName, string elementName)
        {
            //Display buttons for changing array size
            GUILayout.Label(headerName, EditorStyles.boldLabel);
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Add")) { array.arraySize = array.arraySize > 0 ? array.arraySize + 1 : 1; }
            if (GUILayout.Button("Remove")) { array.arraySize = array.arraySize > 0 ? array.arraySize - 1 : 1; }
            GUILayout.EndHorizontal();
            //Display contents of array for modification
            if (array.arraySize < 1)
                GUILayout.Label("No content set");
            else
                for (int i = 0; i < array.arraySize; i++)
                {
                    EditorGUILayout.PropertyField(array.GetArrayElementAtIndex(i), new GUIContent(elementName + (i + 1)));
                }
        }
        */
    }

    /// <summary>
    /// Tools based around the support of Unity Custom Inspector Usage
    /// </summary>
    public static class ArrayTools
    {
        /// <summary>
        /// Returns a provided 2D array in the form of a single List
        /// </summary>
        /// <typeparam name="T">Data Type of Array</typeparam>
        /// <param name="input">2D Array to be converted</param>
        /// <returns>List<T> - List containing all elements of the provided array</returns>
        public static List<T> get2dArrayAsList<T>(T[,] input)
        {
            //Edge case for a null reference being given
            if (input == null) return null;

            //Initialize list to be returned
            List<T> list = new List<T>();

            //Iterate through two dimensions of array
            for (int x = 0; x < input.GetLength(0); x++)
            {
                for (int y = 0; y < input.GetLength(1); y++)
                {
                    //Add element to list
                    list.Add(input[x, y]);
                }
            }

            //Return singular list at the end
            return list;
        }

        /// <summary>
        /// Takes a provided array of a generic type and increases it length by one while keeping the original content
        /// </summary>
        /// <typeparam name="T">Array Type</typeparam>
        /// <param name="array">Array to increase size of</param>
        /// <returns>Contents of provided array with one extra element at the end</returns>
        public static T[] increaseArraySize<T>(T[] array)
        {
            //Edge case for null or empty array
            if (array == null || array.Length < 1) return new T[1];

            //Build a new larger array
            T[] temp = new T[array.Length + 1];

            //Copy contents over to new array
            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }

            return temp;
        }

        /// <summary>
        /// Takes a provided array of a generic type and decreases the size by one, removing the last index of the original array
        /// </summary>
        /// <typeparam name="T">Array type</typeparam>
        /// <param name="array">Array to shrink</param>
        /// <returns>Contents of the provided array with the last element removed</returns>
        public static T[] decreaseArraySize<T>(T[] array)
        {
            //Edge case for null or empty array
            if (array == null || array.Length < 1) return new T[0];

            //Build a smaller array
            T[] temp = new T[array.Length - 1];

            //copy contents of old array exlcuding the last index
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = array[i];
            }

            return temp;
        }

        /// <summary>
        /// Determines if a given index for a 2D array is within the bounds of the array's size
        /// </summary>
        /// <typeparam name="T">Array type</typeparam>
        /// <param name="x">First index of array</param>
        /// <param name="y">Second index of array</param>
        /// <param name="array">Array to check against</param>
        /// <returns>Boolean - If the provided indicies are within the bounds of the array</returns>
        public static bool coordinateExistsWithinArrayBounds<T>(int x, int y, T[,] array)
        {
            if (x < array.GetLength(0) && y < array.GetLength(1) && x > -1 && y > -1) return true;
            else return false;
        }
        /// <summary>
        /// Determines if a given index for a 2D array is within the bounds of the array's size
        /// </summary>
        /// <typeparam name="T">Array type</typeparam>
        /// <param name="index">Index in array</param>
        /// <param name="array">Array to check against</param>
        /// <returns>Boolean - If the provided indicies are within the bounds of the array</returns>
        public static bool coordinateExistsWithinArrayBounds<T>(Vector2Int index, T[,] array)
        { return coordinateExistsWithinArrayBounds(index.x, index.y, array); }
        /// <summary>
        /// Determines if a given index for a 2D array is within the bounds of the array's size
        /// </summary>
        /// <typeparam name="T">Array type</typeparam>
        /// <param name="index">Index in array</param>
        /// <param name="array">Array to check against</param>
        /// <returns>Boolean - If the provided indicies are within the bounds of the array</returns>
        public static bool coordinateExistsWithinArrayBounds<T>(Vector2 index, T[,] array)
        { return coordinateExistsWithinArrayBounds((int)index.x, (int)index.y, array); }
    }

    /// <summary>
    /// Tools based around Grid reading and manipulation.
    /// </summary>
    public static class GridTools
    {
        /// <summary>
        /// Returns the Integer distance between two grid positions
        /// </summary>
        /// <param name="a">Position A</param>
        /// <param name="b">Position B</param>
        /// <returns>Integer - Distance between two points</returns>
        public static int getGridDistanceBetweenPoints(Vector2Int a, Vector2Int b)
        {
            return Mathf.Abs(Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y));
        }

        /// <summary>
        /// Returns Adjacent 2D coordinates to a provided coordinate (Vector2Int)
        /// </summary>
        /// <param name="source">Source Coordinate to return adjectent coordinates to</param>
        /// <returns>Array of Vector2Int - Adjacent Coordinates to the provided source</returns>
        public static Vector2Int[] getAdjacentCoordinates(Vector2Int source)
        {
            Vector2Int[] coordinates = new Vector2Int[4];
            coordinates[0] = new Vector2Int(source.x + 1, source.y);
            coordinates[1] = new Vector2Int(source.x - 1, source.y);
            coordinates[2] = new Vector2Int(source.x, source.y + 1);
            coordinates[3] = new Vector2Int(source.x, source.y - 1);

            return coordinates;
        }
    }

    #endregion

    #region Enumerable Decorator Classes

    /// <summary>
    /// Decorator class to provide iterable functionality to the Unity Vector3Int class
    /// </summary>
    [Serializable]
    public class IVector3Int : MonoBehaviour, IEnumerable
    {
        //Private container using old Vector3Int
        private Vector3Int data;

        //Public value accessors
        public int x { get { return data.x; } set { data.x = value; } }
        public int y { get { return data.y; } set { data.y = value; } }
        public int z { get { return data.z; } set { data.z = value; } }

        /// <summary>
        /// Iterable Vector3Int class. Starting value (0, 0, 0).
        /// </summary>
        public IVector3Int() { data = new Vector3Int(0, 0, 0); }
        /// <summary>
        /// Iterable Vector3Int class. Assigns value to (x, y, 0).
        /// </summary>
        /// <param name="x">First value, x position</param>
        /// <param name="y">Second value, y position</param>
        public IVector3Int(int x, int y) { data = new Vector3Int(x, y, 0); }
        /// <summary>
        /// Iterable Vector3Int class. Starting value (x, y, z).
        /// </summary>
        /// <param name="x">First Value, x position</param>
        /// <param name="y">Second value, y position</param>
        /// <param name="z">Third Value, z position</param>
        public IVector3Int(int x, int y, int z) { data = new Vector3Int(x, y, z); }
        /// <summary>
        /// Iterable Vector3Int class. Converts the source Vector3Int to this object type
        /// </summary>
        /// <param name="source">Source Vector3Int to convert</param>
        public IVector3Int(Vector3Int source) { data = new Vector3Int(source.x, source.y, source.z); }

        /// <summary>
        /// Enumerator for accessing vector values
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            yield return data.x;
            yield return data.y;
            yield return data.z;
        }
        /// <summary>
        /// Accessor for IEnumerator
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

        /// <summary>
        /// Returns the Vector value at the provided index. Expected index (0 - 2), any value outside this returns the Z value.
        /// </summary>
        /// <param name="index">Index of value to access in vector (0, 1, 2)</param>
        /// <returns></returns>
        public int getValue(int index) { return index == 0 ? data.x : index == 1 ? data.y : data.z; }

        /// <summary>
        /// Returns the contents of this class as a Vector3Int
        /// </summary>
        /// <returns></returns>
        public Vector3Int asVector3Int() { return new Vector3Int(data.x, data.y, data.z); }
        /// <summary>
        /// Returns the contents of this class as a Vector3
        /// </summary>
        /// <returns></returns>
        public Vector3 asVector3() { return new Vector3(data.x, data.y, data.z); }
    }

    /// <summary>
    /// Decorator class to provide iterable functionality to the Unity Vector3 class
    /// </summary>
    [Serializable]
    public class IVector3 : MonoBehaviour, IEnumerable
    {
        //Private container using old Vector3 
        private Vector3 data;

        //Public value accessors
        public float x { get { return data.x; } set { data.x = value; } }
        public float y { get { return data.y; } set { data.y = value; } }
        public float z { get { return data.z; } set { data.z = value; } }

        /// <summary>
        /// Iterable Vector3 class. Starting value (0, 0, 0)
        /// </summary>
        public IVector3() { data = new Vector3(0, 0, 0); }
        /// <summary>
        /// Iterable Vector3 class. Starting value (x, y, 0)
        /// </summary>
        /// <param name="x">Value 1, x position</param>
        /// <param name="y">Value 2, y position</param>
        public IVector3(float x, float y) { data = new Vector3(x, y, 0); }
        /// <summary>
        /// Iterable Vector3 class. Starting value (x, y, z)
        /// </summary>
        /// <param name="x">Value 1, x position</param>
        /// <param name="y">Value 2, y position</param>
        /// <param name="z">Value 3, z position</param>
        public IVector3(float x, float y, float z) { data = new Vector3(x, y, z); }
        /// <summary>
        /// Iterable Vector3 class. Converts a standard Vector3 to this object type
        /// </summary>
        /// <param name="source">Source Vector3 to convert</param>
        public IVector3(Vector3 source) { data = new Vector3(source.x, source.x, source.z); }

        /// <summary>
        /// Enumerator for accessing vector values
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            yield return data.x;
            yield return data.y;
            yield return data.z;
        }
        /// <summary>
        /// Accessor for IEnumerator
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

        /// <summary>
        /// Returns the Vector value at the provided index. Expected index (0 - 2), any value outside this returns the Z value.
        /// </summary>
        /// <param name="index">Index of value to access in vector (0, 1, 2)</param>
        /// <returns></returns>
        public float getValue(int index) { return index == 0 ? data.x : index == 1 ? data.y : data.z; }


        /// <summary>
        /// Returns the contents of this class as a Vector3Int
        /// </summary>
        /// <returns></returns>
        public Vector3Int asVector3Int() { return new Vector3Int((int)data.x, (int)data.y, (int)data.z); }
        /// <summary>
        /// Returns the contents of this class as a Vector3
        /// </summary>
        /// <returns></returns>
        public Vector3 asVector3() { return new Vector3(data.x, data.y, data.z); }
    }

    #endregion
}
