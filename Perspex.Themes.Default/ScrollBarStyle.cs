﻿// -----------------------------------------------------------------------
// <copyright file="ScrollBarStyle.cs" company="Steven Kirk">
// Copyright 2014 MIT Licence. See licence.md for more information.
// </copyright>
// -----------------------------------------------------------------------

namespace Perspex.Themes.Default
{
    using System.Linq;
    using Perspex.Controls;
    using Perspex.Controls.Presenters;
    using Perspex.Controls.Primitives;
    using Perspex.Media;
    using Perspex.Styling;

    public class ScrollBarStyle : Styles
    {
        public ScrollBarStyle()
        {
            this.AddRange(new[]
            {
                new Style(x => x.OfType<ScrollBar>())
                {
                    Setters = new[]
                    {
                        new Setter(ScrollBar.TemplateProperty, ControlTemplate.Create<ScrollBar>(this.Template)),
                        new Setter(ScrollBar.HeightProperty, 20.0),
                    },
                },
            });
        }

        private Control Template(ScrollBar control)
        {
            return new Border
            {
                Background = Brushes.Silver,
                Content = new Track
                {
                    [~Track.MinimumProperty] = control[~ScrollBar.MinimumProperty],
                    [~Track.MaximumProperty] = control[~ScrollBar.MaximumProperty],
                    [~Track.ValueProperty] = control[~ScrollBar.ValueProperty],
                    [~Track.ViewportSizeProperty] = control[~ScrollBar.ViewportSizeProperty],
                    [~Track.OrientationProperty] = control[~ScrollBar.OrientationProperty],
                    Thumb = new Thumb
                    {
                        Template = ControlTemplate.Create<Thumb>(this.ThumbTemplate),
                    },
                },
            };
        }

        private Control ThumbTemplate(Thumb control)
        {
            return new Border
            {
                Background = Brushes.Gray,
            };
        }
    }
}