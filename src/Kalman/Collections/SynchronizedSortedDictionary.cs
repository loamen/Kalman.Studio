using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;

namespace Kalman.Collections
{
	/// <summary>
	/// Represents a collection of key/value pairs that are sorted on the key.
	/// </summary>
	/// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
	/// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
	public class SynchronizedSortedDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IDictionary, ICollection, IEnumerable
	{
		private ReaderWriterLock rwLock;
		private SortedDictionary<TKey, TValue> sortedDictionary;

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the SortedDictionary class that is empty and uses the default IComparer implementation for the key type.
		/// </summary>
		public SynchronizedSortedDictionary()
		{
			rwLock = new ReaderWriterLock();
			sortedDictionary = new SortedDictionary<TKey, TValue>();
		}

		/// <summary>
		/// Initializes a new instance of the SortedDictionary class that is empty and uses the specified IComparer implementation to compare keys.
		/// </summary>
		/// <param name="comparer">The IComparer implementation to use when comparing keys, or a null reference (Nothing in Visual Basic) to use the default Comparer for the type of the key.</param>
		public SynchronizedSortedDictionary(IComparer<TKey> comparer)
		{
			rwLock = new ReaderWriterLock();
			sortedDictionary = new SortedDictionary<TKey, TValue>(comparer);
		}

		/// <summary>
		/// Initializes a new instance of the SortedDictionary class that contains elements copied from the specified IDictionary and uses the default IComparer implementation for the key type.
		/// </summary>
		/// <param name="dictionary">The IDictionary whose elements are copied to the new SortedDictionary.</param>
		public SynchronizedSortedDictionary(IDictionary<TKey, TValue> dictionary)
		{
			rwLock = new ReaderWriterLock();
			this.sortedDictionary = new SortedDictionary<TKey, TValue>(dictionary);
		}

		/// <summary>
		/// Initializes a new instance of the SortedDictionary class that contains elements copied from the specified IDictionary and uses the specified IComparer implementation to compare keys.
		/// </summary>
		/// <param name="dictionary">The IDictionary whose elements are copied to the new SortedDictionary.</param>
		/// <param name="comparer">The IComparer implementation to use when comparing keys, or a null reference (Nothing in Visual Basic) to use the default Comparer for the type of the key.</param>
		public SynchronizedSortedDictionary(IDictionary<TKey, TValue> dictionary, IComparer<TKey> comparer)
		{
			rwLock = new ReaderWriterLock();
			this.sortedDictionary = new SortedDictionary<TKey, TValue>(dictionary, comparer);
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// Gets the IComparer used to order the elements of the SortedDictionary.
		/// </summary>
		public IComparer<TKey> Comparer
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return sortedDictionary.Comparer;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}

