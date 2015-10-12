using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;

namespace Kalman.Collections
{
	/// <summary>
	/// Represents a syncrhonized collection of keys and values.
	/// </summary>
	/// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
	/// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
	public class SynchronizedDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IDictionary, ICollection, IEnumerable, ISerializable, IDeserializationCallback
	{
		private ReaderWriterLock rwLock;
		private Dictionary<TKey, TValue> dictionary;

		#region Public Constructors
		/// <summary>
		/// Initializes a new instance of the Dictionary class that is empty, has the default initial capacity, and uses the default equality comparer for the key type.
		/// </summary>
		public SynchronizedDictionary()
		{
			rwLock = new ReaderWriterLock();
			dictionary = new Dictionary<TKey, TValue>();
		}

		/// <summary>
		/// Initializes a new instance of the Dictionary class that contains elements copied from the specified IDictionary and uses the default equality comparer for the key type.
		/// </summary>
		/// <param name="dictionary">The IDictionary whose elements are copied to the new Dictionary.</param>
		public SynchronizedDictionary(IDictionary<TKey, TValue> dictionary)
		{
			rwLock = new ReaderWriterLock();
			this.dictionary = new Dictionary<TKey, TValue>(dictionary);
		}

		/// <summary>
		/// Initializes a new instance of the Dictionary class that is empty, has the default initial capacity, and uses the specified IEqualityComparer.
		/// </summary>
		/// <param name="comparer">The IEqualityComparer implementation to use when comparing keys, or a null reference (Nothing in Visual Basic) to use the default EqualityComparer for the type of the key.</param>
		public SynchronizedDictionary(IEqualityComparer<TKey> comparer)
		{
			rwLock = new ReaderWriterLock();
			dictionary = new Dictionary<TKey, TValue>(comparer);
		}

		/// <summary>
		/// Initializes a new instance of the Dictionary class that is empty, has the specified initial capacity, and uses the default equality comparer for the key type.
		/// </summary>
		/// <param name="capacity">The initial number of elements that the Dictionary can contain.</param>
		public SynchronizedDictionary(int capacity)
		{
			rwLock = new ReaderWriterLock();
			dictionary = new Dictionary<TKey, TValue>(capacity);
		}

		/// <summary>
		/// Initializes a new instance of the Dictionary class that contains elements copied from the specified IDictionary and uses the specified IEqualityComparer.
		/// </summary>
		/// <param name="dictionary">The IDictionary whose elements are copied to the new Dictionary.</param>
		/// <param name="comparer">The IEqualityComparer implementation to use when comparing keys, or a null reference (Nothing in Visual Basic) to use the default EqualityComparer for the type of the key.</param>
		public SynchronizedDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
		{
			rwLock = new ReaderWriterLock();
			this.dictionary = new Dictionary<TKey, TValue>(dictionary, comparer);
		}

