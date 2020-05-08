
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Database
    {
        private IEnumerable<int> integers;
        public Database(IEnumerable<int> args)
        {
            this.Integers = args;
        }

        public IEnumerable<int> Integers
        {
            get => this.integers;
            private set
            {
                if (value.Count() > 16)
                {
                    throw new InvalidOperationException("Cannot have more than 16 integers");
                }
                else
                {
                    this.integers = value;
                }
            }
        }

        public void Add(int newElement)
        {
            if (this.integers.Count() == 16)
            {
                throw new InvalidOperationException("Cannot add any more integers");
            }
            else
            {
                var list = this.integers.ToList();
                list.Add(5);
                this.integers = list;
            }
        }

        public void Remove(int elementToRemove)
        {
            if (!this.integers.Any())
            {
                throw new InvalidOperationException("Cannot remove from an empty database");
            }
            else
            {
                var list = this.integers.ToList();
                list.Reverse();
                list.Remove(elementToRemove);
                list.Reverse();
                this.integers = list;
            }
        }

        public int[] Fetch()
        {
            return this.integers.ToArray();
        }
    }
