using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MAUI_For_Beginners.ViewModel;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
     ObservableCollection<string> items = new ObservableCollection<string>();

    public MainViewModel()
    {
        Items = new();
    }

    [ObservableProperty]
    string text;

    [RelayCommand]
    void Add()
    {
        if(string.IsNullOrWhiteSpace(Text))
            return;

        Items.Add(Text);
        Text = string.Empty;
    }
    
    [RelayCommand]
    void Delete(string s)
    {
        if (Items.Contains(s))
            Items.Remove(s);

    }
}
