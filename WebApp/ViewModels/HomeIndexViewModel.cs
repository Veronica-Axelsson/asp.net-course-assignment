﻿namespace WebApp.ViewModels
{
    public class HomeIndexViewModel
    {
        public string Title { get; set; } = "Home";

        public GridCollectionItemViewModel All { get; set; } = null!;

        //public GridCollectionViewModel BestCollection { get; set; } = null!;
    }
}