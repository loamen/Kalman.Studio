using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;

namespace Kalman.Collections
{
	/// <summary>
	/// Represents a sychronized doubly linked list.
	/// </summary>
	/// <typeparam name="T">Specifies the element type of the linked list.</typeparam>
	public class SynchronizedLinkedList<T> : ICollection<T>, IEnumerable<T>, ICollection, IEnumerable, ISerializable, IDeserializationCallback
	{
		private ReaderWriterLock rwLock;
		private LinkedList<T> linkedList;

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the LinkedList class that is empty.
		/// </summary>
		public SynchronizedLinkedList()
		{
			rwLock = new ReaderWriterLock();
			linkedList = new LinkedList<T>();
		}

		/// <summary>
		/// Initializes a new instance of the LinkedList class that contains elements copied from the specified IEnumerable and has sufficient capacity to accommodate the number of elements copied.
		/// </summary>
		/// <param name="collection">The IEnumerable whose elements are copied to the new LinkedList.</param>
		public SynchronizedLinkedList(IEnumerable<T> collection)
		{
			rwLock = new ReaderWriterLock();
			linkedList = new LinkedList<T>(collection);
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// Gets the number of nodes actually contained in the LinkedList.
		/// </summary>
		public int Count
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return linkedList.Count;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}

		/// <summary>
		/// Gets the first node of the LinkedList.
		/// </summary>
		public LinkedListNode<T> First
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return linkedList.First;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}

		/// <summary>
		/// Gets the last node of the LinkedList.
		/// </summary>
		public LinkedListNode<T> Last
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return linkedList.Last;
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
		/// Adds the specified new node after the specified existing node in the LinkedList.
		/// </summary>
		/// <param name="node">The LinkedListNode after which to insert <i>newNode</i>.</param>
		/// <param name="newNode">The new LinkedListNode to add to the LinkedList.</param>
		public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				linkedList.AddAfter(node, newNode);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Adds a new node containing the specified value after the specified existing node in the LinkedList.
		/// </summary>
		/// <param name="node">The LinkedListNode after which to insert a new LinkedListNode containing value.</param>
		/// <param name="value">The value to add to the LinkedList.</param>
		public void AddAfter(LinkedListNode<T> node, T value)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				linkedList.AddAfter(node, value);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Adds the specified new node before the specified existing node in the LinkedList.
		/// </summary>
		/// <param name="node">The LinkedListNode before which to insert <i>newNode</i>.</param>
		/// <param name="newNode">new LinkedListNode to add to the LinkedList.</param>
		public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				linkedList.AddBefore(node, newNode);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Adds a new node containing the specified value before the specified existing node in the LinkedList.
		/// </summary>
		/// <param name="node">The LinkedListNode before which to insert a new LinkedListNode containing value.</param>
		/// <param name="value">The value to add to the LinkedList.</param>
		public void AddBefore(LinkedListNode<T> node, T value)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				linkedList.AddBefore(node, value);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Adds the specified new node at the start of the LinkedList.
		/// </summary>
		/// <param name="node">new LinkedListNode to add at the start of the LinkedList.</param>
		public void AddFirst(LinkedListNode<T> node)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				linkedList.AddFirst(node);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Adds a new node containing the specified value at the start of the LinkedList.
		/// </summary>
		/// <param name="value">The value to add at the start of the LinkedList.</param>
		public void AddFirst(T value)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				linkedList.AddFirst(value);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Adds the specified new node at the end of the LinkedList.
		/// </summary>
		/// <param name="node">The new LinkedListNode to add at the end of the LinkedList.</param>
		public void AddLast(LinkedListNode<T> node)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				linkedList.AddLast(node);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Adds a new node containing the specified value at the end of the LinkedList.
		/// </summary>
		/// <param name="value">The value to add at the end of the LinkedList.</param>
		public void AddLast(T value)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				linkedList.AddLast(value);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Removes all nodes from the LinkedList.
		/// </summary>
		public void Clear()
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				linkedList.Clear();
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Determines whether a value is in the LinkedList.
		/// </summary>
		/// <param name="item">The value to locate in the LinkedList. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
		/// <returns><b>true</b> if value is found in the LinkedList; otherwise, <b>false</b>.</returns>
		public bool Contains(T item)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return linkedList.Contains(item);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Copies the entire LinkedList to a compatible one-dimensional Array, starting at the specified index of the target array.
		/// </summary>
		/// <param name="array">The one-dimensional Array that is the destination of the elements copied from LinkedList. The Array must have zero-based indexing.</param>
		/// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
		public void CopyTo(T[] array, int arrayIndex)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				linkedList.CopyTo(array, arrayIndex);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Finds the first node that contains the specified value.
		/// </summary>
		/// <param name="value">The value to locate in the LinkedLis.</param>
		/// <returns>The first LinkedListNode that contains the specified value, if found; otherwise, a null reference (Nothing in Visual Basic).</returns>
		public LinkedListNode<T> Find(T value)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return linkedList.Find(value);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Finds the last node that contains the specified value.
		/// </summary>
		/// <param name="value">The value to locate in the LinkedList.</param>
		/// <returns>The last LinkedListNode that contains the specified value, if found; otherwise, a null reference (Nothing in Visual Basic).</returns>
		public LinkedListNode<T> FindLast(T value)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return linkedList.FindLast(value);
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
				LinkedList<T> newLinkedList = new LinkedList<T>(linkedList);
				return newLinkedList.GetEnumerator();
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
				((ISerializable) linkedList).GetObjectData(info, context);
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
				((IDeserializationCallback) linkedList).OnDeserialization(sender);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Removes the specified node from the LinkedList.
		/// </summary>
		/// <param name="node">The LinkedListNode to remove from the LinkedList.</param>
		public void Remove(LinkedListNode<T> node)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				linkedList.Remove(node);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Removes the first occurrence of the specified value from the LinkedList.
		/// </summary>
		/// <param name="item">The value to remove from the LinkedList.</param>
		/// <returns><b>true</b> if the element containing value is successfully removed; otherwise, <b>false</b>. This method also returns <b>false</b> if value was not found in the original LinkedList.</returns>
		public bool Remove(T item)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				return linkedList.Remove(item);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Removes the node at the start of the LinkedList.
		/// </summary>
		public void RemoveFirst()
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				linkedList.RemoveFirst();
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Removes the node at the end of the LinkedList.
		/// </summary>
		public void RemoveLast()
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				linkedList.RemoveLast();
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}
		#endregion

		#region Explicit Interface Implementations
		/// <summary>
		/// Adds an item at the end of the ICollection.
		/// </summary>
		/// <param name="item">The value to add at the end of the ICollection.</param>
		void ICollection<T>.Add(T item)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				linkedList.AddLast(item);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>An IEnumerator that can be used to iterate through the collection.</returns>
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				LinkedList<T> newLinkedList = new LinkedList<T>(linkedList);
				return newLinkedList.GetEnumerator();
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Gets a value indicating whether the ICollection is read-only.
		/// </summary>
		bool ICollection<T>.IsReadOnly
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return ((ICollection<T>) linkedList).IsReadOnly;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
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
				((ICollection) linkedList).CopyTo(array, index);
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
					return ((ICollection) linkedList).SyncRoot;
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
