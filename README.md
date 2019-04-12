# C# Implemention of Max/Min Heap with generics and int
## Zelong Yu


1) GetMin(): It returns the root element of Min Heap. Time Complexity of this operation is O(1).

2) ExtractMin(): Removes the minimum element from MinHeap. Time Complexity of this Operation is O(Logn) as this operation needs to maintain the heap property (by calling heapify()) after removing root.

3) DecreaseKey(): Decreases value of key. The time complexity of this operation is O(Logn). If the decreases key value of a node is greater than the parent of the node, then we don’t need to do anything. Otherwise, we need to traverse up to fix the violated heap property.

4) Insert(): Inserting a new key takes O(Logn) time. We add a new key at the end of the tree. IF new key is greater than its parent, then we don’t need to do anything. Otherwise, we need to traverse up to fix the violated heap property.

*Noted: Delete only works at non-generic MinHeapInt() class, since negative infinity of generics<T> is undefined.*
  
5) Delete(): Deleting a key takes O(Logn) time. We replace the key to be deleted with minum infinite by calling decreaseKey(). After decreaseKey(), the minus infinite value must reach root, so we call extractMin() to remove the key.
  
6) Count(): returns size of heap.

Operations on Max Heap: replace min with max from above, and replace DecreaseKey() with IncreaseKey().
