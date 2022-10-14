﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private SortedSet<Book> books;

        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books, new BookComparator());
        }

        public IEnumerator<Book> GetEnumerator() => new LibraryIterator(this.books.ToList());

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();


        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int index;

            public LibraryIterator(List<Book> books)
            {
                this.books = books;
                this.Reset();
            }

            public Book Current => this.books[this.index];

            object IEnumerator.Current => this.Current;

            public void Dispose() { }

            public bool MoveNext() => ++this.index < this.books.Count;

            public void Reset() => this.index = -1;
        }
    }
}
