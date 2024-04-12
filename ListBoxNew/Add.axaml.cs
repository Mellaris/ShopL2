using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Platform.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ListBoxNew;
using System.Drawing;
using Avalonia.Media.Imaging;
using Bitmap = Avalonia.Media.Imaging.Bitmap;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;


public partial class Add: Window
{
    List<Changing> names = new List<Changing>();
    List<Changing> valuest = new List<Changing>();
    string fileName;
    public Add()
    {
        InitializeComponent();
    }
    public Add( List<Changing> productsName, List<Changing> values)
    {
        InitializeComponent();
        
        foreach (Changing strCol in productsName)
        {
            names.Add(strCol);
        }
        foreach (Changing strCol in values)
        {
            valuest.Add(strCol);
        }
        animals.ItemsSource = names.ToList();
    }
    private void Dobavlen(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (animals.SelectedItems.Count > 0)
        {
            foreach (Changing strCol in animals.SelectedItems)
            {
                names.Add(new Changing()
                {
                    NameV = prodName.Text,
                    PriceV = priceName.Text,
                    fileName = fileName,
                    Sum = 1,
                    del = names.Count,
                    edit = names.Count,
                    idKol = names.Count,
                    NameDob = strCol.NameV,
                });
            }
        }
        else
        {
            names.Add(new Changing()
            {
                NameV = prodName.Text,
                PriceV = priceName.Text,
                fileName = fileName,
                Sum = 1,
                del = names.Count,
                edit = names.Count,
                idKol = names.Count,
            });
        }  
        new MainWindow(names, valuest).Show();
        Close();
        //animals.ItemsSource = names.ToList();

    }
    private string _photo;
    public async void Pict(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        var topLevel = await openFileDialog.ShowAsync(this);
        fileName = String.Join("", topLevel);
        Random random = new Random();
        string photo = "photo" + random.Next(1, 10000) + ".jpg";
        //File.Copy(fileName, photo, true);
        _photo = photo;
        im.Source = new Bitmap(fileName);
        //var files = topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions());
    }
}