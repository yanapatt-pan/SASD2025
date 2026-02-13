using SkiaSharp;
using System;
using System.Collections.Generic;
using static SDL3.SDL;

namespace SkiaLiteUI;

public abstract class Widget
{
    public virtual void Act(float deltaTime) { }
    public abstract void Draw(SKCanvas canvas);
}

public class RectWidget : Widget
{
    public Vector Position { get; }
    public Vector Size { get; }
    public SKColor Color { get; init; } = SKColors.White;
    public float Radius { get; set; } = 0;

    public RectWidget(Vector origin, Vector size)
    {
        Position = origin;
        Size = size;

        var rand = new Random(); 
        time = rand.NextSingle() * 5; // Float single precision
    }

    float time = 0;
    public override void  Act(float deltaTime)
    {
        time += deltaTime;
        this.Radius = MathF.Max((MathF.Sin(time) + 1) * 64.0f, 0);
    }

    public override void Draw(SKCanvas canvas)
    {   
        // Replace widget with this (our)
        using SKPaint paint = Util.CreatePaint(this.Color);
        canvas.DrawRoundRect(new SKRoundRect((SKRect)this, this.Radius), paint);
    }

    public static explicit operator SKRect(RectWidget r)
    {
        return new SKRect(  r.Position.X, r.Position.Y, // todo: Symmetry Format
                            r.Position.X + r.Size.X,
                            r.Position.Y + r.Size.Y);
    }

    // todo: Where this method should move into ?
    public static RectWidget CreateRandom(Random rand, Vector max, Vector size)
    {
        var widget = new RectWidget(rand.NextVector(max), size)
        //{ Color = new SKColor(  (byte)rand.Next(256), 
        //                        (byte)rand.Next(256), 
        //                        (byte)rand.Next(256)) };
        { Color = rand.NextColor()};
        // todo: Extract & Move Method: rand.NextColor()
        return widget;
    }
}