		/// <summary>
		/// Initializes a new instance of the Dictionary class that is empty, has the specified initial capacity, and uses the specified IEqualityComparer.
		/// </summary>
		/// <param name="capacity">The initial number of elements that the Dictionary can contain.</param>
		/// <param name="comparer">The IEqualityComparer implementation to use when comparing keys, or a null reference (Nothing in Visual Basic) to use the default EqualityComparer for the type of the key.</param>
		public SynchronizedDictionary(int capacity, IEqualityComparer<TKey> comparer)
		{
			rwLock = new ReaderWriterLock();
			dictionary = new Dictionary<TKey, TValue>(capacity, comparer);
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// Gets the IEqualityComparer that is used to determine equality of keys for the dictionary.
		/// </summary>
		public IEqualityComparer<TKey> Comparer
		{
			get { return dictionary.Comparer; }
		}

		/// <summary>
		/// Gets the number of key/value pairs contained in the Dictionary.
		/// </summary>
		public int Count
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return dictionary.Count;
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
					return dictionary[key];
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
					dictionary[key] = value;
				}
				finally
				{
					rwLock.ReleaseWriterLock();
				}
			}
		}

		/// <summary>
		/// Gets a collection containing the keys in the Dictionary.
		/// </summary>
		public ICollection<TKey> Keys
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					Dictionary<TKey, TValue> newDictionary = new Dictionary<TKey, TValue>(dictionary);
					return newDictionary.Keys;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}

		/// <summary>
		/// Gets a collection containing the values in the Dictionary.
		/// </summary>
		public ICollection<TValue> Values
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					Dictionary<TKey, TValue> newDictionary = new Dictionary<TKey, TValue>(dictionary);
					return newDictionary.Values;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}
		#endregion

		#region Public Members
		/// <summary>
		/// Adds the specified key and value to the dictionary.
		/// </summary>
		/// <param name="key">The key of the element to add.</param>
		/// <param name="value">The value of the element to add. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
		public void Add(TKey key, TValue value)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				dictionary.Add(key, value);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Removes all keys and values from the Dictionary.
		/// </summary>
		public void Clear()
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				dictionary.Clear();
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Determines whether the Dictionary contains the specified key.
		/// </summary>
		/// <param name="key">The key to locate in the Dictionary.</param>
		/// <returns><b>true</b> if the Dictionary contains an element with the specified key; otherwise, <b>false</b>.</returns>
		public bool ContainsKey(TKey key)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return dictionary.ContainsKey(key);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Determines whether the Dictionary contains the specified value.
		/// </summary>
		/// <param name="value">The value to locate in the Dictionary.</param>
		/// <returns><b>true</b> if the Dictionary contains an element with the specified value; otherwise, <b>false</b>.</returns>
		public bool ContainsValue(TValue value)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return dictionary.ContainsValue(value);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>An IEnumerator that can be used to iterate through the collection.</returns>
		public IEnumerator GetEnumerator()
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				Dictionary<TKey, TValue> newDictionary = new Dictionary<TKey, TValue>(dictionary);
				return newDictionary.GetEnumerator();
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}
		
		/// <summary>
		/// Implements the System.Runtime.Serialization.ISerializable interface and returns the data needed to serialize the Dictionary instance.
		/// </summary>
		/// <param name="info">A System.Runtime.Serialization.SerializationInfo object that contains the information required to serialize the Dictionary instance.</param>
		/// <param name="context">A System.Runtime.Serialization.StreamingContext structure that contains the source and destination of the serialized stream associated with the Dictionary instance.</param>
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				((ISerializable) dictionary).GetObjectData(info, context);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Implements the System.Runtime.Serialization.ISerializable interface and raises the deserialization event when the deserialization is complete.
		/// </summary>
		/// <param name="sender">The source of the deserialization event.</param>
		public void OnDeserialization(object sender)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				((IDeserializationCallback) dictionary).OnDeserialization(sender);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Removes the value with the specified key from the Dictionary.
		/// </summary>
		/// <param name="key">The key of the element to remove.</param>
		/// <returns><b>true</b> if the element is successfully found and removed; otherwise, <b>false</b>. This method returns <b>false</b> if key is not found in the Dictionary.</returns>
		public bool Remove(TKey key)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				return dictionary.Remove(key);
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
		/// <param name="value">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, the default value for the type of the <i>value</i> parameter. This parameter is passed uninitialized.</param>
		/// <returns><b>true</b> if the Dictionary contains an element with the specified key; otherwise, <b>false</b>.</returns>
		public bool TryGetValue(TKey key, out TValue value)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return dictionary.TryGetValue(key, out value);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}
		#endregion

		#region Explicit Interface Implementations
		/// <summary>
		/// Adds the specified value to the ICollection with the specified key.
		/// </summary>
		/// <param name="item">The KeyValuePair structure representing the key and value to add to the Dictionary.</param>
		void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				((ICollection<KeyValuePair<TKey, TValue>>) dictionary).Add(item);
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
				return ((ICollection<KeyValuePair<TKey, TValue>>) dictionary).Contains(item);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Copies the elements of the ICollection to an array of type KeyValuePair, starting at the specified array index.
		/// </summary>
		/// <param name="array">The one-dimensional array of type KeyValuePair that is the destination of the KeyValuePair elements copied from the ICollection. The array must have zero-based indexing.</param>
		/// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
		void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				((ICollection<KeyValuePair<TKey, TValue>>) dictionary).CopyTo(array, arrayIndex);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Gets a value indicating whether the dictionary is read-only.
		/// </summary>
		bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return ((ICollection<KeyValuePair<TKey, TValue>>) dictionary).IsReadOnly;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}

		/// <summary>
		/// Removes a key and value from the dictionary.
		/// </summary>
		/// <param name="item">The KeyValuePair structure representing the key and value to remove from the Dictionary.</param>
		/// <returns><b>true</b> if the key and value represented by keyValuePair is successfully found and removed; otherwise, <b>false</b>. This method returns <b>false</b> if keyValuePair is not found in the ICollection.</returns>
		bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				return ((ICollection<KeyValuePair<TKey, TValue>>) dictionary).Remove(item);
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
				Dictionary<TKey, TValue> newDictionary = new Dictionary<TKey, TValue>(dictionary);
				return newDictionary.GetEnumerator();
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Adds the specified key and value to the dictionary.
		/// </summary>
		/// <param name="key">The object to use as the key.</param>
		/// <param name="value">The object to use as the value.</param>
		void IDictionary.Add(object key, object value)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				((IDictionary) dictionary).Add(key, value);
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
		/// <returns><b>true</b> if the IDictionary contains an element with the specified key; otherwise, <b>false</b>.</returns>
		bool IDictionary.Contains(object key)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return ((IDictionary) dictionary).Contains(key);
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
				return ((IDictionary) dictionary).GetEnumerator();
			}
			finally
			{
				rwLock.ReleaseReaderLock();
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
					return ((IDictionary) dictionary).IsFixedSize;
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
					return ((IDictionary) dictionary).IsReadOnly;
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
		ICollection IDictionary.Keys
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					IDictionary<TKey, TValue> newDictionary = new Dictionary<TKey, TValue>(dictionary);
					return ((IDictionary) newDictionary).Keys;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
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
				((IDictionary) dictionary).Remove(key);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
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
					IDictionary<TKey, TValue> newDictionary = new Dictionary<TKey, TValue>(dictionary);
					return ((IDictionary) newDictionary).Values;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}

		/// <summary>
		/// Gets or sets the value with the specified key.
		/// </summary>
		/// <param name="key">The key of the value to get.</param>
		/// <returns>The value associated with the specified key, or a null reference (Nothing in Visual Basic) if key is not in the dictionary or key is of a type that is not assignable to the key type TKey of the Dictionary.</returns>
		object IDictionary.this[object key]
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return ((IDictionary) dictionary)[key];
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
					((IDictionary) dictionary)[key] = value;
				}
				finally
				{
					rwLock.ReleaseWriterLock();
				}
			}
		}

		/// <summary>
		/// Copies the elements of the ICollection to an array, starting at the specified array index.
		/// </summary>
		/// <param name="array">The one-dimensional array that is the destination of the elements copied from ICollection. The array must have zero-based indexing.</param>
		/// <param name="index">The zero-based index in array at which copying begins.</param>
		void ICollection.CopyTo(Array array, int index)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				((ICollection) dictionary).CopyTo(array, index);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
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
					return ((ICollection) dictionary).SyncRoot;
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
