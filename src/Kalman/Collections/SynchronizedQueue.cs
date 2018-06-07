using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;

namespace Kalman.Collections
{
	/// <summary>
	/// Represents a first-in, first-out synchronized collection of objects.
	/// </summary>
	/// <typeparam name="T">Specifies the type of elements in the queue.</typeparam>
	public class SynchronizedQueue<T> : IEnumerable<T>, ICollection, IEnumerable
	{
		private ReaderWriterLock rwLock;
		private Queue<T> queue;

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the Queue class that is empty and has the default initial capacity.
		/// </summary>
		public SynchronizedQueue()
		{
			rwLock = new ReaderWriterLock();
			queue = new Queue<T>();
		}

		/// <summary>
		///	Initializes a new instance of the Queue class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.
		/// </summary>
		/// <param name="collection">The collection whose elements are copied to the new Queue.</param>
		public SynchronizedQueue(ICollection<T> collection)
		{
			rwLock = new ReaderWriterLock();
			queue = new Queue<T>(collection);
		}

		/// <summary>
		/// Initializes a new instance of the Queue class that is empty and has the specified initial capacity.
		/// </summary>
		/// <param name="capacity">The initial number of elements that the Queue can contain.</param>
		public SynchronizedQueue(int capacity)
		{
			rwLock = new ReaderWriterLock();
			queue = new Queue<T>(capacity);
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// Gets the number of elements contained in the Queue.
		/// </summary>
		public int Count
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return queue.Count;
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
		/// Removes all objects from the Queue.
		/// </summary>
		public void Clear()
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				queue.Clear();
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Determines whether an element is in the Queue.
		/// </summary>
		/// <param name="item">The object to locate in the Queue. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
		/// <returns><b>true</b> if item is found in the Queue; otherwise, <b>false</b>.</returns>
		public bool Contains(T item)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return queue.Contains(item);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Copies the Queue elements to an existing one-dimensional Array, starting at the specified array index.
		/// </summary>
		/// <param name="array">The one-dimensional Array that is the destination of the elements copied from Queue. The Array must have zero-based indexing.</param>
		/// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
		public void CopyTo(T[] array, int arrayIndex)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				queue.CopyTo(array, arrayIndex);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		///	Removes and returns the object at the beginning of the Queue.
		/// </summary>
		/// <returns>The object that is removed from the beginning of the Queue.</returns>
		public T Dequeue()
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				return queue.Dequeue();
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Adds an object to the end of the Queue.
		/// </summary>
		/// <param name="item">The object to add to the Queue. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
		public void Enqueue(T item)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				queue.Enqueue(item);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Returns an enumerator that iterates through the Queue.
		/// </summary>
		/// <returns>An Queue.Enumerator for the Queue.</returns>
		public IEnumerator GetEnumerator()
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				Queue<T> newQueue = new Queue<T>(queue);
				return newQueue.GetEnumerator();
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Returns the object at the beginning of the Queue without removing it.
		/// </summary>
		/// <returns>The object at the beginning of the Queue.</returns>
		public T Peek()
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return queue.Peek();
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Copies the Queue elements to a new array.
		/// </summary>
		/// <returns>A new array containing elements copied from the Queue.</returns>
		public T[] ToArray()
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return queue.ToArray();
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Sets the capacity to the actual number of elements in the Queue, if that number is less than 90 percent of current capacity.
		/// </summary>
		public void TrimExcess()
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				queue.TrimExcess();
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}
		#endregion

		#region Explicit Interface Implementations
		/// <summary>
		///	Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>An IEnumerator that can be used to iterate through the collection.</returns>
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				Queue<T> newQueue = new Queue<T>(queue);
				return newQueue.GetEnumerator();
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// the elements of the ICollection to an Array, starting at a particular Array index.
		/// </summary>
		/// <param name="array">The one-dimensional Array that is the destination of the elements copied from ICollection. The Array must have zero-based indexing.</param>
		/// <param name="index">The zero-based index in array at which copying begin.</param>
		void ICollection.CopyTo(Array array, int index)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				((ICollection) queue).CopyTo(array, index);
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
					return ((ICollection) queue).SyncRoot;
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
