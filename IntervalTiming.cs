using System;

namespace DungeonRoguelike;

public class IntervalTiming
{
    private readonly TimeSpan interval;
    private TimeSpan lastEventTimestamp;

    public IntervalTiming(TimeSpan interval)
    {
        this.interval = interval;
        lastEventTimestamp = TimeSpan.Zero;
    }

    public bool IsReady(TimeSpan currentTime)
    {
        if (currentTime - lastEventTimestamp >= interval || currentTime == TimeSpan.Zero)
        {
            lastEventTimestamp = currentTime;
            return true;
        }

        return false;
    }
}