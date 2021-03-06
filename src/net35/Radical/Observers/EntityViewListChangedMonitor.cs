﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Topics.Radical.ComponentModel;
using System.ComponentModel;

namespace Topics.Radical.Observers
{
    //public static class EntityViewObserver
    //{
    //    public static EntityViewMonitor Monitor( IEntityView source )
    //    {
    //        return new EntityViewMonitor( source );
    //    }
    //}

    public class EntityViewListChangedMonitor : AbstractMonitor<IEntityView>
    {
        ListChangedEventHandler handler = null;

        public EntityViewListChangedMonitor( IEntityView source )
            : base( source )
        {

        }

        public EntityViewListChangedMonitor()
            : base()
        {

        }

        public EntityViewListChangedMonitor( IEntityView source, IDispatcher dispatcher )
            : base( source, dispatcher )
        {

        }

        public EntityViewListChangedMonitor( IDispatcher dispatcher )
            : base( dispatcher )
        {

        }

        protected override void StartMonitoring( object source )
        {
            base.StartMonitoring( source );

            handler = ( s, e ) => this.OnChanged();
            this.Source.ListChanged += handler;
        }

        public void Observe( IEntityView source )
        {
            this.StopMonitoring();
            this.StartMonitoring( source );
        }

        protected override void OnStopMonitoring( Boolean targetDisposed )
        {
            if( !targetDisposed && this.WeakSource != null && this.WeakSource.IsAlive )
            {
                this.Source.ListChanged -= handler;
            }

            handler = null;
        }
    }
}