		/// <summary>
		/// Gets the number of key/value pairs contained in the SortedDictionary.
		/// </summary>
		public int Count
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return sortedDictionary.Count;
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
		/// <param name="key">The key of the value to get or set.</param>
		/// <returns>The value associated with the specified key. If the specified key is not found, a get operation throws a KeyNotFoundException, and a set operation creates a new element with the specified key.</returns>
		public TValue this[TKey key]
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return sortedDictionary[key];
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
					sortedDictionary[key] = value;
				}
				finally
				{
					rwLock.ReleaseWriterLock();
				}
			}
		}

		/// <summary>
		/// Gets a collection containing the keys in the SortedDictionary.
		/// </summary>
		public ICollection<TKey> Keys
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					Dictionary<TKey, TValue> newDictionary = new Dictionary<TKey, TValue>(sortedDictionary);
					return newDictionary.Keys;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}

		/// <summary>
		/// Gets a collection containing the values in the SortedDictionary.
		/// </summary>
		public ICollection<TValue> Values
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					Dictionary<TKey, TValue> newDictionary = new Dictionary<TKey, TValue>(sortedDictionary);
					return newDictionary.Values;
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
		/// Adds an element with the specified key and value into the SortedDictionary.
		/// </summary>
		/// <param name="key">The key of the element to add.</param>
		/// <param name="value">The value of the element to add. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
		public void Add(TKey key, TValue value)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				sortedDictionary.Add(key, value);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		///	Removes all elements from the SortedDictionary.
		/// </summary>
		public void Clear()
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				sortedDictionary.Clear();
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Determines whether the SortedDictionary contains an element with the specified key.
		/// </summary>
		/// <param name="key">The key to locate in the SortedDictionary.</param>
		/// <returns><b>true</b> if the SortedDictionary contains an element with the specified key; otherwise, <b>false</b>.</returns>
		public bool ContainsKey(TKey key)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return sortedDictionary.ContainsKey(key);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Determines whether the SortedDictionary contains an element with the specified value.
		/// </summary>
		/// <param name="value">The value to locate in the SortedDictionary. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
		/// <returns><b>true</b> if the SortedDictionary contains an element with the specified value; otherwise, <b>false</b>.</returns>
		public bool ContainsValue(TValue value)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return sortedDictionary.ContainsValue(value);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Copies the elements of the SortedDictionary to the specified array of KeyValuePair structures, starting at the specified index.
		/// </summary>
		/// <param name="array">The one-dimensional array of KeyValuePair structures that is the destination of the elements copied from the current SortedDictionary The array must have zero-based indexing.</param>
		/// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				((ICollection<KeyValuePair<TKey, TValue>>) sortedDictionary).CopyTo(array, arrayIndex);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Returns an enumerator that iterates through the SortedDictionary.
		/// </summary>
		/// <returns>A SortedDictionary.Enumerator for the SortedDictionary.</returns>
		public IEnumerator GetEnumerator()
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				SortedDictionary<TKey, TValue> newSortedDictionary = new SortedDictionary<TKey, TValue>(sortedDictionary);
				return newSortedDictionary.GetEnumerator();
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Removes the element with the specified key from the SortedDictionary.
		/// </summary>
		/// <param name="key">The key of the element to remove.</param>
		/// <returns><b>true</b> if the element is successfully removed; otherwise, <b>false</b>. This method also returns <b>false</b> if key is not found in the SortedDictionary.</returns>
		public bool Remove(TKey key)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				return sortedDictionary.Remove(key);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Gets the value associated with the specified key.
		/// </summary>
		/// <param name="key">The key of the value to get.</param>
		/// <param name="value">When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the value parameter.</param>
		/// <returns></returns>
		public bool TryGetValue(TKey key, out TValue value)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return sortedDictionary.TryGetValue(key, out value);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}
		#endregion

		#region Explicit Interface Implementations
		/// <summary>
		/// Adds an item to the ICollection.
		/// </summary>
		/// <param name="item">The KeyValuePair structure to add to the ICollection.</param>
		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				((ICollection<KeyValuePair<TKey, TValue>>) sortedDictionary).Add(item);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Determines whether the ICollection contains a specific key and value.
		/// </summary>
		/// <param name="item">The KeyValuePair structure to locate in the ICollection.</param>
		/// <returns><b>true</b> if keyValuePair is found in the ICollection; otherwise, <b>false</b>.</returns>
		bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return ((ICollection<KeyValuePair<TKey, TValue>>) sortedDictionary).Contains(item);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Removes the first occurrence of the specified element from the ICollection.
		/// </summary>
		/// <param name="item">The KeyValuePair structure to remove from the ICollection.</param>
		/// <returns><b>true</b> if keyValuePair was successfully removed from the ICollection; otherwise, <b>false</b>. This method also returns <b>false</b> if keyValuePair was not found in the ICollection.</returns>
		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				return ((ICollection<KeyValuePair<TKey, TValue>>) sortedDictionary).Remove(item);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>An IEnumerator that can be used to iterate through the collection.</returns>
		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				Dictionary<TKey, TValue> newDictionary = new Dictionary<TKey, TValue>(sortedDictionary);
				return newDictionary.GetEnumerator();
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Copies the elements of the ICollection to an array, starting at the specified array index.
		/// </summary>
		/// <param name="array">The one-dimensional array that is the destination of the elements copied from the ICollection. The array must have zero-based indexing.</param>
		/// <param name="index">The zero-based index in array at which copying begins.</param>
		void ICollection.CopyTo(Array array, int index)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				((ICollection) sortedDictionary).CopyTo(array, index);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Adds an element with the provided key and value to the IDictionary.
		/// </summary>
		/// <param name="key">The object to use as the key of the element to add.</param>
		/// <param name="value">The object to use as the value of the element to add.</param>
		void IDictionary.Add(object key, object value)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				((IDictionary) sortedDictionary).Add(key, value);
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
				return ((IDictionary) sortedDictionary).Contains(key);
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
				SortedDictionary<TKey, TValue> newSortedDictionary = new SortedDictionary<TKey, TValue>(sortedDictionary);
				return ((IDictionary) newSortedDictionary).GetEnumerator();
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
				((IDictionary) sortedDictionary).Remove(key);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
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
					return ((ICollection<KeyValuePair<TKey, TValue>>) sortedDictionary).IsReadOnly;
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
					SortedDictionary<TKey, TValue> newSortedDictionary = new SortedDictionary<TKey, TValue>(sortedDictionary);
					return ((IDictionary<TKey, TValue>) newSortedDictionary).Keys;
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
					SortedDictionary<TKey, TValue> newSortedDictionary = new SortedDictionary<TKey, TValue>(sortedDictionary);
					return ((IDictionary<TKey, TValue>) newSortedDictionary).Values;
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
					return ((ICollection) sortedDictionary).SyncRoot;
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
					return ((IDictionary) sortedDictionary).IsFixedSize;
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
					return ((IDictionary) sortedDictionary).IsReadOnly;
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
		/// <param name="key">The key of the element to get.</param>
		/// <returns>The element with the specified key, or a null reference (Nothing in Visual Basic) if key is not in the dictionary or key is of a type that is not assignable to the key type TKey of the SortedDictionary.</returns>
		object IDictionary.this[object key]
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return ((IDictionary) sortedDictionary)[key];
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
					((IDictionary) sortedDictionary)[key] = value;
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
					SortedDictionary<TKey, TValue> newSortedDictionary = new SortedDictionary<TKey, TValue>(sortedDictionary);
					return ((IDictionary) newSortedDictionary).Keys;
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
					SortedDictionary<TKey, TValue> newSortedDictionary = new SortedDictionary<TKey, TValue>(sortedDictionary);
					return ((IDictionary) newSortedDictionary).Values;
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
