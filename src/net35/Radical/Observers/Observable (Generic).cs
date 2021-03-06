﻿using System;
using System.ComponentModel;

namespace Topics.Radical
{
    /// <summary>
    /// An observable generic type.
    /// </summary>
    /// <typeparam name="T">The type proxied by this observable.</typeparam>
    public class Observable<T> : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        protected virtual void OnPropertyChanged()
        {
            if( this.PropertyChanged != null )
            {
                this.PropertyChanged( this, new PropertyChangedEventArgs( "Value" ) );
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Observable&lt;T&gt;"/> class.
        /// </summary>
        public Observable()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Observable&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Observable( T value )
        {
            this._value = value;
        }

        private T _value;

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public virtual T Value
        {
            get { return this._value; }
            set
            {
                if( !Object.Equals( value, this.Value ) )
                {
                    this._value = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Topics.Radical.Observable&lt;T&gt;"/> to <see ref="T"/>.
        /// </summary>
        /// <param name="val">The source value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator T( Observable<T> val )
        {
            return val.Value;
        }
    }
}