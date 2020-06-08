﻿using InventoryMobileApp.Commands;
using InventoryMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace InventoryMobileApp.Views.Behaviours
{
    public class DesignationItemTappedBehaviour : Behavior<ListView>
    {
        /// <summary>
        /// Attach events
        /// </summary>        
        protected override void OnAttachedTo(ListView listView)
        {
            base.OnAttachedTo(listView);
            listView.ItemTapped += ListView_ItemTapped;
        }

        /// <summary>
        /// Detach events
        /// </summary>        
        protected override void OnDetachingFrom(ListView listView)
        {
            base.OnDetachingFrom(listView);
            listView.ItemTapped -= ListView_ItemTapped;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var listView = (ListView)sender;
            var designationViewModel = (DesignationViewModel)listView.BindingContext;
            var designationItemTappedCommand = new DesignationItemTappedCommand();
            designationItemTappedCommand.Execute(designationViewModel);
        }
    }
}
