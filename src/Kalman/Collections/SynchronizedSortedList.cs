using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;

namespace Kalman.Collections
{
	/// <summary>
	/// Represents a synchronized collection of key/value pairs that are sorted by key based on the associated IComparer implementation.
	/// </summary>
	/// <typeparam name="TKey">The type of keys in the collection.</typeparam>
	/// <typeparam name="TValue">The type of values in the collection.</typeparam>
	public class SynchronizedSortedList<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IDictionary, ICollection, IEnumerable
	{
		private ReaderWriterLock rwLock;
		private SortedList<TKey, TValue> sortedList;

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the SortedList class that is empty, has the default initial capacity, and uses the default IComparer.
		/// </summary>
		public SynchronizedSortedList()
		{
			rwLock = new ReaderWriterLock();
			sortedList = new SortedList<TKey, TValue>();
		}

		/// <summary>
		/// Initializes a new instance of the SortedList class that is empty, has the default initial capacity, and uses the specified IComparer.
		/// </summary>
		/// <param name="comparer">The IComparer implementation to use when comparing keys, or aa null reference (Nothing in Visual Basic) to use the default Comparer for the type of the key.</param>
		public SynchronizedSortedList(IComparer<TKey> comparer)
		{
			rwLock = new ReaderWriterLock();
			sortedList = new SortedList<TKey, TValue>(comparer);
		}

		/// <summary>
		/// Initializes a new instance of the SortedList class that contains elements copied from the specified IDictionary, has sufficient capacity to accommodate the number of elements copied, and uses the default IComparer.
		/// </summary>
		/// <param name="dictionary">The IDictionary whose elements are copied to the new SortedList.</param>
		public SynchronizedSortedList(IDictionary<TKey, TValue> dictionary)
		{
			rwLock = new ReaderWriterLock();
			sortedList = new SortedList<TKey, TValue>(dictionary);
		}

		/// <summary>
		/// Initializes a new instance of the SortedList class that is empty, has the specified initial capacity, and uses the default IComparer.
		/// </summary>
		/// <param name="capacity">The initial number of elements that the SortedList can contain.</param>
		public SynchronizedSortedList(int capacity)
		{
			rwLock = new ReaderWriterLock();
			sortedList = new SortedList<TKey, TValue>(capacity);
		}

		/// <summary>
		/// Initializes a new instance of the SortedList class that contains elements copied from the specified IDictionary, has sufficient capacity to accommodate the number of elements copied, and uses the specified IComparer.
		/// </summary>
		/// <param name="dictionary">The IDictionary whose elements are copied to the new SortedList.</param>
		/// <param name="comparer">The IComparer implementation to use when comparing keys, or aa null reference (Nothing in Visual Basic) to use the default Comparer for the type of the key.</param>
		public SynchronizedSortedList(IDictionary<TKey, TValue> dictionary, IComparer<TKey> comparer)
		{
			rwLock = new ReaderWriterLock();
			sortedList = new SortedList<TKey, TValue>(dictionary, comparer);
		}

		/// <summary>
		/// Initializes a new instance of the SortedList class that is empty, has the specified initial capacity, and uses the specified IComparer.
		/// </summary>
		/// <param name="capacity">The initial number of elements that the SortedList can contain.</param>
		/// <param name="comparer">The IComparer implementation to use when comparing keys, or aa null reference (Nothing in Visual Basic) to use the default Comparer for the type of the key.</param>
		public SynchronizedSortedList(int capacity, IComparer<TKey> comparer)
		{
			rwLock = new ReaderWriterLock();
			sortedList = new SortedList<TKey, TValue>(capacity, comparer);
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// Gets or sets the number of elements that the SortedList can contain.
		/// </summary>
		public int Capacity
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return sortedList.Capacity;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}

		/// <summary>
		/// Gets the IComparer for the sorted list.
		/// </summary>
		public IComparer<TKey> Comparer
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return sortedList.Comparer;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}

