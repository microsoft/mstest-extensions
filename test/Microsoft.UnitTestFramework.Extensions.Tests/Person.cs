// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.

namespace Microsoft.UnitTestFramework.Extensions
{
    using System.ComponentModel;

    public class Person : INotifyPropertyChanged
    {
        private int id;
        private string first;
        private string last;

        public int Id
        {
            get => id;
            set
            {
                if ( id == value )
                {
                    return;
                }

                id = value;
                OnPropertyChanged( nameof( Id ) );
            }
        }

        public string FirstName
        {
            get => first;
            set
            {
                if ( first == value )
                {
                    return;
                }

                first = value;
                OnPropertyChanged( nameof( FirstName ) );
                OnPropertyChanged( nameof( FullName ) );
            }
        }

        public string LastName
        {
            get => last;
            set
            {
                if ( last == value )
                {
                    return;
                }

                last = value;
                OnPropertyChanged( nameof( LastName ) );
                OnPropertyChanged( nameof( FullName ) );
            }
        }

        public string FullName => $"{FirstName} {LastName}";

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged( string propertyName ) =>
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
    }
}