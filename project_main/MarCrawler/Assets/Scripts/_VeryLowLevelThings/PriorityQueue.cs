using System.Collections.Generic;

/// <summary>
/// a priority queue for non-arbitrary priorities.
/// Higer numbers mean higer priority.
/// </summary>
public class PriorityQueue<T>{

	private int minPriority;
	private int maxPriority;
	private Queue<T>[] queues;
	private int size;

	public PriorityQueue(int minPriority, int maxPriority){

		if (minPriority > maxPriority)
			throw new PriorityQueueException ("minPriority must be lower than maxPriority");

		this.minPriority = minPriority;
		this.maxPriority = maxPriority;

		queues = new Queue<T>[maxPriority - minPriority + 1];
	
		this.size = 0;
	}

	public int Size{
		get{ return size; }
	}

	public void Enqueue(T item, int priority){
		if (priority > maxPriority || priority < minPriority)
			throw new PriorityQueueException("given priority is not in the accepted range. priority: " + priority 
				+ " range:" + minPriority + " to " + maxPriority);

		queues [priority].Enqueue (item);
		size++;
	}

	public T Dequeue(){
		if (size < 0)
			throw new PriorityQueueException("priority queue is empty");

		T result = default(T);

		for (int i = maxPriority; i >= minPriority; i--) {
			if (queues [i].Count > 0) {
				size--;
				result = queues [i].Dequeue();
				break;
			}
		}

		return result;
	}

}