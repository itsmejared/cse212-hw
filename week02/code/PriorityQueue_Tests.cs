using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue Items with Different Priorities and Dequeue the Highest Priority Item
    // Expected Result: The item with the highest priority should be dequeued first.
    // Defect(s) Found: 
    //          1 - The priority comparison in Dequeue() uses '>=' which causes incorrect Dequeue behavior
    //              Instead of Dequeueing the highest priority item, it dequeues the last item with 
    //              the highest priority due to the '>=' comparison.

    public void TestPriorityQueue_DequeueHighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("LowPriorityItem", 1);
        priorityQueue.Enqueue("HighPriorityItem", 10);
        priorityQueue.Enqueue("MediumPriorityItem", 5);

        var dequeuedItem = priorityQueue.Dequeue(); // Should dequeue "HighPriorityItem"

        Assert.AreEqual("HighPriorityItem", dequeuedItem, "The dequeued item should be the one with the highest priority.");

    }

    [TestMethod]
    // Scenario: Enqueue Items with Duplicate Priorities and Dequeue the first Enqueued Item
    // Expected Result: First item with the highest priority should be dequeued first.
    // Defect(s) Found:
    //      1 - When multiple items share the same priority, the queue does not preserve the
    //          order in which they were added. The expected behavior is FIFO for equal priorities (first enqueued, first dequeued).
    //      2 - The priority comparison treats equal priorities as "higher" (uses '>='), which
    //          causes a later-enqueued item to win ties( meaning the last one added with that priority is dequeued first).
    //      3 - The Dequeue() implementation removes the wrong element from the list.
    //          It must remove the item at the index we found as highest priority, not some other
    //          element (which results in the wrong item being returned/removed).

    public void TestPriorityQueue_DequeueDuplicatePriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("FirstItem", 5);
        priorityQueue.Enqueue("SecondItem", 5);
        priorityQueue.Enqueue("ThirdItem", 5);

        var dequeuedItem = priorityQueue.Dequeue(); // Should dequeue "FirstItem"

        Assert.AreEqual("FirstItem", dequeuedItem, "The dequeued item should be the first one enqueued with the highest priority.");
    }

    [TestMethod]
    // Scenario: Dequeue from an Empty Queue
    // Expected Result: An InvalidOperationException should be thrown.
    // Defect(s) Found: None
    public void TestPriorityQueue_DequeueEmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected an exception to be thrown");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message, "The exception message should indicate that the queue is empty.");
        }
    }
}