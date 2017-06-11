﻿namespace StingyJunk.Console
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    /// <summary>
    ///     The display area for a section of console
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class DisplayArea
    {
        //private Position _lastWritePosition;
        private Position _writePosition;

        public DisplayArea(string name, int top, int left, int bottom, int right)
        {
            Name = name;
            Top = top;
            Left = left;
            Bottom = bottom;
            Right = right;
        }

        /// <summary>
        ///     The name to refer to this by
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     The topmost line
        /// </summary>
        public int Top { get; }

        /// <summary>
        ///     The bottom most line
        /// </summary>
        public int Bottom { get; }

        /// <summary>
        /// The left most column
        /// </summary>
        public int Left { get; }

        /// <summary>
        /// The right most column
        /// </summary>
        public int Right { get; }

        /// <summary>
        ///     Does the area start writing at the <see cref="Top"/> when it 
        /// reaches <see cref="Bottom"/> and gets another command to emit text
        /// </summary>
        public bool Cycle { get; set; }

        /// <summary>
        ///     Does the area appear to scroll when it gets a command to emit text
        /// that would be outside its display boundary
        /// </summary>
        public bool Scroll { get; set; }

        /// <summary>
        ///     The last write position for this display area
        /// </summary>
        //internal Position LastWritePosition
        //{
        //    get => _lastWritePosition;
        //    private set
        //    {
        //        _lastWritePosition = value;
        //        IsCherryPop = true;
        //    }
        //}

        /// <summary>
        ///     The current write position
        /// </summary>
        internal Position WritePosition
        {
            get => _writePosition;
            private set => _writePosition = value;
        }

        internal void SetWritePosition(Position writePosition)
        {
            IsCherryPop = true;
           // Interlocked.CompareExchange(ref _lastWritePosition, _writePosition, _lastWritePosition);
            Interlocked.CompareExchange(ref _writePosition, writePosition, _writePosition);
        }


        internal bool IsCherryPop { get; private set; }
    }
}