
namespace CustomDoublyLinkedList
{
    using System;
    public class CustomDoublyLinkedList<T>
    {
        private class ListNode
        {
            public ListNode(T value)
            {
                this.Value = value;
            }

            public T Value { get;  }
            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }
        }

        private ListNode headNode;
        private ListNode tailNode;

        public CustomDoublyLinkedList()
        {

        }

        public int Count { get; set; }
        public void AddFirst(T element)
        {
            if (this.headNode == null)
            {
                this.headNode = new ListNode(element);
                this.tailNode = this.headNode;
            }
            else
            {
                var newHead = new ListNode(element);
                newHead.NextNode = this.headNode;
                this.headNode.PreviousNode = newHead;
                this.headNode = newHead;
            }
            this.Count++;
        }

        public void AddLast(T element)
        {
            if (this.tailNode == null)
            {
                this.tailNode = new ListNode(element);
                this.headNode = this.tailNode;
            }
            else
            {
                var newTail = new ListNode(element);
                newTail.PreviousNode = this.tailNode;
                this.tailNode.NextNode = newTail;
                this.tailNode = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List empty");
            }

            var value = this.headNode.Value;
            this.headNode = this.headNode.NextNode;
            this.Count--;
            return value;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List empty");
            }

            var value = this.tailNode.Value;
            this.tailNode = this.tailNode.PreviousNode;
            this.Count--;
            return value;
        }

        public void ForEach(Action<T> action)
        {
            var currEl = this.headNode;
            while (currEl != null)
            {
                action(currEl.Value);
                currEl = currEl.NextNode;
            }
        }

        public T[] ToArray()
        {
            var currEl = this.headNode;
            var arr = new T[this.Count];
            var index = 0;
            while (currEl != null)
            {
                arr[index] = currEl.Value;
                currEl = currEl.NextNode;
                index++;
            }

            return arr;
        }
    }
}
