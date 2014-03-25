﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Perspex.Controls;
using Perspex.Media;
using Perspex.Styling;

namespace Perspex.Themes.Default
{
    public class ButtonStyle : Styles
    {
        public ButtonStyle()
        {
            this.AddRange(new[]
            {
                new Style(new Selector().OfType<Button>())
                {
                    Setters = new[]
                    {
                        new Setter(Button.TemplateProperty, ControlTemplate.Create<Button>(this.Template)),
                    },
                },
                new Style(new Selector().OfType<Button>().Template().Id("border"))
                {
                    Setters = new[]
                    {
                        new Setter(Button.BackgroundProperty, new SolidColorBrush(0xffdddddd)),
                        new Setter(Button.BorderBrushProperty, new SolidColorBrush(0xff707070)),
                        new Setter(Button.BorderThicknessProperty, 2.0),
                        new Setter(Button.ForegroundProperty, new SolidColorBrush(0xff000000)),
                    },
                },
                new Style(new Selector().OfType<Button>().Class(":mouseover").Template().Id("border"))
                {
                    Setters = new[]
                    {
                        new Setter (Button.BackgroundProperty, new SolidColorBrush(0xffbee6fd)),
                        new Setter (Button.BorderBrushProperty, new SolidColorBrush(0xff3c7fb1)),
                    },
                },
                new Style(new Selector().OfType<Button>().Class(":pressed").Template().Id("border"))
                {
                    Setters = new[]
                    {
                        new Setter (Button.BackgroundProperty, new SolidColorBrush(0xffc4e5f6)),
                        new Setter (Button.BorderBrushProperty, new SolidColorBrush(0xff2c628b)),
                    },
                },
            });
        }

        private Control Template(Button control)
        {
            Border border = new Border();
            border.Id = "border";
            border.SetValue(Border.BackgroundProperty, control.GetObservable(Button.BackgroundProperty));
            border.SetValue(Border.BorderBrushProperty, control.GetObservable(Button.BorderBrushProperty));
            border.SetValue(Border.BorderThicknessProperty, control.GetObservable(Button.BorderThicknessProperty));
            border.Padding = new Thickness(3);
            ContentPresenter contentPresenter = new ContentPresenter();
            contentPresenter.SetValue(ContentPresenter.ContentProperty, control.GetObservable(Button.ContentProperty));
            border.Content = contentPresenter;
            return border;
        }
    }
}