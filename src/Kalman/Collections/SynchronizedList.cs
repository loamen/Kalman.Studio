using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Threading;

namespace Kalman.Collections
{
	/// <summary>
	/// Represents a strongly typed list of objects that can be accessed by index. Provides methods to search, sort, and manipulate lists.
	/// </summary>
	/// <typeparam name="T">The type of elements in the list.</typeparam>
	public class SynchronizedList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IList, ICollection, IEnumerable
	{
		private ReaderWriterLock rwLock;
		private List<T> list;

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the List class that is empty and has the default initial capacity.
		/// </summary>
		public SynchronizedList()
		{
			rwLock = new ReaderWriterLock();
			list = new List<T>();
		}

		/// <summary>
		/// Initializes a new instance of the List class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.
		/// </summary>
		/// <param name="collection">The collection whose elements are copied to the new list.</param>
		public SynchronizedList(IEnumerable<T> collection)
		{
			rwLock = new ReaderWriterLock();
			list = new List<T>(collection);
		}

		/// <summary>
		/// Initializes a new instance of the List class that is empty and has the specified initial capacity.
		/// </summary>
		/// <param name="capacity">The number of elements that the new list can initially store.</param>
		public SynchronizedList(int capacity)
		{
			rwLock = new ReaderWriterLock();
			list = new List<T>(capacity);
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// Gets or sets the total number of elements the internal data structure can hold without resizing.
		/// </summary>
		public int Capacity
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return list.Capacity;
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
					list.Capacity = value;
				}
				finally
				{
					rwLock.ReleaseWriterLock();
				}
			}
		}

		/// <summary>
		/// Gets the number of elements actually contained in the List.
		/// </summary>
		public int Count
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return list.Count;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}

		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index of the element to get or set.</param>
		/// <returns>The element at the specified index.</returns>
		public T this[int index]
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return list[index];
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
					list[index] = value;
				}
				finally
				{
					rwLock.ReleaseWriterLock();
				}
			}
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Adds an object to the end of the List.
		/// </summary>
		/// <param name="item">object to be added to the end of the List. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
		public void Add(T item)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				list.Add(item);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Adds the elements of the specified collection to the end of the List.
		/// </summary>
		/// <param name="collection">The collection whose elements should be added to the end of the List. The collection itself cannot be a null reference (Nothing in Visual Basic), but it can contain elements that are a null reference (Nothing in Visual Basic), if type T is a reference type.</param>
		public void AddRange(IEnumerable<T> collection)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				list.AddRange(collection);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Returns a read-only IList wrapper for the current collection.
		/// </summary>
		/// <returns>A ReadOnlyCollection that acts as a read-only wrapper around the current List.</returns>
		public ReadOnlyCollection<T> AsReadOnly()
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.AsReadOnly();
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Searches the entire sorted List for an element using the default comparer and returns the zero-based index of the element.
		/// </summary>
		/// <param name="item">The object to locate. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
		/// <returns>The zero-based index of item in the sorted List, if item is found; otherwise, a negative number that is the bitwise complement of the index of the next element that is larger than item or, if there is no larger element, the bitwise complement of Count.</returns>
		public int BinarySearch(T item)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.BinarySearch(item);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Searches the entire sorted List for an element using the specified comparer and returns the zero-based index of the element.
		/// </summary>
		/// <param name="item">The object to locate. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
		/// <param name="comparer">The IComparer implementation to use when comparing elements, or a null reference (Nothing in Visual Basic) to use the default comparer Comparer.</param>
		/// <returns>The zero-based index of item in the sorted List, if item is found; otherwise, a negative number that is the bitwise complement of the index of the next element that is larger than item or, if there is no larger element, the bitwise complement of Count.</returns>
		public int BinarySearch(T item, IComparer<T> comparer)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.BinarySearch(item, comparer);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Searches a range of elements in the sorted List for an element using the specified comparer and returns the zero-based index of the element.
		/// </summary>
		/// <param name="index">The zero-based starting index of the range to search.</param>
		/// <param name="count">The length of the range to search.</param>
		/// <param name="item">The object to locate. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
		/// <param name="comparer">The IComparer implementation to use when comparing elements, or a null reference (Nothing in Visual Basic) to use the default comparer Comparer.</param>
		/// <returns>The zero-based index of item in the sorted List, if item is found; otherwise, a negative number that is the bitwise complement of the index of the next element that is larger than item or, if there is no larger element, the bitwise complement of Count.</returns>
		public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.BinarySearch(index, count, item, comparer);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Removes all elements from the List.
		/// </summary>
		public void Clear()
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				list.Clear();
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Determines whether an element is in the List.
		/// </summary>
		/// <param name="item">The object to locate in the List. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
		/// <returns><b>true</b> if item is found in the List; otherwise, <b>false</b>.</returns>
		public bool Contains(T item)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.Contains(item);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Converts the elements in the current List to another type, and returns a list containing the converted elements.
		/// </summary>
		/// <typeparam name="TOutput">The type each element in the list should be converted to.</typeparam>
		/// <param name="converter">A Converter delegate that converts each element from one type to another type.</param>
		/// <returns>A List of the target type containing the converted elements from the current List.</returns>
		public List<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.ConvertAll<TOutput>(converter);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Copies the entire List to a compatible one-dimensional array, starting at the beginning of the target array.
		/// </summary>
		/// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
		public void CopyTo(T[] array)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				list.CopyTo(array);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Copies the entire List to a compatible one-dimensional array, starting at the specified index of the target array.
		/// </summary>
		/// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
		/// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
		public void CopyTo(T[] array, int arrayIndex)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				list.CopyTo(array, arrayIndex);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Copies a range of elements from the List to a compatible one-dimensional array, starting at the specified index of the target array.
		/// </summary>
		/// <param name="index">The zero-based index in the source List at which copying begins.</param>
		/// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing</param>
		/// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
		/// <param name="count">The number of elements to copy.</param>
		public void CopyTo(int index, T[] array, int arrayIndex, int count)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				list.CopyTo(index, array, arrayIndex, count);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Determines whether the List contains elements that match the conditions defined by the specified predicate.
		/// </summary>
		/// <param name="match">The Predicate delegate that defines the conditions of the elements to search for.</param>
		/// <returns><b>true</b> if the List contains one or more elements that match the conditions defined by the specified predicate; otherwise, <b>false</b>.</returns>
		public bool Exists(Predicate<T> match)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.Exists(match);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Searches for an element that matches the conditions defined by the specified predicate, and returns the first occurrence within the entire List.
		/// </summary>
		/// <param name="match">The Predicate delegate that defines the conditions of the element to search for.</param>
		/// <returns>first element that matches the conditions defined by the specified predicate, if found; otherwise, the default value for type <i>T</i>.</returns>
		public T Find(Predicate<T> match)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.Find(match);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Retrieves all the elements that match the conditions defined by the specified predicate.
		/// </summary>
		/// <param name="match">The Predicate delegate that defines the conditions of the elements to search for.</param>
		/// <returns>A List containing all the elements that match the conditions defined by the specified predicate, if found; otherwise, an empty List.</returns>
		public List<T> FindAll(Predicate<T> match)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.FindAll(match);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence within the entire List.
		/// </summary>
		/// <param name="match">The Predicate delegate that defines the conditions of the element to search for.</param>
		/// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by match, if found; otherwise, ?.</returns>
		public int FindIndex(Predicate<T> match)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.FindIndex(match);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence within the range of elements in the List that extends from the specified index to the last element.
		/// </summary>
		/// <param name="startIndex">The zero-based starting index of the search.</param>
		/// <param name="match">The Predicate delegate that defines the conditions of the element to search for.</param>
		/// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by match, if found; otherwise, ?.</returns>
		public int FindIndex(int startIndex, Predicate<T> match)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.FindIndex(startIndex, match);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Searches for an element that matches the conditions defined by the specified predicate, and returns the last occurrence within the entire List.
		/// </summary>
		/// <param name="match">The Predicate delegate that defines the conditions of the element to search for.</param>
		/// <returns>The last element that matches the conditions defined by the specified predicate, if found; otherwise, the default value for type <i>T</i>.</returns>
		public T FindLast(Predicate<T> match)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.FindLast(match);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the last occurrence within the entire List.
		/// </summary>
		/// <param name="match">The Predicate delegate that defines the conditions of the element to search for.</param>
		/// <returns>The zero-based index of the last occurrence of an element that matches the conditions defined by match, if found; otherwise, ?.</returns>
		public int FindLastIndex(Predicate<T> match)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.FindLastIndex(match);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the last occurrence within the range of elements in the List that extends from the first element to the specified index.
		/// </summary>
		/// <param name="startIndex">The zero-based starting index of the backward search.</param>
		/// <param name="match">The Predicate delegate that defines the conditions of the element to search for.</param>
		/// <returns>The zero-based index of the last occurrence of an element that matches the conditions defined by match, if found; otherwise, ?.</returns>
		public int FindLastIndex(int startIndex, Predicate<T> match)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.FindLastIndex(startIndex, match);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the last occurrence within the range of elements in the List that contains the specified number of elements and ends at the specified index.
		/// </summary>
		/// <param name="startIndex">The zero-based starting index of the backward search.</param>
		/// <param name="count">The number of elements in the section to search.</param>
		/// <param name="match">The Predicate delegate that defines the conditions of the element to search for.</param>
		/// <returns>The zero-based index of the last occurrence of an element that matches the conditions defined by match, if found; otherwise, ?.</returns>
		public int FindLastIndex(int startIndex, int count, Predicate<T> match)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.FindLastIndex(startIndex, count, match);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Performs the specified action on each element of the List.
		/// </summary>
		/// <param name="action">The Action delegate to perform on each element of the List.</param>
		public void ForEach(Action<T> action)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				list.ForEach(action);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Returns an enumerator that iterates through the List.
		/// </summary>
		/// <returns>A List.Enumerator for the List.</returns>
		public IEnumerator GetEnumerator()
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				List<T> newList = new List<T>(list);
				return newList.GetEnumerator();
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Creates a shallow copy of a range of elements in the source List.
		/// </summary>
		/// <param name="index">The zero-based List index at which the range starts.</param>
		/// <param name="count">The number of elements in the range.</param>
		/// <returns>A shallow copy of a range of elements in the source List.</returns>
		public List<T> GetRange(int index, int count)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.GetRange(index, count);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Searches for the specified object and returns the zero-based index of the first occurrence within the entire List.
		/// </summary>
		/// <param name="item">The object to locate in the List. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
		/// <returns>The zero-based index of the first occurrence of item within the entire List, if found; otherwise, ?.</returns>
		public int IndexOf(T item)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.IndexOf(item);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Searches for the specified object and returns the zero-based index of the first occurrence within the range of elements in the List that extends from the specified index to the last element.
		/// </summary>
		/// <param name="item">The object to locate in the List. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
		/// <param name="index">The zero-based starting index of the search.</param>
		/// <returns>zero-based index of the first occurrence of item within the range of elements in the List that extends from index to the last element, if found; otherwise, ?.</returns>
		public int IndexOf(T item, int index)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.IndexOf(item, index);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Searches for the specified object and returns the zero-based index of the first occurrence within the range of elements in the List that starts at the specified index and contains the specified number of elements.
		/// </summary>
		/// <param name="item">The object to locate in the List. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
		/// <param name="index">The zero-based starting index of the search.</param>
		/// <param name="count">The number of elements in the section to search.</param>
		/// <returns>The zero-based index of the first occurrence of item within the range of elements in the List that starts at index and contains count number of elements, if found; otherwise, ?.</returns>
		public int IndexOf(T item, int index, int count)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.IndexOf(item, index, count);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Inserts an element into the List at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index at which item should be inserted.</param>
		/// <param name="item">The object to insert. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
		public void Insert(int index, T item)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				list.Insert(index, item);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Inserts the elements of a collection into the List at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index at which the new elements should be inserted.</param>
		/// <param name="collection">The collection whose elements should be inserted into the List. The collection itself cannot be a null reference (Nothing in Visual Basic), but it can contain elements that are a null reference (Nothing in Visual Basic), if type T is a reference type.</param>
		public void InsertRange(int index, IEnumerable<T> collection)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				list.InsertRange(index, collection);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Searches for the specified object and returns the zero-based index of the last occurrence within the entire List.
		/// </summary>
		/// <param name="item">The object to locate in the List. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
		/// <returns>The zero-based index of the last occurrence of item within the entire the List, if found; otherwise, ?.</returns>
		public int LastIndexOf(T item)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.LastIndexOf(item);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Searches for the specified object and returns the zero-based index of the last occurrence within the range of elements in the List that extends from the first element to the specified index.
		/// </summary>
		/// <param name="item"> object to locate in the List. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
		/// <param name="index">The zero-based starting index of the backward search.</param>
		/// <returns>The zero-based index of the last occurrence of item within the range of elements in the List that extends from the first element to index, if found; otherwise, ?.</returns>
		public int LastIndexOf(T item, int index)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.LastIndexOf(item, index);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Searches for the specified object and returns the zero-based index of the last occurrence within the range of elements in the List that contains the specified number of elements and ends at the specified index.
		/// </summary>
		/// <param name="item">The object to locate in the List. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
		/// <param name="index">The zero-based starting index of the backward search.</param>
		/// <param name="count">The number of elements in the section to search.</param>
		/// <returns>The zero-based index of the last occurrence of item within the range of elements in the List that contains count number of elements and ends at index, if found; otherwise, ?.</returns>
		public int LastIndexOf(T item, int index, int count)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.LastIndexOf(item, index, count);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Removes the first occurrence of a specific object from the List.
		/// </summary>
		/// <param name="item">The object to remove from the List. The value can be a null reference (Nothing in Visual Basic) for reference types.</param>
		/// <returns><b>true</b> if item is successfully removed; otherwise, <b>false</b>. This method also returns <b>false</b> if item was not found in the List.</returns>
		public bool Remove(T item)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				return list.Remove(item);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Removes the all the elements that match the conditions defined by the specified predicate.
		/// </summary>
		/// <param name="match">The Predicate delegate that defines the conditions of the elements to remove.</param>
		/// <returns>The number of elements removed from the List.</returns>
		public int RemoveAll(Predicate<T> match)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				return list.RemoveAll(match);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Removes the element at the specified index of the List.
		/// </summary>
		/// <param name="index">The zero-based index of the element to remove.</param>
		public void RemoveAt(int index)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				list.RemoveAt(index);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Removes a range of elements from the List.
		/// </summary>
		/// <param name="index">The zero-based starting index of the range of elements to remove.</param>
		/// <param name="count">The number of elements to remove.</param>
		public void RemoveRange(int index, int count)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				list.RemoveRange(index, count);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Reverses the order of the elements in the entire List.
		/// </summary>
		public void Reverse()
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				list.Reverse();
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Reverses the order of the elements in the specified range.
		/// </summary>
		/// <param name="index">The zero-based starting index of the range to reverse.</param>
		/// <param name="count">The number of elements in the range to reverse.</param>
		public void Reverse(int index, int count)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				list.Reverse(index, count);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Sorts the elements in the entire List using the default comparer.
		/// </summary>
		public void Sort()
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				list.Sort();
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Sorts the elements in the entire List using the specified System.Comparison.
		/// </summary>
		/// <param name="comparison">The System.Comparison to use when comparing elements.</param>
		public void Sort(Comparison<T> comparison)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				list.Sort(comparison);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Sorts the elements in the entire List using the specified comparer.
		/// </summary>
		/// <param name="comparer">The IComparer implementation to use when comparing elements, or a null reference (Nothing in Visual Basic) to use the default comparer.</param>
		public void Sort(IComparer<T> comparer)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				list.Sort(comparer);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Sorts the elements in a range of elements in List using the specified comparer.
		/// </summary>
		/// <param name="index">The zero-based starting index of the range to sort.</param>
		/// <param name="count">The length of the range to sort.</param>
		/// <param name="comparer">The IComparer implementation to use when comparing elements, or a null reference (Nothing in Visual Basic) to use the default comparer.</param>
		public void Sort(int index, int count, IComparer<T> comparer)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				list.Sort();
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Copies the elements of the List to a new array.
		/// </summary>
		/// <returns>An array containing copies of the elements of the List.</returns>
		public T[] ToArrary()
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.ToArray();
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Sets the capacity to the actual number of elements in the List, if that number is less than a threshold value.
		/// </summary>
		public void TrimExcess()
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				list.TrimExcess();
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Determines whether every element in the List matches the conditions defined by the specified predicate.
		/// </summary>
		/// <param name="match">The Predicate delegate that defines the conditions to check against the elements.</param>
		/// <returns><b>true</b> if every element in the List matches the conditions defined by the specified predicate; otherwise, <b>false</b>. If the list has no elements, the return value is <b>true</b>.</returns>
		public bool TrueForAll(Predicate<T> match)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return list.TrueForAll(match);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
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
				List<T> newList = new List<T>(list);
				return newList.GetEnumerator();
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
				((ICollection) list).CopyTo(array, index);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Adds an item to the IList.
		/// </summary>
		/// <param name="value">The Object to add to the IList.</param>
		/// <returns>The position into which the new element was inserted.</returns>
		int IList.Add(object value)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				return ((IList) list).Add(value);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		/// Determines whether the IList contains a specific value.
		/// </summary>
		/// <param name="value">The Object to locate in the IList.</param>
		/// <returns><b>true</b> if item is found in the IList; otherwise, <b>false</b>.</returns>
		bool IList.Contains(object value)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return ((IList) list).Contains(value);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Determines the index of a specific item in the IList.
		/// </summary>
		/// <param name="value">The object to locate in the IList.</param>
		/// <returns>The index of item if found in the list; otherwise, ?.</returns>
		int IList.IndexOf(object value)
		{
			try
			{
				rwLock.AcquireReaderLock(Timeout.Infinite);
				return ((IList) list).IndexOf(value);
			}
			finally
			{
				rwLock.ReleaseReaderLock();
			}
		}

		/// <summary>
		/// Inserts an item to the IList at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index at which item should be inserted.</param>
		/// <param name="value">The object to insert into the IList.</param>
		void IList.Insert(int index, object value)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				((IList) list).Insert(index, value);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
			}
		}

		/// <summary>
		///	Removes the first occurrence of a specific object from the IList.
		/// </summary>
		/// <param name="value">The object to remove from the IList.</param>
		void IList.Remove(object value)
		{
			try
			{
				rwLock.AcquireWriterLock(Timeout.Infinite);
				((IList) list).Remove(value);
			}
			finally
			{
				rwLock.ReleaseWriterLock();
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
					return ((ICollection<T>) list).IsReadOnly;
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
					return ((ICollection) list).SyncRoot;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}

		/// <summary>
		/// Gets a value indicating whether the IList has a fixed size.
		/// </summary>
		bool IList.IsFixedSize
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return ((IList) list).IsFixedSize;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}

		/// <summary>
		/// Gets a value indicating whether the IList is read-only.
		/// </summary>
		bool IList.IsReadOnly
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return ((IList) list).IsReadOnly;
				}
				finally
				{
					rwLock.ReleaseReaderLock();
				}
			}
		}

		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index of the element to get or set.</param>
		/// <returns>The element at the specified index.</returns>
		object IList.this[int index]
		{
			get
			{
				try
				{
					rwLock.AcquireReaderLock(Timeout.Infinite);
					return ((IList) list)[index];
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
				}
				finally
				{
					rwLock.ReleaseWriterLock();
				}
			}
		}
		#endregion
	}
}
