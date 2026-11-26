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
    IConnectivity connectivity;
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
        
        if(connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            Application.Current.MainPage.DisplayAlert("No Internet", "You are not connected to the internet", "OK");
            return;
        }

        Items.Add(Text);
        Text = string.Empty;
    }
    
    [RelayCommand]
    void Delete(string s)
    {
        if (Items.Contains(s))
            Items.Remove(s);

    }
    [RelayCommand]
    async Task Tap(string s)
    {
        if (Items.Contains(s))
        {
            await Shell.Current.GoToAsync(nameof(DetailPage), new Dictionary<string, object>
            {
                {"item", s}
            });
        }
    }
}
