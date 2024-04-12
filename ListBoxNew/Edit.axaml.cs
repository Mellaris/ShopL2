using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

namespace ListBoxNew;

public partial class Edit : Window
{
    List<Changing> values = new List<Changing>();
    List<Changing> names = new List<Changing>();
    List<Changing> val = new List<Changing>();
    List<Changing> nameCh = new List<Changing>();
    int help = 0;
    int helpTwo = 0;
    string file;
    int helpThree = 0;

    public Edit()
    {
        InitializeComponent();
    }
    public Edit(List<Changing> valuesT, List<Changing> productsName, List<Changing> valuest)
    {
        InitializeComponent();
        foreach (Changing c in valuesT)
        {
            prodName.Text = c.NameV;
            priceName.Text = c.PriceV;
            if (c.fileName != null)
            {
                im.Source = new Bitmap(c.fileName);
            }        
            values.Add(c);
        }
        foreach (Changing c in productsName)
        {
            names.Add(c);
        }
        foreach (Changing c in valuest)
        {
            val.Add(c);
        }
        helpThree = 0;
        foreach (Changing q in values)
        {
            foreach (Changing w in names)
            {
                if (q.NameDob != null)
                {
                    if(q.NameDob == w.NameV)
                    {
                        animals.ItemsSource = names.Skip(names.IndexOf(w)).Take(1).ToList();
                        break;
                    }
                }
            }
            break;
        }
    }
    public void ChOther(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        foreach(Changing c in values)
        {
            foreach(Changing w in names)
            {
                if(c.NameV != w.NameV)
                {
                    nameCh.Add(w);
                }
            }
            break;
        }
        animals.ItemsSource = nameCh.ToList();
        
    }
    public void EditB(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (values.Count > 0)
        {
            foreach (Changing changing in values)
            {
                foreach (Changing c in val)
                {
                    if (changing.PriceV == c.PriceV && changing.NameV == c.NameV)
                    {
                        helpTwo++;
                    }
                }
            }
        }
        if (helpTwo > 0)
        {
            foreach (Changing changing in names)
            {
                foreach (Changing c in values)
                {
                    foreach(Changing c2 in val)
                    {
                        if (changing.PriceV == c.PriceV && changing.NameV == c.NameV)
                        {
                            changing.PriceV = priceName.Text;
                            changing.NameV = prodName.Text;
                            if (helpThree > 0)
                            {
                                changing.fileName = file;
                            }      
                            else
                            {
                                changing.fileName = changing.fileName;
                            }
                            if (animals.SelectedItems.Count > 0)
                            {
                                foreach(Changing strCol in animals.SelectedItems)
                                {
                                    changing.NameDob = strCol.NameV;
                                    c.NameDob = strCol.NameV;
                                    c2.NameDob = strCol.NameV;
                                    break;
                                }
                                
                            }
                            c.PriceV = priceName.Text;
                            c.NameV = prodName.Text;
                            if (helpThree > 0)
                            {
                                c.fileName = file;
                            }
                            else
                            {
                                c.fileName = c.fileName;
                            }                          
                            c2.PriceV = priceName.Text;
                            c2.NameV = prodName.Text;
                            if (helpThree > 0)
                            {
                                c2.fileName = file;
                            }
                            else
                            {
                                c2.fileName = c2.fileName;
                            }
                            break;
                        }
                    }
                    if (help > 0)
                    {
                        break;
                    }

                }
                if (help > 0)
                {
                    break;
                }
            }
        }
        else if (helpTwo == 0)
        {
            foreach (Changing changing in names)
            {
                foreach (Changing c in values)
                {
                    if (changing.PriceV == c.PriceV && changing.NameV == c.NameV)
                    {

                        changing.PriceV = priceName.Text;
                        changing.NameV = prodName.Text;
                        if (helpThree > 0)
                        {
                            changing.fileName = file;
                        }   
                        else
                        {
                            changing.fileName = changing.fileName;
                        }
                        if (animals.SelectedItems.Count > 0)
                        {
                            foreach (Changing strCol in animals.SelectedItems)
                            {
                                changing.NameDob = strCol.NameV;
                                c.NameDob = strCol.NameV;
                                break;
                            }

                        }
                        c.PriceV = priceName.Text;
                        c.NameV = prodName.Text;
                        if (helpThree > 0)
                        {
                            c.fileName = file;
                        }
                        else
                        {
                            c.fileName = c.fileName;
                        }
                        help++;
                        break;
                    }
                }
                if (help > 0)
                {
                    break;
                }
            }
        }
        new MainWindow(names, val).Show();
        Close();
    }
    private string _photo;
    public async void Pictt(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        helpThree++;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        var top = await openFileDialog.ShowAsync(this);
        file = String.Join("", top);
        Random random = new Random();
        string photo = "photo" + random.Next(1, 10000) + ".jpg";
        //File.Copy(fileName, photo, true);
        _photo = photo;
        im.Source = new Bitmap(file);
    }
}