		/// <summary>
		/// Gets the number of key/value pairs contained in the SortedList.
		/// </summary>
		public int Count
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return sortedList.Count;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}

		/// <summary>
		/// Gets or sets the value associated with the specified key.
		/// </summary>
		/// <param name="key">The key whose value to get or set.</param>
		/// <returns>The value associated with the specified key. If the specified key is not found, a get operation throws a KeyNotFoundException and a set operation creates a new element using the specified key.</returns>
		public TValue this[TKey key]
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return sortedList[key];
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}

			set
			{
				try
				{
					rwLock.AcquireWriterLock(Timeout.Infinite);
					sortedList[key] = value;
				}
				finally
				{
					rwLock.ReleaseWriterLock();
				}
			}
		}

		/// <summary>
		/// Gets a collection containing the keys in the SortedList.
		/// </summary>
		public ICollection<TKey> Keys
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					SortedList<TKey, TValue> newSortedList = new SortedList<TKey, TValue>(sortedList);
					return newSortedList.Keys;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}

		/// <summary>
		/// Gets a collection containing the values in the SortedList.
		/// </summary>
		public ICollection<TValue> Values
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					SortedList<TKey, TValue> newSortedList = new SortedList<TKey, TValue>(sortedList);
					return newSortedList.Values;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Adds an element with the specified key and value into the SortedList.
		/// </summary>
		/// <param name="key">The key of the element to add.</param>
		/// <param name="value">The value of the element to add. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
		public void Add(TKey key, TValue value)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				sortedList.Add(key, value);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Removes all elements from the SortedList.
		/// </summary>
		public void Clear()
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				sortedList.Clear();
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Determines whether the SortedList contains a specific key.
		/// </summary>
		/// <param name="key">The key to locate in the SortedList.</param>
		/// <returns><b>true</b> if the SortedList contains an element with the specified key; otherwise, <b>false</b>.</returns>
		public bool ContainsKey(TKey key)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return sortedList.ContainsKey(key);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Determines whether the SortedList contains a specific value.
		/// </summary>
		/// <param name="value">The value to locate in the SortedList.</param>
		/// <returns><b>true</b> if the SortedList contains an element with the specified value; otherwise, <b>false</b>.</returns>
		public bool ContainsValue(TValue value)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return sortedList.ContainsValue(value);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Returns an enumerator that iterates through the SortedList.
		/// </summary>
		/// <returns>An IEnumerator of type KeyValuePair for the SortedList.</returns>
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return ((IEnumerable<KeyValuePair<TKey, TValue>>) sortedList).GetEnumerator();
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Searches for the specified key and returns the zero-based index within the entire SortedList.
		/// </summary>
		/// <param name="key">The key to locate in the SortedList.</param>
		/// <returns>The zero-based index of key within the entire SortedList, if found; otherwise, -1.</returns>
		public int IndexOfKey(TKey key)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return sortedList.IndexOfKey(key);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Searches for the specified value and returns the zero-based index within the entire SortedList.
		/// </summary>
		/// <param name="value">The value to locate in the SortedList.</param>
		/// <returns>The zero-based index of value within the entire SortedList, if found; otherwise, -1.</returns>
		public int IndexOfValue(TValue value)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return sortedList.IndexOfValue(value);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Removes the element with the specified key from the SortedList.
		/// </summary>
		/// <param name="key">The key of the element to remove.</param>
		/// <returns><b>true</b> if the element is successfully removed; otherwise, <b>false</b>. This method also returns <b>false</b> if key was not found in the original SortedList.</returns>
		public bool Remove(TKey key)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				return sortedList.Remove(key);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Removes the element at the specified index of the SortedList.
		/// </summary>
		/// <param name="index">The zero-based index of the element to remove.</param>
		public void RemoveAt(int index)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				sortedList.RemoveAt(index);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Sets the capacity to the actual number of elements in the SortedList, if that number is less than 90 percent of current capacity.
		/// </summary>
		public void TrimExcess()
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				sortedList.TrimExcess();
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Gets the value associated with the specified key.
		/// </summary>
		/// <param name="key">The key whose value to get.</param>
		/// <param name="value">When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized.</param>
		/// <returns></returns>
		public bool TryGetValue(TKey key, out TValue value)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return sortedList.TryGetValue(key, out value);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}
		#endregion

		#region Explicit Interface Implementations
		/// <summary>
		/// Adds a key/value pair to the ICollection.
		/// </summary>
		/// <param name="item">The KeyValuePair to add to the ICollection.</param>
		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				((ICollection<KeyValuePair<TKey, TValue>>) sortedList).Add(item);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Determines whether the ICollection contains a specific element.
		/// </summary>
		/// <param name="item">The KeyValuePair to locate in the ICollection.</param>
		/// <returns><b>true</b> if keyValuePair is found in the ICollection; otherwise, <b>false</b>.</returns>
		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return ((ICollection<KeyValuePair<TKey, TValue>>) sortedList).Contains(item);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Copies the elements of the ICollection to an Array, starting at a particular Array index.
		/// </summary>
		/// <param name="array">The one-dimensional Array that is the destination of the elements copied from ICollection. The Array must have zero-based indexing.</param>
		/// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				((ICollection<KeyValuePair<TKey, TValue>>) sortedList).CopyTo(array, arrayIndex);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Removes the first occurrence of a specific key/value pair from the ICollection.
		/// </summary>
		/// <param name="item">The KeyValuePair to remove from the ICollection.</param>
		/// <returns><b>true</b> if keyValuePair was successfully removed from the ICollection; otherwise, <b>false</b>. This method also returns <b>false</b> if keyValuePair was not found in the original ICollection.</returns>
		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				return ((ICollection<KeyValuePair<TKey, TValue>>) sortedList).Remove(item);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Copies the elements of the ICollection to an Array, starting at a particular Array index.
		/// </summary>
		/// <param name="array">The one-dimensional Array that is the destination of the elements copied from ICollection. The Array must have zero-based indexing.</param>
		/// <param name="index">The zero-based index in array at which copying begins.</param>
		void ICollection.CopyTo(Array array, int index)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				((ICollection) sortedList).CopyTo(array, index);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Adds an element with the provided key and value to the IDictionary.
		/// </summary>
		/// <param name="key">The Object to use as the key of the element to add.</param>
		/// <param name="value">The Object to use as the value of the element to add.</param>
		void IDictionary.Add(object key, object value)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				((IDictionary) sortedList).Add(key, value);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Determines whether the IDictionary contains an element with the specified key.
		/// </summary>
		/// <param name="key">The key to locate in the IDictionary.</param>
		/// <returns><b>true</b> if the IDictionary contains an element with the key; otherwise, <b>false</b>.</returns>
		bool IDictionary.Contains(object key)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return ((IDictionary) sortedList).Contains(key);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Returns an IDictionaryEnumerator for the IDictionary.
		/// </summary>
		/// <returns>An IDictionaryEnumerator for the IDictionary.</returns>
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				SortedList<TKey, TValue> newSortedList = new SortedList<TKey, TValue>(sortedList);
				return ((IDictionary) newSortedList).GetEnumerator();
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Removes the element with the specified key from the IDictionary.
		/// </summary>
		/// <param name="key">The key of the element to remove.</param>
		void IDictionary.Remove(object key)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				((IDictionary) sortedList).Remove(key);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>An IEnumerator that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				SortedList<TKey, TValue> newSortedList = new SortedList<TKey, TValue>(sortedList);
				return ((IEnumerable) newSortedList).GetEnumerator();
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Gets a value indicating whether the ICollection is read-only.
		/// </summary>
		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return ((ICollection<KeyValuePair<TKey, TValue>>) sortedList).IsReadOnly;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}

		/// <summary>
		/// Gets an ICollection containing the keys of the IDictionary.
		/// </summary>
		ICollection<TKey> IDictionary<TKey, TValue>.Keys
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					SortedList<TKey, TValue> newSortedList = new SortedList<TKey, TValue>(sortedList);
					return ((IDictionary<TKey, TValue>) newSortedList).Keys;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}

		/// <summary>
		/// Gets an ICollection containing the values of the IDictionary.
		/// </summary>
		ICollection<TValue> IDictionary<TKey, TValue>.Values
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					SortedList<TKey, TValue> newSortedList = new SortedList<TKey, TValue>(sortedList);
					return ((IDictionary<TValue, TValue>) newSortedList).Values;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}

		/// <summary>
		/// Gets a value indicating whether access to the ICollection is synchronized (thread safe).
		/// </summary>
		bool ICollection.IsSynchronized
		{
			get { return true; }
		}

		/// <summary>
		/// Gets an object that can be used to synchronize access to the ICollection.
		/// </summary>
		object ICollection.SyncRoot
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return ((ICollection) sortedList).SyncRoot;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}

		/// <summary>
		/// Gets a value indicating whether the IDictionary has a fixed size.
		/// </summary>
		bool IDictionary.IsFixedSize
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return ((IDictionary) sortedList).IsFixedSize;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}

		/// <summary>
		/// Gets a value indicating whether the IDictionary is read-only.
		/// </summary>
		bool IDictionary.IsReadOnly
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return ((IDictionary) sortedList).IsReadOnly;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}

		/// <summary>
		/// Gets or sets the element with the specified key.
		/// </summary>
		/// <param name="key">The key of the element to get or set.</param>
		/// <returns>The element with the specified key, or a null reference (Nothing in Visual Basic) if key is not in the dictionary or key is of a type that is not assignable to the key type TKey of the SortedList.</returns>
		object IDictionary.this[object key]
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					SortedList<TKey, TValue> newSortedList = new SortedList<TKey, TValue>(sortedList);
					return ((IDictionary) newSortedList)[key];
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}

			set
			{
				try
				{
					rwLock.AcquireWriterLock(Timeout.Infinite);
					SortedList<TKey, TValue> newSortedList = new SortedList<TKey, TValue>(sortedList);
					((IDictionary) newSortedList)[key] = value;
				}
				finally
				{
					rwLock.ReleaseWriterLock();
				}
			}
		}

		/// <summary>
		/// Gets an ICollection containing the keys of the IDictionary.
		/// </summary>
		ICollection IDictionary.Keys
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					SortedList<TKey, TValue> newSortedList = new SortedList<TKey, TValue>(sortedList);
					return ((IDictionary) newSortedList).Keys;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}

		/// <summary>
		/// Gets an ICollection containing the values in the IDictionary.
		/// </summary>
		ICollection IDictionary.Values
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					SortedList<TKey, TValue> newSortedList = new SortedList<TKey, TValue>(sortedList);
					return ((IDictionary) newSortedList).Values;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}
		#endregion
	}
}
