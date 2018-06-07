using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;

namespace Kalman.Collections
{
	/// <summary>
	/// Represents a variable size last-in-first-out (LIFO) collection of instances of the same arbitrary type.
	/// </summary>
	/// <typeparam name="T">Specifies the type of elements in the stack.</typeparam>
	public class SynchronizedStack<T> : IEnumerable<T>, ICollection, IEnumerable
	{
		private ReaderWriterLock rwLock;
		private Stack<T> stack;

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the Stack class that is empty and has the default initial capacity.
		/// </summary>
		public SynchronizedStack()
		{
			rwLock = new ReaderWriterLock();
			stack = new Stack<T>();
		}

		/// <summary>
		/// Initializes a new instance of the Stack class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.
		/// </summary>
		/// <param name="collection">The collection to copy elements from.</param>
		public SynchronizedStack(IEnumerable<T> collection)
		{
			rwLock = new ReaderWriterLock();
			stack = new Stack<T>(collection);
		}

		/// <summary>
		/// Initializes a new instance of the Stack class that is empty and has the specified initial capacity or the default initial capacity, whichever is greater.
		/// </summary>
		/// <param name="capacity">The initial number of elements that the Stack can contain.</param>
		public SynchronizedStack(int capacity)
		{
			rwLock = new ReaderWriterLock();
			stack = new Stack<T>(capacity);
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// Gets the number of elements contained in the Stack.
		/// </summary>
		public int Count
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return stack.Count;
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
		/// Removes all objects from the Stack.
		/// </summary>
		public void Clear()
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				stack.Clear();
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Determines whether an element is in the Stack.
		/// </summary>
		/// <param name="item">The object to locate in the Stack. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
		/// <returns><b>true</b> if item is found in the Stack; otherwise, <b>false</b>.</returns>
		public bool Contains(T item)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return stack.Contains(item);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Copies the Stack to an existing one-dimensional Array, starting at the specified array index.
		/// </summary>
		/// <param name="array">The one-dimensional Array that is the destination of the elements copied from Stack. The Array must have zero-based indexing.</param>
		/// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
		public void CopyTo(T[] array, int arrayIndex)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				stack.CopyTo(array, arrayIndex);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Returns an enumerator for the Stack.
		/// </summary>
		/// <returns>An Stack.Enumerator for the Stack.</returns>
		public IEnumerator GetEnumerator()
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				Stack<T> newStack = new Stack<T>(stack);
				return newStack.GetEnumerator();
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Returns the object at the top of the Stack without removing it.
		/// </summary>
		/// <returns>The object at the top of the Stack.</returns>
		public T Peek()
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return stack.Peek();
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Removes and returns the object at the top of the Stack.
		/// </summary>
		/// <returns>The object removed from the top of the Stack.</returns>
		public T Pop()
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				return stack.Pop();
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Inserts an object at the top of the Stack.
		/// </summary>
		/// <param name="item">The object to push onto the Stack. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
		public void Push(T item)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				stack.Push(item);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Copies the Stack to a new array.
		/// </summary>
		/// <returns>A new array containing copies of the elements of the Stack.</returns>
		public T[] ToArray()
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return stack.ToArray();
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Sets the capacity to the actual number of elements in the Stack, if that number is less than 90 percent of current capacity.
		/// </summary>
		public void TrimExcess()
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				stack.TrimExcess();
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}
		#endregion

		#region Explicit Interface Implementations
		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>An IEnumerator that can be used to iterate through the collection.</returns>
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				Stack<T> newStack = new Stack<T>(stack);
				return newStack.GetEnumerator();
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
		/// <param name="index">The zero-based index in array at which copying begins.</param>
		void ICollection.CopyTo(Array array, int index)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				((ICollection) stack).CopyTo(array, index);
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
					return ((ICollection) stack).SyncRoot;
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
