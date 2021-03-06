﻿namespace Topics.Radical.Validation
{
    using System;

    /// <summary>
    /// Defines some extensions facilities for the <see cref="Ensure"/> class.
    /// </summary>
    public static class EnsureExtensions
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the currently 
        /// inspected object is a null reference.
        /// </summary>
        /// <typeparam name="T">The type of the inspected object.</typeparam>
        /// <param name="validator">The current validator.</param>
        /// <returns>The current validator for fluent interface usage.</returns>
        public static IEnsure<T> IsNotNull<T>( this IEnsure<T> validator )
            where T : class
        {
            //var value = validator.GetValue<T>();
            //if ( value == null ) 
            //{
            //    throw new ArgumentNullException( validator.Name, validator.GetFullErrorMessage( "The inspected value should be non null." ) );
            //}
            validator.If( s => s == null )
                .ThenThrow( e => 
                {
                    return new ArgumentNullException( e.Name, e.GetFullErrorMessage( "The inspected value should be non null." ) );
                } );

            return validator;
        }
    }
}
