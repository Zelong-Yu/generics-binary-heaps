using System;
using System.Collections.Generic;
using System.Linq;


public class MinHeap<T> where T:IComparable<T> 
{
       
    private readonly List<T> _elements;
    //constructor
    public MinHeap()
    {
        _elements = new List<T>();
    }

    //Returns the parent node index of node at index i 
    int parent(int i) => (i - 1) / 2;

    //get index of left child of node at index i
    int left(int i) => 2 * i + 1;

    //get index of right child of node at index i
    int right(int i) => 2 * i + 2;

    //utility func to swap two element
    void swap(int aIndex, int bIndex)
    {
        var temp = _elements[aIndex];
        _elements[aIndex] = _elements[bIndex];
        _elements[bIndex] = temp;
    }


    /// getMin()       O(1) returns root
    public T GetMin()
    {
        if (_elements.Count() == 0 || _elements is null) 
            return default(T);
        return _elements[0];
    }
    /// extractMin()   O(log n) remove root, put the last element at root, call heapify()
    public T ExtractMin()
    {
        if (_elements.Count() == 0 || _elements is null)
            return default(T);
        //Store the minimum value as root, and remove it from heap, return root
        T root = _elements[0];
        //place the last element of heap at root, and heapify from root
        _elements[0] = _elements[_elements.Count() - 1];
        _elements.RemoveAt(_elements.Count() - 1);
        heapify(0);
        return root;
    }


    ///insert() O(log n) add new element at the end of tree. if smaller than parent, traverse up
    public void Insert(T k)
    {
        //first insert the new element at the end
        _elements.Add(k);
        //initialize i to be last index
        int i = _elements.Count() - 1;
        //traverse up to fix heap property
        while (i!=0 && _elements[parent(i)].CompareTo(_elements[i])>0)
        {
            swap(i, parent(i));
            i = parent(i);
        }
    }

    /// decreaseKey() O(log n) Decreases value of key at index 'i' to new_val.
    /// if after decrease value of node smaller than parent, traverse up
    public void DecreaseKey(int i, T newval)
    {
        _elements[i] = newval;
        //traverse up to fix heap property
        while (i != 0 && _elements[parent(i)].CompareTo(_elements[i]) > 0)
        {
            swap(i, parent(i));
            i = parent(i);
        }
    }

    ///delete() O(log n) replace key with minum infinite by decreaseKey(), traverse up, extractMin
    ///warning: will not work since T negative inf is not defined. 
    /*public void DeleteKey(int i)
    {
        DecreaseKey(i, default(T));
        extractMin();
    }*/

    // A recursive method to heapify a subtree with the root at given index 
    // This method assumes that the subtrees are already heapified 
    void heapify(int i)
    {
        //left child index
        int l = left(i);
        //right child index
        int r = right(i);
        //among node[i] and its two child find the smallest
        int smallest = i;
        if (l < _elements.Count() && _elements[l].CompareTo(_elements[i]) < 0)
            smallest = l;
        if (r < _elements.Count() && _elements[r].CompareTo(_elements[smallest]) < 0)
            smallest = r;
        if (smallest != i) //swap note[i] with smallest if note[i] is not the smallest
        {
            swap(i, smallest);
            heapify(smallest);
        }
    }

    //return heap size
    public int Count()
    {
        return _elements.Count();
    }
}

